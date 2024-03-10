using Dependencies;
using MinimalApiEndpoints;
using RegisterServices;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AppServices();


}
var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    app.UseEndpoints();

    app.Run();
}
