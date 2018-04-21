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
    public partial class FormDishProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService serviceProduct;

        public DishProductViewModel DishProduct { set { dishProduct = value; } get { return dishProduct; } }

        private DishProductViewModel dishProduct;

        public FormDishProduct(IProductService service)
        {
            InitializeComponent();
            this.serviceProduct = service;
        }

        private void FormDishProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> list = serviceProduct.GetList();
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dishProduct != null)
            {
                comboBoxProduct.Enabled = false;
                comboBoxProduct.SelectedValue = dishProduct.ProductId;
                textBoxCount.Text = dishProduct.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Укажите количество продукта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт для блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (dishProduct == null)
                {
                    dishProduct = new DishProductViewModel
                    {
                        ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                        ProductName = comboBoxProduct.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    dishProduct.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Добавлен продукт для блюда", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
