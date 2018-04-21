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
    public partial class FormProductToRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService serviceProduct;

        public RequestProductViewModel RequestProduct { set { requestProduct = value; } get { return requestProduct; } }

        private RequestProductViewModel requestProduct;

        public FormProductToRequest(IProductService service)
        {
            InitializeComponent();
            this.serviceProduct = service;
        }

        private void FormProductToRequest_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> listProducts = serviceProduct.GetList();
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = listProducts;
                comboBoxProduct.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество продукта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт для заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ProductViewModel product = serviceProduct.GetElement(Convert.ToInt32(comboBoxProduct.SelectedValue));
                requestProduct = new RequestProductViewModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Count = Convert.ToInt32(textBoxCount.Text)
                };
                MessageBox.Show("Продукт добавлен в заявку", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
