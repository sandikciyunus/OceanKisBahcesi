using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface ISliderService
    {
        IList<Slider> GetAll();
        IList<HomeVideo> GetAllHomeVideo();
        HomeVideo GetById(int id);
        Slider GetBySliderId(int id);
        void UpdateVideo(HomeVideo homeVideo);
        void Update(Slider slider);
        void UpdateSlider(Slider slider);
        void UpdateIsActive(Slider slider);
        void AddSlider(Slider slider);
        int CountIsActive();
        void DeleteSlider(Slider slider);
    }
}
