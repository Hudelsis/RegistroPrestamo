using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RegistroPrestamos.DAL;
using RegistroPrestamos.Entidades;

namespace RegistroPrestamos.BLL
{
    class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);

            else
                return Modificar(prestamos);
        }

        private static bool Existe(object prestamosId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Prestamos prestamos)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Prestamos.Add(prestamos);
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

        public static bool Modificar(Prestamos prestamos)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(prestamos).State = EntityState.Modified;
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
                var prestamos = context.Prestamos.Find(id);

                if (prestamos != null)
                {
                    context.Prestamos.Remove(prestamos);
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
        public static Prestamos Buscar(int id)
        {
            Prestamos prestamos;
            Contexto context = new Contexto();


            try
            {
                prestamos = (Prestamos)context.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return prestamos;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Prestamos.Find(id) != null;
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
        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Prestamos.Where(criterio).ToList();
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

