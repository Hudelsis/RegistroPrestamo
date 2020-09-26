using RegistroPrestamos.Entidades;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RegistroPrestamos.DAL;
using System.Text;
using System.Linq.Expressions;

namespace RegistroPrestamos.BLL
{
    class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.Id))
                return Insertar(cliente);

            else
                return Modificar(cliente);
        }

        private static bool Existe(object clienteId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Clientes cliente)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Clientes.Add(cliente);
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;


        }

        public static bool Modificar(Clientes cliente)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(cliente).State = EntityState.Modified;
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;

        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto context = new Contexto();

            try
            {
                var cliente = context.Clientes.Find(id);

                if (cliente != null)
                {
                    context.Clientes.Remove(cliente);
                    paso = context.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return paso;

        }
        public static Clientes Buscar(int id)
        {
            Clientes cliente;
            Contexto context = new Contexto();

            try
            {
                cliente = (Clientes)context.Clientes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return cliente;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Clientes.Find(id) != null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return encontrado;

        }
        
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Clientes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }
            return lista;

        }
    }
}
