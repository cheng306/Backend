using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDatabase>(opt => opt.UseInMemoryDatabase());
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddMvc();
            //services.AddDbContext<UserContext>(NewMethod());
           // services.AddEntityFrameworkInMemoryDatabase();

        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Cors");
            app.UseMvc();
            InitializeDb(serviceProvider.GetService<AppDatabase>());
        }

        public void InitializeDb(AppDatabase database)
        {
            database.TransfersList.Add(new Transfer{Sender = "John",Amount = 10});
            database.TransfersList.Add(new Transfer{ Sender = "Tim",Amount = 20});

            database.Users.Add(new User { Email = "a@gmail.com", FirstName = "Tim", LastName = "Tim", Password = "a", UserName="Timu" });

            database.SaveChanges();
        }


    }
}
