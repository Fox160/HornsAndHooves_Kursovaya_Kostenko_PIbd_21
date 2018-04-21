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
    public partial class FormAddRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private BindingList<RequestProductViewModel> requestProducts;

        public FormAddRequest(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormAddRequest_Load(object sender, EventArgs e)
        {
            requestProducts = new BindingList<RequestProductViewModel>();
            dataGridViewRequestProducts.DataSource = requestProducts;
            LoadData();

        }

        private void LoadData()
        {
            double sum = 0;
            foreach (var productRequest in requestProducts)
            {
                sum += productRequest.Count * productRequest.ProductPrice;
            }
            textBoxTotalSum.Text = sum.ToString();
        }

        private void buttonAddProductToRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProductToRequest>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.RequestProduct != null)
                {
                    requestProducts.Add(form.RequestProduct);
                }
                LoadData();
            }
        }

        private void buttonDeleteProductFromRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequestProducts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить продукт из запроса?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = dataGridViewRequestProducts.SelectedRows[0].Cells[0].RowIndex;
                    try
                    {
                        requestProducts.RemoveAt(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonAddRequest_Click(object sender, EventArgs e)
        {
            if (requestProducts == null || requestProducts.Count == 0)
            {
                MessageBox.Show("Выберите продукты для заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<RequestProductBindingModel> requestProductBM = new List<RequestProductBindingModel>();
                for (int i = 0; i < requestProducts.Count; ++i)
                {
                    requestProductBM.Add(new RequestProductBindingModel
                        {
                            Id = requestProducts[i].Id,
                            RequestId = requestProducts[i].RequestId,
                            ProductId = requestProducts[i].ProductId,
                            Count = requestProducts[i].Count
                        }
                    );
                }
                service.AddElement(new RequestBindingModel
                    {
                        Price = Convert.ToInt32(textBoxTotalSum.Text),
                        Date = DateTime.Now,
                        RequestProducts = requestProductBM
                    }
                );
                MessageBox.Show("Добавлена новое заявка", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
