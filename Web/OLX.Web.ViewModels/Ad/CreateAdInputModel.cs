namespace OLX.Web.ViewModels.Ad
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using OLX.Data.Models;
    using OLX.Services.Mapping;

    public class CreateAdInputModel : IMapTo<Ad>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        // Phone number/Email
        public string ContactData { get; set; }

        public int CategoryId { get; set; }

        public virtual List<SelectListItem> Categories { get; set; }

        public virtual IEnumerable<IFormFile> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
       {
            configuration.CreateMap<IFormFile, Image>()
                .ForMember(d => d.Extension, s => s.MapFrom(x => Path.GetExtension(x.FileName)));
        }
    }
}
