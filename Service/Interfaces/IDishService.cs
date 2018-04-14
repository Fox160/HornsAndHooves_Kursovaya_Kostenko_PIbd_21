using Service.BindingModels;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDishService
    {
        List<DishViewModel> GetList();

        DishViewModel GetElement(int id);

        void AddElement(DishBindingModel model);

        void UpdElement(DishBindingModel model);

        void DelElement(int id);
    }
}
