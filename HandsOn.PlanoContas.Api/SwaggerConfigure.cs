using Microsoft.OpenApi.Models;

namespace HandsOn.PlanoContas.Api;

public static class SwaggerConfigure
{

    public static void Configure(IServiceCollection services)
    {


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Plano de Contas", Version = "v1" });
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "Controle de Plano de Contas",
                Type = SecuritySchemeType.ApiKey,
                Name = "XApiKey",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });
            var key = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            };
            var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
            c.AddSecurityRequirement(requirement);
        });






    }

}
