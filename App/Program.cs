using App.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var conectionStringInMemory = builder.Configuration.GetConnectionString("DefaultConnectionInMemory");

builder.Services.AddInMemoryDataBaseConnection(conectionStringInMemory);
builder.Services.AddRepositories();

var app = builder.Build();

app.Run();



//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();