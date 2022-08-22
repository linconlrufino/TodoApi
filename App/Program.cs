using App.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var conectionStringInMemory = builder.Configuration.GetConnectionString("DefaultConnectionInMemory");

builder.Services.AddInMemoryDataBaseConnection(conectionStringInMemory);
builder.Services.AddRepositories();
builder.Services.AddHandlers();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();



//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

