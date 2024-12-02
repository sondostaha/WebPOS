using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace WebPOS.Extentions
{
    public static class CustomeJWTExtention
    {
        public static void AddCustomeJwtAuthentication(this IServiceCollection services ,ConfigurationManager configuration)
        {
            services.AddAuthentication(o =>
            { 
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            
            ).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))

                };
            }); 
        }
        public static void AddCustoemSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(e =>
            {
                e.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Web_POS",
                    //Description = ""
                    Contact =new OpenApiContact() 
                    {
                        Name = "Admin",
                        Email ="SuperAdmin@gmail.com",
                        //Url = 
                    }
                });
                e.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter The Jwt Key",
                });
                e.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
                });
            });
        }
    }
}
