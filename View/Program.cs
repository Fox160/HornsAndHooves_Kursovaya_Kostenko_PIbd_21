using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Service;
using Service.Interfaces;
using Service.Implementations;
using Unity;
using Unity.Lifetime;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, DBContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDishService, DishService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRequestService, RequestService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportService>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
