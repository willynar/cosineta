using Cocinecta;
using Entities.Administration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using NSwag;
using NSwag.Generation.Processors.Security;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
});

// IConfiguration
var configuration = builder.Configuration;

// Add DbContext and Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging());

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Lockout.AllowedForNewUsers = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYYZ0123456789-._@ +";
})
//.AddRoleStore<RoleStore<ApplicationRole>>()
//.AddRoleManager<RoleManager<ApplicationRole>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Add Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = false,
    ValidateLifetime = false,
    ValidateIssuerSigningKey = true,
    ValidIssuer = configuration.GetConnectionString("serverDomain"),
    ValidAudience = configuration.GetConnectionString("serverDomain"),
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetConnectionString("Secret_key")?.ToString() ?? string.Empty)),
    ClockSkew = TimeSpan.Zero
});

// Add Authorization
builder.Services.AddAuthorization(options => { });

// Add Controllers
builder.Services.AddControllers();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddNecessaryServices();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(opt =>
//{
//    opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            Array.Empty<string>()
//        }
//    });
//});
builder.Services.AddSwaggerDocument(config =>
{
    config.Title = "Cocineta";
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Cocineta API";
        document.Info.Description = "API Cocineta";
        document.Info.TermsOfService = "None";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "support",
            Email = "",
            //Url = new Uri("https://twitter.com/spboyer"),
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Cocineta",
            //Url = "https://example.com/license"
        };
    };

    // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
    // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
    config.AddSecurity("JWT", Enumerable.Empty<string>(),
        new NSwag.OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Enter the Bearer Authorization string as following: Bearer {Token JWT}."
        }
    );

    config.PostProcess = document => document.Produces = new List<string>
                    {
                        "application/json",
                        "application/xml"
                    };

    config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
//app.UseSwagger();
//app.UseSwaggerUI();
//AÑADIMOS EL MIDDLEWARE DE SWAGGER(NSwag)
//app.UseOpenApi(); // serve documents (same as app.UseSwagger()) para  local
app.UseOpenApi(a =>
{
    a.PostProcess = (document, _) =>
    {
        document.Schemes = new[] { NSwag.OpenApiSchema.Https, NSwag.OpenApiSchema.Http };
    };
});
// serve documents (same as app.UseSwagger())
//app.UseSwaggerUi3();
app.UseSwaggerUi3(options =>
{
    // Define web UI route
    options.Path = "/swagger";
});
// serve Swagger UI
//app.UseReDoc();

app.UseReDoc(options =>
{
    //c.Path = "/redoc";
    options.DocumentPath = "/swagger/v1/swagger.json";
});


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
