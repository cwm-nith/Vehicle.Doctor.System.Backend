using Vehicle.Doctor.System.API.Applications;
using Vehicle.Doctor.System.API.Applications.Configurations;
using Vehicle.Doctor.System.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSetting = new ApplicationSetting();
builder.Configuration.GetSection("AppSetting").Bind(appSetting);
builder.Services.AddSingleton(appSetting);

builder.Services
    .AddApplicationService()
    .AddInfrastructure(appSetting);

var app = builder.Build();

var settings = app.Services.GetService<ApplicationSetting>();
if (settings?.Swagger.IsEnable ?? false) app.UseCustomSwagger();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();
