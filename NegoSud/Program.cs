using Common.Mapping;
using Microsoft.OpenApi.Models;
using NegoSud.Config;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://locahost:7061");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "enable all",
    policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// Add services to the container.
ConfigDependencies.AddDependencies(builder.Services);
builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);
builder.Services.AddAutoMapper(typeof(ProductMapping).Assembly);
builder.Services.AddAutoMapper(typeof(FournisseurMapping).Assembly);
builder.Services.AddAutoMapper(typeof(FamilyMapping).Assembly);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "NegoSud", Version = "v1" });
    c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Scheme = "Basic",
        Name = "Authorization",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Basic"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

app.UseCors("enable all");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
