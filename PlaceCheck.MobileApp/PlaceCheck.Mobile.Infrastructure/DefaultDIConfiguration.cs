using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Mobile.Infrastructure.PlaceCheckApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceCheck.Mobile.Infrastructure
{
    public static class DefaultDIConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPlaceCheckApi(configuration);
            return services;
        }
    }
}
