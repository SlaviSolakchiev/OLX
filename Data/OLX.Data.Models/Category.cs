namespace OLX.Data.Models
{
    using System.Collections.Generic;

    using OLX.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }

        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; }

    }
}
