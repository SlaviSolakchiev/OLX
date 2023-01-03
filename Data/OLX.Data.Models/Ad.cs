namespace OLX.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using OLX.Data.Common.Models;
    using OLX.Services.Mapping;

    public class Ad : BaseDeletableModel<string>, IMapTo<Image>
    {
        public Ad()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        // Phone number/Email
        public string ContactData { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}
