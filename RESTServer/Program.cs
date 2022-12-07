

using EFCDataBase;
using EFCDataBase.DAOImpl;
using Microsoft.OpenApi.Models;
using Services.Implementations;
using Services.Interfaces;
using WebApplication1.Background;
using WebApplication1.Middleware;
using WebSocket.Clients;
using WebSocket.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/// add new comment

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
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

//? WS-Client
//WS-client
builder.Services.AddScoped<IWebClient, RecordClient>();
builder.Services.AddHostedService<WebClientBackgroundService>();

//!services login
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IBoxService,BoxService>();
//!db 
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IRecordDAO,RecordDAO>();
builder.Services.AddScoped<IBoxDao,BoxDao>();

builder.Services.AddDbContext<DBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();
//?
app.MapControllers();

app.Run();