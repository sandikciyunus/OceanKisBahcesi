using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class SliderService : ISliderService
    {
        private ISliderDal _sliderDal;
        public SliderService(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void AddSlider(Slider slider)
        {
            _sliderDal.AddSlider(slider);
        }

        public int CountIsActive()
        {
            return _sliderDal.CountIsActive();
        }

        public void DeleteSlider(Slider slider)
        {
            _sliderDal.Delete(slider);
        }

        public IList<Slider> GetAll()
        {
            return _sliderDal.GetList();
        }

        public IList<HomeVideo> GetAllHomeVideo()
        {
            return _sliderDal.GetAllHomeVideo();
        }

        public HomeVideo GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public Slider GetBySliderId(int id)
        {
            return _sliderDal.Get(p => p.Id == id);
        }

        public void Update(Slider slider)
        {
            _sliderDal.Update(slider);
        }

        public void UpdateIsActive(Slider slider)
        {
            _sliderDal.UpdateIsActive(slider);
        }

        public void UpdateSlider(Slider slider)
        {
            _sliderDal.UpdateSlider(slider);
        }

        public void UpdateVideo(HomeVideo homeVideo)
        {
            _sliderDal.UpdateVideo(homeVideo);
        }
    }
}
