using System;
using System.Data.SqlClient;
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
    public partial class AccederDatos : Form
    {
        public AccederDatos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int res = Clases.Persona.Insertar(this.txtCedula.Text, this.txtApellido.Text, this.txtNombres.Text, Convert.ToDateTime(this.txtFechaNaci.Text), Convert.ToDouble(this.txtPeso.Text));
            if(res>0)
                MessageBox.Show("Registro exitoso");
            else
                MessageBox.Show("Registro fallido");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
