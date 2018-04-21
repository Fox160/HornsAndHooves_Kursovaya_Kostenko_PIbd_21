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
    public partial class FormAddProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService service;

        public int Id { set { id = value; } }

        private int? id;


        public FormAddProduct(IProductService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ProductViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxProductName.Text = view.Name;
                        textBoxProductPrice.Text = view.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text))
            {
                MessageBox.Show("Введите название продукта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxProductPrice.Text))
            {
                MessageBox.Show("Введите цену продукта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ProductBindingModel
                        {
                            Id = id.Value,
                            Name = textBoxProductName.Text,
                            Price = Convert.ToInt32(textBoxProductPrice.Text)
                        }
                    );
                }
                else
                {
                    service.AddElement(new ProductBindingModel
                        {
                            Name = textBoxProductName.Text,
                            Price = Convert.ToInt32(textBoxProductPrice.Text)
                        }
                    );
                }
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
