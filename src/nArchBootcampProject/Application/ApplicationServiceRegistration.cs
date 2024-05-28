using System.Reflection;
using Application.Services.Applicants;
using Application.Services.ApplicationInformations;
using Application.Services.ApplicationStateInformations;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.Blacklists;
using Application.Services.BootcampImages;
using Application.Services.Bootcamps;
using Application.Services.BootcampStates;
using Application.Services.Employees;
using Application.Services.Instructors;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using Application.Services.Chapters;
using Application.Services.Comments;
using Application.Services.Announcements;
using Application.Services.Certificates;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int>();

        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IApplicationInformationService, ApplicationInformationManager>();
        services.AddScoped<IApplicationStateInformationService, ApplicationStateInformationManager>();
        services.AddScoped<IBlacklistService, BlacklistManager>();
        services.AddScoped<IBootcampService, BootcampManager>();
        services.AddScoped<IBootcampImageService, BootcampImageManager>();
        services.AddScoped<IBootcampStateService, BootcampStateManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IChapterService, ChapterManager>();
        services.AddScoped<ICommentService, CommentManager>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
