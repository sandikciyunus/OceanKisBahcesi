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
        public IList<Slider> GetAll()
        {
            return _sliderDal.GetList();
        }
    }
}
