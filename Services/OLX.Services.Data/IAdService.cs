namespace OLX.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OLX.Data.Models;
    using OLX.Web.ViewModels.Ad;

    public interface IAdService
    {
        public Task CreateAsync(CreateAdInputModel inputModel, string id, string imagePath);

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);
    }
}
