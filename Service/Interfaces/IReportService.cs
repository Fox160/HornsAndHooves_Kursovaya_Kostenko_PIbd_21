using Service.BindingModels;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReportService
    {
        List<OrderViewModel> GetOrdersList(ReportBindingModel model);

        List<RequestViewModel> GetRequestsList(ReportBindingModel model);

        void SaveReportToFile(ReportBindingModel model);
    }
}
