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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
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
    }
}
