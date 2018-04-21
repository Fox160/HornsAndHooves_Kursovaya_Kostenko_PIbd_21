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
    public partial class FormSendRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private List<RequestProductViewModel> requestProducts;

        public int Id { set { id = value; } }

        private int? id;

        public FormSendRequest(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        requestProducts = view.RequestProducts;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (requestProducts == null)
            {
                requestProducts = new List<RequestProductViewModel>();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
