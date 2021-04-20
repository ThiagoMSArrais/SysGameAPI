using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SysGame.Domain.Interfaces;
using SysGame.Domain.Notificacoes;
using SysGame.Domain.Services;
using SysGame.Infra.Data.Repository;

namespace SysGame.CrossCutting.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            services.AddScoped<IAmigoServices, AmigoService>();
            services.AddScoped<IJogoServices, JogoService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
