﻿using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<HotelRepository>();
            return services;
        }
    }
    
}