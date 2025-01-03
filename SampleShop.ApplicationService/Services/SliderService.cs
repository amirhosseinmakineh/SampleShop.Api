using SampleShop.ApplicationService.Contract.Dtos.Slider;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleShop.ApplicationService.Services
{
    public class SliderService : ISliderService
    {
        private readonly IBaseRepository<long, Slider> sliderRepository;

        public SliderService(IBaseRepository<long, Slider> sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }

        public ICollection<SliderDto> GetSliders()
        {
            var sliders = sliderRepository
                .GetAll().Select(x => new SliderDto()
                {
                    ImageName = x.ImageName,
                    CreateObjectDate = x.CreateObjectDat,
                    Id = x.Id,
                    IsDelete = x.IsDelete
                }).ToList();
            return sliders;
        }
    }
}
