namespace OLX.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using OLX.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Автомобили, каравани, лодки" });
            await dbContext.Categories.AddAsync(new Category { Name = "Недвижими имоти" });
            await dbContext.Categories.AddAsync(new Category { Name = "Електроника" });
            await dbContext.Categories.AddAsync(new Category { Name = "Спорт" });
            await dbContext.Categories.AddAsync(new Category { Name = "Животни" });
            await dbContext.Categories.AddAsync(new Category { Name = "Мода" });
            await dbContext.Categories.AddAsync(new Category { Name = "Работа" });
            await dbContext.Categories.AddAsync(new Category { Name = "Дом и градина" });
            await dbContext.Categories.AddAsync(new Category { Name = "Книги" });

            await dbContext.SaveChangesAsync();
        }
    }
}
