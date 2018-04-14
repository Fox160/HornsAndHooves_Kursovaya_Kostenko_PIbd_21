using Models;
using Service.BindingModels;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductService : IProductService
    {
        private DBContext context;

        public ProductService(DBContext context)
        {
            this.context = context;
        }

        public List<ProductViewModel> GetList()
        {
            return context.Products
                .Select(rec => new ProductViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Price = rec.Price
                }
            )
            .ToList();
        }

        public ProductViewModel GetElement(int id)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (product != null)
            {
                return new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
            }
            throw new Exception("Продукт не найден");
        }

        public void AddElement(ProductBindingModel model)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Name == model.Name);
            if (product != null)
            {
                throw new Exception("Уже есть продукт с таким названием");
            }
            context.Products.Add(
                new Product
                {
                    Name = model.Name,
                    Price = model.Price
                }
            );
            context.SaveChanges();
        }

        public void UpdElement(ProductBindingModel model)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
            if (product != null)
            {
                throw new Exception("Уже есть продукт с таким названием");
            }
            product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (product == null)
            {
                throw new Exception("Продукт не найден");
            }
            product.Name = model.Name;
            product.Price = model.Price;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Продукт не найден");
            }
        }
    }
}
