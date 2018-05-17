using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace View
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ISerializeService service;

        public FormMain(ISerializeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonDishes_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishes>();
            form.ShowDialog();
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProducts>();
            form.ShowDialog();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReports>();
            form.ShowDialog();
        }

        private void buttonRequests_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(sfd.FileName);

                    writer.WriteLine(service.GetData());
                    writer.Dispose();

                    MessageBox.Show("Бэкап БД проведен успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
