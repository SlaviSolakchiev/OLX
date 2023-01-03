namespace OLX.Web.Controllers
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OLX.Data.Models;
    using OLX.Services.Data;
    using OLX.Services.Mapping;
    using OLX.Web.ViewModels.Ad;

    public class AdController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAdService adService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdController(
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager,
            IAdService adService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.adService = adService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = this.categoriesService.GetAll();
            var viewModel = new CreateAdInputModel() { Categories = categories };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = this.categoriesService.GetAll();

                var viewModel = new CreateAdInputModel() { Categories = categories };
                return this.View(viewModel);
            }

            var currentUserId = await this.userManager.GetUserAsync(this.User);
            await this.adService.CreateAsync(inputModel, currentUserId.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.Redirect("/Ad/ThankYou");
        }

        [HttpGet]
        public IActionResult ListAll(int id = 1)
        {
            var viewModel = new AdsListViewModel()
            {
                PageNumber = id,
                Ads = this.adService.GetAll<AdsInListViewModel>(id, 12),
            };

            return this.View(viewModel);
        }


        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
