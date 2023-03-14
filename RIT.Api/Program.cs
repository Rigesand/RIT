using Microsoft.EntityFrameworkCore;
using RIT.Api;
using RIT.Api.Middlewares;
using RIT.Api.Services;
using RIT.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgresql"));
});

builder.Services.AddScoped<DrillBlockPointService>();
builder.Services.AddScoped<HoleService>();
builder.Services.AddScoped<DrillBlockService>();
builder.Services.AddScoped<HolePointService>();

var app = builder.Build();

using (var serviceScope = ((IApplicationBuilder) app).ApplicationServices
       .GetService<IServiceScopeFactory>()?.CreateScope())
{
    if (serviceScope != null)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseValidationException();
app.MapControllers();

app.Run();