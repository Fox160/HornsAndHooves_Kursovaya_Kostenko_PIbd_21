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
    public partial class FormAddDish : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDishService service;

        public int Id { set { id = value; } }

        private int? id;

        private List<DishProductViewModel> dishProducts;

        public FormAddDish(IDishService dishService)
        {
            InitializeComponent();
            this.service = dishService;
        }

        private void FormAddDish_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DishViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxDishName.Text = view.Name;
                        textBoxDishPrice.Text = view.Price.ToString();
                        textBoxDescription.Text = view.Description;
                        dishProducts = view.DishProducts;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (dishProducts == null)
            {
                dishProducts = new List<DishProductViewModel>();
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = dishProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.DishProduct != null)
                {
                    if (id.HasValue)
                    {
                        form.DishProduct.DishId = id.Value;
                    }
                    dishProducts.Add(form.DishProduct);
                }
                LoadData();
            }
        }

        private void buttonChangeProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDishProduct>();
                int id = dataGridViewProducts.SelectedRows[0].Cells[0].RowIndex;
                form.DishProduct = dishProducts[id];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dishProducts[id] = form.DishProduct;
                    LoadData();
                }
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = dataGridViewProducts.SelectedRows[0].Cells[0].RowIndex;
                    try
                    {
                        dishProducts.RemoveAt(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonSaveDish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDishName.Text))
            {
                MessageBox.Show("Введите название блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDishPrice.Text))
            {
                MessageBox.Show("Введите цену блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Введите описание блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dishProducts == null || dishProducts.Count == 0)
            {
                MessageBox.Show("Выберите продукты для блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<DishProductBindingModel> dishProductBM = new List<DishProductBindingModel>();
                for (int i = 0; i < dishProducts.Count; ++i)
                {
                    dishProductBM.Add(new DishProductBindingModel
                        {
                            Id = dishProducts[i].Id,
                            DishId = dishProducts[i].DishId,
                            ProductId = dishProducts[i].ProductId,
                            Count = dishProducts[i].Count
                        }
                    );
                }
                if (id.HasValue)
                {
                    service.UpdElement(new DishBindingModel
                        {
                            Id = id.Value,
                            Name = textBoxDishName.Text,
                            Price = Convert.ToInt32(textBoxDishPrice.Text),
                            Description = textBoxDescription.Text,
                            DishProducts = dishProductBM
                        }
                    );
                }
                else
                {
                    service.AddElement(new DishBindingModel
                        {
                            Name = textBoxDishName.Text,
                            Price = Convert.ToInt32(textBoxDishPrice.Text),
                            Description = textBoxDescription.Text,
                            DishProducts = dishProductBM
                        }
                    );
                }
                MessageBox.Show("Добавлено новое блюдо", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
