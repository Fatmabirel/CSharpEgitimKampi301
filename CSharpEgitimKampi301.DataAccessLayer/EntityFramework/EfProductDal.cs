using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategory()
        {
            using (var context = new CampContext())
            {
                var values = context.Products
                    .Select(x => new
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        ProductStock = x.ProductStock,
                        ProductDescription = x.ProductDescription,
                        ProductPrice = x.ProductPrice,
                        CategoryName = x.Category.CategoryName
                    }).ToList();
                return values.Cast<object>().ToList();
            }
        }
    }
}
