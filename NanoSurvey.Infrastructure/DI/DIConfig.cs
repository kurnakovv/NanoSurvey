using Microsoft.Extensions.DependencyInjection;
using NanoSurvey.Application.Abstracts.Repositories;
using NanoSurvey.Application.Abstracts.Services;
using NanoSurvey.Application.Services;
using NanoSurvey.Infrastructure.Data;

namespace NanoSurvey.Infrastructure.DI
{
    public static class DIConfig
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISurveyRepositoryAsync, SurveyRepositoryAsync>();

            services.AddTransient<ISurveyServiceAsync, SurveyServiceAsync>();
        }
    }
}
