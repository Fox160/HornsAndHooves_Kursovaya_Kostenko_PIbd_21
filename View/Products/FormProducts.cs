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
    public partial class FormProducts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService service;

        public FormProducts(IProductService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<ProductViewModel> list = service.GetList();
                dataGridViewProducts.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Добавлен новый продукт", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void buttonChangeProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddProduct>();
                form.Id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Продукт изменен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить продукт?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelElement(id);
                        MessageBox.Show("Продукт удален", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
