using Service.BindingModels;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRequestService
    {
        List<RequestViewModel> GetList();

        RequestViewModel GetElement(int id);

        void AddElement(RequestBindingModel model);

        void SaveRequestToExcelFile(RequestViewModel model, string filename);

        void SaveRequestToWordFile(RequestViewModel model, string filename);
    }
}
