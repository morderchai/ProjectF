using UserService.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserService
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Upewnij się, że baza danych istnieje
            await context.Database.EnsureCreatedAsync();

            // Dodaj użytkownika, jeśli nie istnieje
            if (!await context.Users.AnyAsync())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Email = "admin@threadia.pl",
                    CreatedAt = DateTime.UtcNow
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
