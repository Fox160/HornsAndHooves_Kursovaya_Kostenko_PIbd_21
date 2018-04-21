using Service.BindingModels;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace View
{
    public partial class FormViewRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private BindingList<RequestProductViewModel> requestProducts;

        public int Id { set { id = value; } }

        private int? id;

        public FormViewRequest(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        requestProducts = new BindingList<RequestProductViewModel>(view.RequestProducts);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (requestProducts == null)
            {
                requestProducts = new BindingList<RequestProductViewModel>();
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewRequests.DataSource = requestProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            double sum = 0;
            foreach (var productRequest in requestProducts)
            {
                sum += productRequest.Count * productRequest.ProductPrice;
            }
            textBoxTotalSum.Text = sum.ToString();
        }
    }
}
