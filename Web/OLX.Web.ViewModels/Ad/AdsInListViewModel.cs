namespace OLX.Web.ViewModels.Ad
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using OLX.Data.Models;
    using OLX.Services.Mapping;

    public class AdsInListViewModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        // Phone number/Email
        public string ContactData { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, AdsInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                                x.Images.FirstOrDefault().RemoteImageUrl :
                                "/images/ads/" + x.Images.FirstOrDefault().Id + x.Images.FirstOrDefault().Extension));
        }
    }
}
