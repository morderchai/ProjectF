using WebApplication3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMessageService, MessageService>();
//builder.Services.AddScoped<AppDbContext>();
//builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseNpgsql(Environment.GetEnvironmentVariable("CONN_STRING")));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Seedowanie danych
await UserService.DbSeeder.SeedAsync(app.Services);
await PostService.DbSeeder.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();