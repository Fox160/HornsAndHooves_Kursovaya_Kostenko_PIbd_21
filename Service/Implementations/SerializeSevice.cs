using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Service.Implementations
{
    public class SerializeSevice : ISerializeService
    {
        private DBContext context;

        public SerializeSevice(DBContext context)
        {
            this.context = context;
        }

        public string GetData()
        {
            DataContractJsonSerializer clientJS = new DataContractJsonSerializer(typeof(List<Client>));
            MemoryStream msClient = new MemoryStream();
            clientJS.WriteObject(msClient, context.Clients.ToList());
            msClient.Position = 0;
            StreamReader srClient = new StreamReader(msClient);
            string clientsJSON = srClient.ReadToEnd();
            srClient.Close();
            msClient.Close();

            DataContractJsonSerializer dishJS = new DataContractJsonSerializer(typeof(List<Dish>));
            MemoryStream msDish = new MemoryStream();
            dishJS.WriteObject(msDish, context.Dishes.ToList());
            msDish.Position = 0;
            StreamReader srDish = new StreamReader(msDish);
            string dishesJSON = srDish.ReadToEnd();
            srDish.Close();
            msDish.Close();

            DataContractJsonSerializer dishProductJS = new DataContractJsonSerializer(typeof(List<DishProduct>));
            MemoryStream msDishProduct = new MemoryStream();
            dishProductJS.WriteObject(msDishProduct, context.DishProducts.ToList());
            msDishProduct.Position = 0;
            StreamReader srDishProduct = new StreamReader(msDishProduct);
            string dishProductsJSON = srDishProduct.ReadToEnd();
            srDishProduct.Close();
            msDishProduct.Close();

            DataContractJsonSerializer orderJS = new DataContractJsonSerializer(typeof(List<Order>));
            MemoryStream msOrder = new MemoryStream();
            orderJS.WriteObject(msOrder, context.Orders.ToList());
            msOrder.Position = 0;
            StreamReader srOrder = new StreamReader(msOrder);
            string ordersJSON = srOrder.ReadToEnd();
            srOrder.Close();
            msOrder.Close();

            DataContractJsonSerializer orderDishJS = new DataContractJsonSerializer(typeof(List<OrderDish>));
            MemoryStream msOrderDish = new MemoryStream();
            orderDishJS.WriteObject(msOrderDish, context.OrderDishs.ToList());
            msOrderDish.Position = 0;
            StreamReader srOrderDish = new StreamReader(msOrderDish);
            string orderDishesJSON = srOrderDish.ReadToEnd();
            srOrderDish.Close();
            msOrderDish.Close();

            DataContractJsonSerializer productJS = new DataContractJsonSerializer(typeof(List<Product>));
            MemoryStream msProduct = new MemoryStream();
            productJS.WriteObject(msProduct, context.Products.ToList());
            msProduct.Position = 0;
            StreamReader srProduct = new StreamReader(msProduct);
            string productsJSON = srProduct.ReadToEnd();
            srProduct.Close();
            msProduct.Close();

            DataContractJsonSerializer requestJS = new DataContractJsonSerializer(typeof(List<Request>));
            MemoryStream msRequest = new MemoryStream();
            requestJS.WriteObject(msRequest, context.Requests.ToList());
            msRequest.Position = 0;
            StreamReader srRequest = new StreamReader(msRequest);
            string requestsJSON = srRequest.ReadToEnd();
            srRequest.Close();
            msRequest.Close();

            DataContractJsonSerializer requestProductJS = new DataContractJsonSerializer(typeof(List<RequestProduct>));
            MemoryStream msRequestProduct = new MemoryStream();
            requestProductJS.WriteObject(msRequestProduct, context.RequestProducts.ToList());
            msRequestProduct.Position = 0;
            StreamReader srRequestProduct = new StreamReader(msRequestProduct);
            string requestProductsJSON = srRequestProduct.ReadToEnd();
            srRequestProduct.Close();
            msRequestProduct.Close();

            return
                "{\n" +
                "    \"Clients\": " + clientsJSON + ",\n" +
                "    \"Dishes\": " + dishesJSON + ",\n" +
                "    \"DishProducts\": " + dishProductsJSON + ",\n" +
                "    \"Orders\": " + ordersJSON + ",\n" +
                "    \"OrderDishes\": " + orderDishesJSON + ",\n" +
                "    \"Products\": " + productsJSON + ",\n" +
                "    \"Requests\": " + requestsJSON + ",\n" +
                "    \"RequestProducts\": " + requestProductsJSON + "\n" +
                "}";
        }
    }
}
