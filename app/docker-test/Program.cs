var builder = WebApplication.CreateBuilder(args);
var parentBaseDirectory = Directory.GetParent(AppContext.BaseDirectory).FullName;
var environmentName = builder.Environment.EnvironmentName;

builder.Configuration.SetBasePath(parentBaseDirectory);
builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", true, true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
