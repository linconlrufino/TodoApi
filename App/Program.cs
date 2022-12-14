using App.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);

//var conectionStringInMemory = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddInMemoryDataBaseConnection(conectionStringInMemory);

var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlConnection(conectionString);
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddAuthenticationJwt();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(option =>
    {
        //option.Providers.Add<BrotliCOmpressionProvider>();
        option.Providers.Add<GzipCompressionProvider>();
        //option.Providers.Add<CustomCompressionprovider>();
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(option =>
    {
        option.Level = CompressionLevel.Optimal;
    });
    builder
        .Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
}