using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DigitalMark.Data;
using DigitalMark.Repositories;
using Microsoft.Extensions.Configuration;

namespace DigitalMark
{
    public class Startup
    {

        public IConfiguration Configuration {get; set;}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<HospitalRepository, HospitalRepository>();
            services.AddTransient<EnderecoRepository, EnderecoRepository>();
            services.AddTransient<EnfermeiroRepository, EnfermeiroRepository>();
            services.AddTransient<HospitalEnfermeiroRepository, HospitalEnfermeiroRepository>();

             services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                     builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
            }));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseMvc();
        
        }
    }
}
