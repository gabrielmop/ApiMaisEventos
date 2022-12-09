using APIMaisEventos.Inerfaces;
using APIMaisEventos.Inerfaces.Infra;
using APIMaisEventos.Infra;
using APIMaisEventos.Repositories;
using APIMaisEventos.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Runtime.CompilerServices;

namespace APIMaisEventos.ServiceConfiguration
{
    public static class ServiceConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration config )
        {
            services.AddSingleton(config);
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAppSettingsManager, AppSettingsManager>();
            services.AddTransient<ISqlDataContext, SqlDataContext>();
            services.AddTransient<IusuarioRepository, UsuarioRepository>();
            services.BuildServiceProvider();
        }
    }
}
