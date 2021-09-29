using Core.DataAcces;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Abstract
{
    public interface ISliderDal:IEntityRepository<Slider>
    {
        IList<HomeVideo> GetAllHomeVideo();
        HomeVideo GetById(int id);
        void UpdateVideo(HomeVideo homeVideo);
        void UpdateSlider(Slider slider);
        void AddSlider(Slider slider);
        void UpdateIsActive(Slider slider);
        int CountIsActive();
    }
}
