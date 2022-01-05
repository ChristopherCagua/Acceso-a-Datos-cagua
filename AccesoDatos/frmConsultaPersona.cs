using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public partial class frmConsultaPersona : Form
    {
        private string ncedula;
        public frmConsultaPersona(string cedula)
        {
            InitializeComponent();
            this.ncedula = cedula;
        }

        private void frmConsultaPersona_Load(object sender, EventArgs e)
        {
            MessageBox.Show("La cédula es: " + ncedula);
        }
    }
}
