namespace OLX.Data.Models
{
    using System;
    using OLX.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}