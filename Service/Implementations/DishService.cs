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
    public class DishService : IDishService
    {
        private DBContext context;

        public DishService(DBContext context)
        {
            this.context = context;
        }

        public List<DishViewModel> GetList()
        {
            return context.Dishes.Select(
                rec => new DishViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Price = rec.Price,
                    Description = rec.Description,
                    DishProducts = context.DishProducts
                        .Where(recPC => recPC.DishId == rec.Id)
                        .Select(
                            recPC => new DishProductViewModel
                            {
                                Id = recPC.Id,
                                DishId = recPC.DishId,
                                ProductId = recPC.ProductId,
                                ProductName = recPC.Product.Name,
                                Count = recPC.Count
                            }
                        )
                        .ToList()
                }
            )
            .ToList();
        }

        public DishViewModel GetElement(int id)
        {
            Dish dish = context.Dishes.FirstOrDefault(rec => rec.Id == id);
            if (dish != null)
            {
                return new DishViewModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Price = dish.Price,
                    Description = dish.Description,
                    DishProducts = context.DishProducts
                        .Where(recDP => recDP.DishId == dish.Id)
                        .Select(
                            recPC => new DishProductViewModel
                            {
                                Id = recPC.Id,
                                DishId = recPC.DishId,
                                ProductId = recPC.ProductId,
                                ProductName = recPC.Product.Name,
                                Count = recPC.Count
                            }
                        )
                        .ToList()
                };
            }
            throw new Exception("Блюдо не найдено");
        }

        public void AddElement(DishBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Dish dish = context.Dishes.FirstOrDefault(rec => rec.Name == model.Name);
                    if (dish != null)
                        throw new Exception("Такое блюдо существует");
                    dish = new Dish
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price
                    };
                    context.Dishes.Add(dish);
                    context.SaveChanges();

                    var groupProducts = model.DishProducts
                        .GroupBy(rec => rec.ProductId)
                        .Select(rec => new
                            {
                                ProductId = rec.Key,
                                Count = rec.Sum(r => r.Count)
                            }
                        );
                    foreach (var groupProduct in groupProducts)
                    {
                        context.DishProducts.Add(
                            new DishProduct
                            {
                                DishId = dish.Id,
                                ProductId = groupProduct.ProductId,
                                Count = groupProduct.Count
                            }
                        );
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(DishBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Dish dish = context.Dishes.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                    if (dish != null)
                        throw new Exception("Такое блюдо существует");

                    dish = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
                    if (dish == null)
                        throw new Exception("Блюдо не найдено");

                    dish.Name = model.Name;
                    dish.Price = model.Price;
                    dish.Description = model.Description;
                    context.SaveChanges();

                    var compIds = model.DishProducts.Select(rec => rec.ProductId).Distinct();
                    var updateProducts = context.DishProducts.Where(rec => rec.DishId == model.Id && compIds.Contains(rec.ProductId));
                    foreach (var updateProduct in updateProducts)
                    {
                        updateProduct.Count = model.DishProducts.FirstOrDefault(rec => rec.Id == updateProduct.Id).Count;
                    }
                    context.SaveChanges();
                    context.DishProducts.RemoveRange(context.DishProducts.Where(rec => rec.DishId == model.Id && !compIds.Contains(rec.ProductId)));
                    context.SaveChanges();

                    var groupProducts = model.DishProducts
                        .Where(rec => rec.Id == 0)
                        .GroupBy(rec => rec.ProductId)
                        .Select(rec => new
                            {
                                ProductId = rec.Key,
                                Count = rec.Sum(r => r.Count)
                            }
                        );

                    foreach (var groupProduct in groupProducts)
                    {
                        DishProduct dishProduct = context.DishProducts.FirstOrDefault(rec => rec.DishId == model.Id && rec.ProductId == groupProduct.ProductId);
                        if (dishProduct != null)
                        {
                            dishProduct.Count += groupProduct.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.DishProducts.Add(
                                new DishProduct
                                {
                                    DishId = model.Id,
                                    ProductId = groupProduct.ProductId,
                                    Count = groupProduct.Count
                                }
                            );
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Dish dish = context.Dishes.FirstOrDefault(rec => rec.Id == id);
                    if (dish != null)
                    {
                        context.DishProducts.RemoveRange(context.DishProducts.Where(rec => rec.DishId == id));
                        context.Dishes.Remove(dish);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Блюдо не найдено");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
