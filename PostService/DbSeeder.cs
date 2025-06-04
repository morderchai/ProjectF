using PostService.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PostService
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

            // Dodaj tagi, jeśli nie istnieją
            if (!await context.Tags.AnyAsync())
            {
                var tags = new[]
                {
                    new Tag { Id = Guid.NewGuid(), Name = "dotnet" },
                    new Tag { Id = Guid.NewGuid(), Name = "csharp" },
                    new Tag { Id = Guid.NewGuid(), Name = "threadia" }
                };

                context.Tags.AddRange(tags);
                await context.SaveChangesAsync();
            }

            // Dodaj post, jeśli nie istnieje
            if (!await context.Posts.AnyAsync())
            {
                var user = await context.Users.FirstOrDefaultAsync();
                var tags = await context.Tags.ToListAsync();

                var post = new Post
                {
                    Id = Guid.NewGuid(),
                    Content = "Witaj w Threadia!",
                    CreatedAt = DateTime.UtcNow,
                    AuthorId = user.Id,
                    Tags = tags
                };

                context.Posts.Add(post);
                await context.SaveChangesAsync();
            }
        }
    }

    
}
