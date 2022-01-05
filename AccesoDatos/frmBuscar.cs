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
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            DataTable dt = getpersona();
            this.comboPersona.DataSource = dt;
            this.comboPersona.DisplayMember = "nombreCompleto";
            this.comboPersona.ValueMember = "cedula";

        }
        private DataTable getpersona(string cedula="")
        {
            string sql = "";
            SqlConnection conexion = new SqlConnection(@"server=MAQUINA-DE-GUER\SQLEXPRESS; database=TI2021; Integrated Security=true");
            if (cedula == "")
            {
                sql = "select cedula, apellidos, nombres, upper(apellidos+ ' ' + nombres) as nombreCompleto, fechaNacimiento, peso ";
                sql += "from Personas order by apellidos, nombres";
            }
            else
            {
                sql = "select cedula, apellidos, nombres, upper(apellidos+ ' ' + nombres) as nombreCompleto, fechaNacimiento, peso ";
                sql += "from Personas where cedula=@cedula order by apellidos, nombres";
            }

            SqlCommand comando = new SqlCommand(sql, conexion);
            if (cedula != "")
            {
                comando.Parameters.Add(new SqlParameter("@cedula", cedula));
            }
            SqlDataAdapter ad1 = new SqlDataAdapter(comando);

            //pasar los datos del adaptador a un datatable
            DataTable dt = new DataTable();
            ad1.Fill(dt);
            return dt;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable dt = getpersona(this.comboPersona.SelectedValue.ToString());
            //mostrar la informacion
            foreach(DataRow row in dt.Rows)
            {
                this.txtCedula.Text = row["cedula"].ToString();
                this.txtNombres.Text = row["nombres"].ToString();
                this.txtApellido.Text = row["apellidos"].ToString();
                this.datoTiempo.Value = Convert.ToDateTime(row["fechaNacimiento"].ToString());
                this.txtPeso.Text = row["peso"].ToString();

            }
        }
    }
}
