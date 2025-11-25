using ProyectoPOS_1CA_A.CapaEntidades;
using ProyectoPOS_1CA_A.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A.CapaPresentacion
{
    public partial class FrmCliente : Form
    {
        int clienteId = 0; //almacena el ID del cliente seleccionado para editar o eliminar
        ClienteBLL bll = new ClienteBLL();//crea una instancia de la capa de negocio
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
            Limpiar();
        }
        public void CargarDatos()
        {
            //obtiene los datos desde la BLL - DAL - BD
            dgvCLientes.DataSource = bll.Listar();
        }
        void Limpiar()
        {
            txtNombre.Clear();
            txtDui.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            chkEstado.Checked = true;
            txtBuscar.Clear();
            txtNombre.Focus();

            clienteId = 0;//Resetea el ID del cliente 0 = Nuevo Registro
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente
                {
                    Id = clienteId,//Si es 0 es nuevo registro, si tiene valor es MOdificación
                    Nombre = txtNombre.Text,
                    Dui = txtDui.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Estado = chkEstado.Checked
                };
                //Llamamos al metodo guardar de la BLL(EL DECIDE SI ES INSERT O UPDATE)
                int id = bll.Guardar(c);
                MessageBox.Show("Cliente guardado con exito.","Notificación",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCLientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                clienteId = Convert.ToInt32(dgvCLientes.Rows[e.RowIndex].Cells["Id"].Value);
                txtNombre.Text = dgvCLientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDui.Text = dgvCLientes.Rows[e.RowIndex].Cells["Dui"].Value.ToString();
                txtTelefono.Text = dgvCLientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvCLientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(dgvCLientes.Rows[e.RowIndex].Cells["Estado"].Value);
            };
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(clienteId == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("¿Está seguro de eliminar el cliente seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bll.Eliminar(clienteId);
                CargarDatos();
                Limpiar();
            }
        }
        private void btnCAncelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCLientes.DataSource = bll.Buscar(txtBuscar.Text);
        }
    }
}
