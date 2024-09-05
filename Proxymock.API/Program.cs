using Proxymock.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefaultServices(builder.Configuration);

var app = builder.Build();

app.UseMiddlewares();
app.Run();