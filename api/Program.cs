var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseCors(b => b
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.Run();
