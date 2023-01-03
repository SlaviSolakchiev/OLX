namespace OLX.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using OLX.Data.Common.Repositories;
    using OLX.Data.Models;
    using OLX.Services.Mapping;
    using OLX.Web.ViewModels.Ad;

    public class AdService : IAdService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        private readonly IDeletableEntityRepository<Ad> adsRepository;
        private readonly IRepository<Image> imageRepository;

        public AdService(IDeletableEntityRepository<Ad> adsRepository, IRepository<Image> imageRepository)
        {
            this.adsRepository = adsRepository;
            this.imageRepository = imageRepository;
        }

        public async Task CreateAsync(CreateAdInputModel inputModel, string currentUserId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}");

            var currentAd = AutoMapperConfig.MapperInstance.Map<Ad>(inputModel);
            currentAd.AddedByUserId = currentUserId;

            foreach (var image in inputModel.Images)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }


                foreach (var dbImage in currentAd.Images)
                {
                    dbImage.AddedByUserId = currentUserId;
                    var physicalPAth = $"{imagePath}/ads/{dbImage.Id}{extension}";

                    using (Stream fileStream = new FileStream(physicalPAth, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }
            }

            await this.adsRepository.AddAsync(currentAd);
            await this.adsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var list = this.adsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip(( page - 1) * 12)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return list;
        }
    }
}
