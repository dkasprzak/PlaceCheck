using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Mobile.Application.Interfaces;
using PlaceCheck.Mobile.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PlaceCheck.Mobile.Infrastructure.PlaceCheckApi
{
    public static class PlaceCheckApiConfiguration
    {
        public static IServiceCollection AddPlaceCheckApi(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<PlaceCheckApiOptions>(configuration.GetSection("ApiClients:PlaceCheckApi"));
            services.AddHttpClient<IPlaceCheckApiService, PlaceCheckApiService>(cliient =>
            {
                var options = configuration.GetSection("ApiClients:PlaceCheckApi").Get<PlaceCheckApiOptions>();
                cliient.BaseAddress = new Uri(options.BaseUrl);
                cliient.DefaultRequestHeaders.Accept.Clear();
                cliient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
