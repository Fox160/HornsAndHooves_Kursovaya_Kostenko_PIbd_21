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
    public partial class FormDishes : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDishService service;

        public FormDishes(IDishService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormDishes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<DishViewModel> list = service.GetList();
                dataGridViewDishes.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddDish_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddDish>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChangeDish_Click(object sender, EventArgs e)
        {
            if (dataGridViewDishes.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddDish>();
                form.Id = Convert.ToInt32(dataGridViewDishes.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDeleteDish_Click(object sender, EventArgs e)
        {
            if (dataGridViewDishes.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить блюдо?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewDishes.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
