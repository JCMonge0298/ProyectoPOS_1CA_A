using ProyectoPOS_1CA_A.CapaDatos;
using ProyectoPOS_1CA_A.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOS_1CA_A.CapaNegocio
{
    public class ClienteBLL
    {
        ClienteDAL dal = new ClienteDAL();
        //Crea una instancia de ClienteDAL para acceder a los métodos de datos

        public DataTable Listar()
        {
                       return dal.Listar();
            //Llama al método Listar de ClienteDAL y
            ////devuelve el DataTable resultante
        }
        public int Guardar(Cliente c)
        {
            //VALIDACIONES(van solo aqui)
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");
            //Si el Id es 0, es un nuevo cliente
            if (c.Id == 0)
            {
                return dal.Insertar(c);
            }
            else
            {
                dal.Actualizar(c);
                return c.Id;
            }
        }
        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
        public DataTable Buscar(string nombre)
        {
            return dal.Buscar(nombre);
        }
    }
}
