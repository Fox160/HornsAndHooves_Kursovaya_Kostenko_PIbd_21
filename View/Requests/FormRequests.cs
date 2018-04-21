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
    public partial class FormRequests : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        public FormRequests(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRequests_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<RequestViewModel> list = service.GetList();
                dataGridViewRequests.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddRequest>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonViewRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormViewRequest>();
                form.Id = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void dataGridViewRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonViewRequest_Click(sender, e);
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSendRequest>();
            form.Id = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells[0].Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                SaveFileDialog sfd = new SaveFileDialog{ Filter = "xls|*.xls|xlsx|*.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        service.SaveRequestToExcelFile(
                            service.GetElement((int)dataGridViewRequests.SelectedRows[0].Cells[0].Value),
                            sfd.FileName
                        );
                        MessageBox.Show("Заявка сохранена в excel-файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveToWord_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "doc|*.doc|docx|*.docx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        service.SaveRequestToWordFile(
                            service.GetElement((int)dataGridViewRequests.SelectedRows[0].Cells[0].Value),
                            sfd.FileName
                        );
                        MessageBox.Show("Заявка сохранена в word-файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
