using System;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Return.Web.Api.Services;
using Returns.Models;

namespace Return.Web.Api;

public static class Extensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddReturnsDbContextFactory(Func<IServiceProvider, DbContextOptions>? factory = null)
        {
            //Would setup ef based on Func or existing database options, but will keep simplistic for now and
            //  use hardcoded data in the service
            return services;
        }
        
        public IServiceCollection AddReturnsService()
        {
            //if the service required a more complex setup, we could add options and validation here. 
            // Say you need to retrieve keys from vault for the 
            services.AddSingleton<IInvestmentService, InvestmentService>();
            return services;
        }
        
        public IServiceCollection AddMapsterProfiles()
        {
            var config = new TypeAdapterConfig();
            //usually, mapping from db models to response models, use to using mapster or manual mapping
            config.NewConfig<Database.Investment, InvestmentRes>();
                //.Map(...); for some custom mapping
                
            config.Compile(); //precompile
            services.AddSingleton(config);
            return services;
        }
    }
}