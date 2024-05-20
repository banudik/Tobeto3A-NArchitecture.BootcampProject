using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("NArchBootcampProjectString"))
        );
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<IApplicationInformationRepository, ApplicationInformationRepository>();
        services.AddScoped<IApplicationStateInformationRepository, ApplicationStateInformationRepository>();
        services.AddScoped<IBlacklistRepository, BlacklistRepository>();
        services.AddScoped<IBootcampRepository, BootcampRepository>();
        services.AddScoped<IBootcampImageRepository, BootcampImageRepository>();
        services.AddScoped<IBootcampStateRepository, BootcampStateRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        return services;
    }
}
