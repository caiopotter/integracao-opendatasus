using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Fiotec.Prova.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FIOTEC - API Integração OpenDataSUS",
                    Version = "v1",
                    Description = "Caio Lima Potter<br/> "
                });

                options.IncludeXmlComments(GetPathForDocuments());
                options.CustomSchemaIds(type => type.ToString());
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app, IConfiguration configuration)
        {
            var basePath = configuration["AppSettings:BasePath"];

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "FIOTEC - API Integração OpenDataSUS");                
                c.DocExpansion(DocExpansion.None);
                c.DocumentTitle = "FIOTEC - API Integração OpenDataSUS";                
                c.OAuthClientSecret("swagger-ui-secret");
                c.OAuthRealm("swagger-ui-realm");
                c.OAuthAppName("Swagger UI");
            });

            app.UseStaticFiles();




            return app;
        }

        private static string GetPathForDocuments()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppContext.BaseDirectory, xmlFile);
        }

    }
}
