﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class ProductImage:IEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
        public int IsSubProduct { get; set; }
    }
}