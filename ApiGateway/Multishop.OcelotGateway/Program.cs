var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelo.jsont").Build();

app.MapGet("/", () => "Hello World!");

app.Run();
