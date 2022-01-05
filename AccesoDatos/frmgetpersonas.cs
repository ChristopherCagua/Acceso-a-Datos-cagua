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
    public partial class frmgetpersonas : Form
    {
        public frmgetpersonas()
        {
            InitializeComponent();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            this.CargarPersonas();

        }
        private void CargarPersonas()
        {
            this.dgPersonas.DataSource = Clases.Persona.getpersona();
        }
        private void dgPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgPersonas.Columns[e.ColumnIndex].Name == "LinkSeleccionar")
                {
                    //MessageBox.Show("click en seleccionar");
                    string cedula = this.dgPersonas["Cédulas", e.RowIndex].Value.ToString();
                    frmConsultaPersona frm1 = new frmConsultaPersona(cedula);
                    frm1.ShowDialog();
                }
                else if (this.dgPersonas.Columns[e.ColumnIndex].Name == "LinkEliminar")
                {
                    //MessageBox.Show("click en Eliminar");
                    if (MessageBox.Show("¿ESTAS SEGURO QUE DESEAS ELIMINAR?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string cedula = this.dgPersonas["Cédulas", e.RowIndex].Value.ToString();
                        int respuesta= Clases.Persona.Borrar(cedula);
                        if (respuesta > 0)
                        {
                            MessageBox.Show("PERSONA ELIMINADA CON EXITO", "ELIMINO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.CargarPersonas();
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO SE ELIMINO NINGUN DATO", "CANCELACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
        }
    }
}
