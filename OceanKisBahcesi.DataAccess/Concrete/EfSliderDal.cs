using Core.DataAccess.Entity_Framework;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfSliderDal : EfEntityRepositoryBase<Slider>, ISliderDal
    {
        private readonly OceanContext _context;
        public EfSliderDal(OceanContext context) : base(context)
        {
            _context = context;
        }

        public void AddSlider(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            var sliders = _context.Sliders.ToList();
            foreach (var item in sliders)
            {
                if (slider.IsActive == 1)
                {
                    if (item.Id != slider.Id)
                    {
                        item.IsActive = 0;
                        _context.Sliders.Update(item);
                        _context.SaveChanges();
                    }
                }

            }
        }

        public int CountIsActive()
        {
            return _context.Sliders.Where(p => p.IsActive == 1).Count();
        }

        public IList<HomeVideo> GetAllHomeVideo()
        {
            return _context.HomeVideos.ToList();
        }

        public HomeVideo GetById(int id)
        {
            return _context.HomeVideos.Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateIsActive(Slider slider)
        {
            var updateSlider = _context.Sliders.Where(p => p.Id == slider.Id).FirstOrDefault();
            updateSlider.IsActive = slider.IsActive;
            _context.Sliders.Update(updateSlider);
            _context.SaveChanges();

            var sliders = _context.Sliders.ToList();
            foreach (var item in sliders)
            {
                if (slider.IsActive == 1)
                {
                    if (item.Id != slider.Id)
                    {
                        item.IsActive = 0;
                        _context.Sliders.Update(item);
                        _context.SaveChanges();
                    }
                }

            }
        }

        public void UpdateSlider(Slider slider)
        {
            var updateSlider = _context.Sliders.Where(p => p.Id == slider.Id).FirstOrDefault();
            updateSlider.IsActive = slider.IsActive;
            updateSlider.Name = slider.Name;
            _context.Sliders.Update(updateSlider);
            _context.SaveChanges();

            var sliders = _context.Sliders.ToList();
            foreach (var item in sliders)
            {
                if (slider.IsActive == 1)
                {
                    if (item.Id != slider.Id)
                    {
                        item.IsActive = 0;
                        _context.Sliders.Update(item);
                        _context.SaveChanges();
                    }
                }

            }
        }

        public void UpdateVideo(HomeVideo homeVideo)
        {
            var updateHomeVideo = _context.HomeVideos.Where(p => p.Id == homeVideo.Id).FirstOrDefault();
            updateHomeVideo.VideoName = homeVideo.VideoName;
            _context.HomeVideos.Update(updateHomeVideo);
            _context.SaveChanges();
        }
    }
}
