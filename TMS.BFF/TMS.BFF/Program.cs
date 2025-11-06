using TMS.Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTmsServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

    // options.AddPolicy("AllowAngularApp",
    //     policy =>
    //     {
    //         policy
    //             .WithOrigins("http://localhost:4200")
    //             .AllowAnyHeader()
    //             .AllowAnyMethod();
    //     });
});

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

// app.UseCors("AllowAngularApp");
app.UseCors("AllowAll"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
