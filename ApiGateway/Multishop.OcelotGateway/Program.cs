using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{

    opt.Authority = builder.Configuration["IdentityServerUrl"]; //kiminle beraber kullanacaðýz
    opt.Audience = ""; //dinleyici olan 
    opt.RequireHttpsMetadata = false;
});



IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
