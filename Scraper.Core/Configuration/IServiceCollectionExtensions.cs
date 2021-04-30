using Microsoft.Extensions.DependencyInjection;
using Scraper.Core.Interfaces.Requests;
using Scraper.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDefaultScraperConfiguration(this IServiceCollection services)
        {
            services.AddSingleton(ScraperDefaults.Configuration);
            services.AddSingleton(new HttpClient());

            services.AddScoped<IRequestService, RequestService>();

            return services;
        }
    }
}
