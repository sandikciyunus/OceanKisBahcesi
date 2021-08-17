using Microsoft.Extensions.DependencyInjection;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.Business.Concrete;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<OceanContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderDal, EfSliderDal>();
            
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceDal, EfServiceDal>();  
            
            services.AddScoped<IAddressInformationService, AddressInformationService>();
            services.AddScoped<IAdressInformationDal, EfAddressInformationDal>();
        }
    }
}
