﻿using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CSharpEgitimKampi301.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Object> TGetProductsWithCategory();
    }
}
