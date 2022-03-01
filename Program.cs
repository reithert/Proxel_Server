using Proxel_Server.Hubs;
// var corsPolicy = "Policy1";
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         builder =>
//         {
//             builder.WithOrigins("http://localhost:4200/")
//                 .AllowAnyHeader()
//                 .AllowAnyMethod()
//                 .AllowCredentials();
//         });
// });

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(builder => {
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NodeHub>("/nodehub");
});

app.MapControllers();

app.Run();
