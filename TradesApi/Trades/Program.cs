using Microsoft.EntityFrameworkCore;
using Trades;
using Trades.DataBase;
using Trades.Interface;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Server=.; Database= estudoDB;Integrated Security=SSPI; ";

// Add services to the container.
builder.Services.AddCors(opt =>
    opt.AddPolicy("CorsPolicy",
    builder => builder.SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials())
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITradesService, TradesService>();
builder.Services.AddScoped<ICounterPartiesService, CounterPartiesService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();