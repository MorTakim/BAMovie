using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Test
{
    public partial class frmMain : Form
    {

        private readonly IServiceActor _serviceActor;

        public frmMain(IServiceActor serviceActor)
        {
            _serviceActor = serviceActor;
            InitializeComponent();
        }

        public frmMain()
            : this(DependencyContainer.Current.Resolve<IServiceActor>())
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _serviceActor.Insert(new Actor()
            {
                Name = "Yavuz"
            });

            Actor yb = _serviceActor.GetAll().FirstOrDefault(x => x.Name == "Yavuz");

            MessageBox.Show(yb.Name);
        }
    }
}
