using APIMaisEventos.Inerfaces.Infra;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace APIMaisEventos.Infra
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IConfiguration _config;
   
        public AppSettingsManager(IConfiguration config) 
        {
            _config = config;
        }

        public string GetValue(string Property) 
        {
            return _config.GetValue<string>(Property);
        }

    }
}
