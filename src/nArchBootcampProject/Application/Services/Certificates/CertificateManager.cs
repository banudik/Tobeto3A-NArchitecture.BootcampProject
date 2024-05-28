using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Application.Services.UsersService;
using Application.Services.Bootcamps;

namespace Application.Services.Certificates;

public class CertificateManager : ICertificateService
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly CertificateBusinessRules _certificateBusinessRules;
    private readonly IUserService _userService;
    private readonly IBootcampService _bootcampService;

    public CertificateManager(ICertificateRepository certificateRepository, CertificateBusinessRules certificateBusinessRules, IUserService userService, IBootcampService bootcampService)
    {
        _certificateRepository = certificateRepository;
        _certificateBusinessRules = certificateBusinessRules;
        _userService = userService;
        _bootcampService = bootcampService;
    }

    public async Task<Certificate?> GetAsync(
        Expression<Func<Certificate, bool>> predicate,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Certificate? certificate = await _certificateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return certificate;
    }

    public async Task<IPaginate<Certificate>?> GetListAsync(
        Expression<Func<Certificate, bool>>? predicate = null,
        Func<IQueryable<Certificate>, IOrderedQueryable<Certificate>>? orderBy = null,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Certificate> certificateList = await _certificateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return certificateList;
    }

    public async Task<Certificate> AddAsync(Certificate certificate)
    {
        Certificate addedCertificate = await _certificateRepository.AddAsync(certificate);

        return addedCertificate;
    }

    public async Task<Certificate> UpdateAsync(Certificate certificate)
    {
        Certificate updatedCertificate = await _certificateRepository.UpdateAsync(certificate);

        return updatedCertificate;
    }

    public async Task<Certificate> DeleteAsync(Certificate certificate, bool permanent = false)
    {
        Certificate deletedCertificate = await _certificateRepository.DeleteAsync(certificate);

        return deletedCertificate;
    }

    public async Task GenerateCertificatePdf(Certificate certificate)
    {
        User? user = await _userService.GetAsync(
            predicate: u => u.Id == certificate.UserId
        );

        Bootcamp? bootcamp = await _bootcampService.GetAsync(
            predicate: u => u.Id == certificate.BootcampId
        );


        var fileName = $"{certificate.Id}.pdf";
        var filePath = Path.Combine("GeneratedCertificates", fileName);

        Directory.CreateDirectory("GeneratedCertificates");

        using (var writer = new PdfWriter(filePath))
        {
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                document.Add(new Paragraph("Certificate of Completion")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(24));

                document.Add(new Paragraph("This is to certify that")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18));

                document.Add(new Paragraph(user.FirstName + " " + user.LastName)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20)
                    .SetBold());

                document.Add(new Paragraph("has successfully completed the course")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18));

                document.Add(new Paragraph(bootcamp.Name)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20)
                    .SetBold());

                document.Add(new Paragraph($"on {certificate.CreatedDate.ToShortDateString()}")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18));

                document.Close();
            }
        }

        await Task.CompletedTask;
    }
}
