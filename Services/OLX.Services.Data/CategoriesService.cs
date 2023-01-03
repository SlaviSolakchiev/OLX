namespace OLX.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using OLX.Data.Common.Repositories;
    using OLX.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<SelectListItem> GetAll()
        {
            return this.categoriesRepository.All().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
        }
    }
}
