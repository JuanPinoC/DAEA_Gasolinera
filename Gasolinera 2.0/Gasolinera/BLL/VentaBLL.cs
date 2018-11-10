using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    class VentaBLL
    {
        VentaDAL ven = new VentaDAL();

        public List<CVenta> ListarBLL()
        {
            return ven.Listar();
        }

        public CVenta GetBLL(int codigo)
        {
            return ven.Get(codigo);
        }

        public int AgregarBLL(int usuario,
                                int producto,
                                float cantidad,
                                DateTime fecha,
                                int contribuyente,
                                int cliente,
                                string sede,
                                string placa,
                                string observacion)
        {
            CVenta nuevo = new CVenta
            {
                usuario = usuario,
                producto = producto,
                cantidad = cantidad,
                fecha = fecha,
                contribuyente = contribuyente,
                cliente = cliente,
                sede = sede,
                placa = placa,
                observacion = observacion
            };

            return ven.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                int usuario,
                                int producto,
                                float cantidad,
                                DateTime fecha,
                                int contribuyente,
                                int cliente,
                                string sede,
                                string placa,
                                string observacion)
        {
            CVenta editado = new CVenta
            {
                codigo = codigo,
                usuario = usuario,
                producto = producto,
                cantidad = cantidad,
                fecha = fecha,
                contribuyente = contribuyente,
                cliente = cliente,
                sede = sede,
                placa = placa,
                observacion = observacion
            };

            return ven.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return ven.Eliminar(codigo);
        }
    }
}
