using Microsoft.EntityFrameworkCore;
using PictureStore.Data;
using PictureStore.Data.DbContexts;
using PictureStore.Data.Interfaces;
using PictureStore.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllInDev",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContext<PicturesContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:PicturesDBConnectionString"]));
builder.Services.AddScoped<IPicturesService, PicturesService>();
builder.Services.AddScoped<IPicturesRepository, PicturesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PictureStore.API.xml"));
});

builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PicturesContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllInDev");
    app.UseDeveloperExceptionPage();
}
app.UseStatusCodePages();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
