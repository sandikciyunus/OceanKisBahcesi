using Core.DataAccess.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfFeatureDal:EfEntityRepositoryBase<Feature>,IFeatureDal
    {
        private readonly OceanContext _context;
        public EfFeatureDal(OceanContext context) : base(context)
        {
            _context = context;
        }

        public IList<Feature> GetAll()
        {
            return _context.Features.Include(p => p.Language).ToList();
        }

        public void UpdateFeatureImage(Feature feature)
        {
            var updateFeature = _context.Features.Where(p => p.Id == feature.Id).FirstOrDefault();
            updateFeature.Image = feature.Image;
            updateFeature.Name = feature.Name;
            updateFeature.LanguageId = feature.LanguageId;
            updateFeature.Sort = feature.Sort;
            _context.Features.Update(updateFeature);
            _context.SaveChanges();
        }

        public void UpdateFeatureName(Feature feature)
        {
            var updateFeature = _context.Features.Where(p => p.Id == feature.Id).FirstOrDefault();
            updateFeature.Name = feature.Name;
            updateFeature.LanguageId = feature.LanguageId;
            updateFeature.Sort = feature.Sort;
            _context.Features.Update(updateFeature);
            _context.SaveChanges();
        }
    }
}
