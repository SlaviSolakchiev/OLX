namespace OLX.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface ICategoriesService
    {
        public List<SelectListItem> GetAll();
    }
}
