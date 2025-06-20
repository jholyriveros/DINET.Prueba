﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DINET.Prueba.Helpers
{
    /// <summary>
    /// Http Client Extensions
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Add HttpClient If Configured
        /// </summary>
        public static void AddHttpClientIfConfigured(this IServiceCollection services, string name,
                                                        IConfiguration configuration, string configKey)
        {
            var apiUrl = configuration.GetValue<string>(configKey);
            if (apiUrl != null)
            {
                services.AddHttpClient(name, httpClient =>
                {
                    httpClient.BaseAddress = new Uri(apiUrl);
                });
            }
        }
    }
}