using ProyectoPOS_1CA_A.CapaEntidades;
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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        //Creacion de una lista estatica que simulara la DB
        public static List<Producto> listaProductos = new List<Producto>();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            //Cargar los datos iniciales
            if (!listaProductos.Any())
            {// cada vez que se cargue el formulario, si la lista esta vacia,
             // se agregan los productos iniciales
                listaProductos.Add(new Producto
                {
                    Id = 1,
                    Nombre = "Café Gourmet",
                    Descripcion = "Importado",
                    Precio = 10.5m,
                    Stock = 100,
                    Estado = true
                });
                listaProductos.Add(new Producto
                {
                    Id = 2,
                    Nombre = "Café Borbon",
                    Descripcion = "De altura",
                    Precio = 20.0m,
                    Stock = 50,
                    Estado = true
                });
                listaProductos.Add(new Producto
                {
                    Id = 3,
                    Nombre = "Cheescake",
                    Descripcion = "Dulce sabor",
                    Precio = 15.75m,
                    Stock = 75,
                    Estado = true
                });
            }
            RefrescarGrid();//mando a llamar el metodo para refrescar el datagridview
        }
        //asignar la lista como DataSOurce al datagridview
        private void RefrescarGrid()
        {
            dgvProductos.DataSource = null; // Limpiar el DataSource antes de reasignarlo
            dgvProductos.DataSource = listaProductos; // Asignar la lista como DataSource
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Validaciones basicas
            //valida que el nombre no este vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text)){
                MessageBox.Show("El nombre del producto es obligatorio.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }//valida que el precio ingresado sea un decimal
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El precio del producto debe ser un valor numérico.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }//valida que el stock ingresado sea un entero
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("el stock del producto debe ser un valor entero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }
        }
    }
}
