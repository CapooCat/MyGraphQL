using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MyGraphQL.GraphQL;
using MyGraphQLs.HotChocolate;
using MyGraphQLs.HotChocolate.Models;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphQLs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Them Authentication
            var key = "4fb4043e16ff127eca681216598a830e8b0cf3bf";
            var issuer = DataEncryption.EncryptString(System.Net.Dns.GetHostName());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidateIssuer = true,
                    ValidAudience = issuer,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuerSigningKey = true
                };
            });
            //Ket noi database
            services.AddPooledDbContextFactory<BookShellContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Khoi tao GraphQL schema
            services
                .AddGraphQLServer()

                .AddMutationType<Mutation>()

                .AddFiltering()
                .AddProjections()
                .AddAuthorization()

                .AddType<BookType>()
                .AddType<UserType>()

                .AddQueryType<Query>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //setup duong dan GraphQL
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }
            app.UseAuthentication();
            app.UseGraphQL("/api");
        }
    }
}
