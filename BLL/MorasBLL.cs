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
    class MorasBLL
    {
        public static bool Guardar(Moras moras)
        {
            if (!Existe(moras.MoraId))
                return Insertar(moras);
            else
                return Modificar(moras);
        }
        
        private static bool Insertar(Moras moras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Moras.Add(moras);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
       
        public static bool Modificar(Moras moras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
               
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId={moras.MoraId}");

                foreach (var item in moras.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
               

                contexto.Entry(moras).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var clientes = contexto.Clientes.Find(id);
                if (clientes != null)
                {
                    contexto.Clientes.Remove(clientes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        
        public static Moras Buscar(int id)
        {
            
            //Moras moras = new Moras();
            
            Contexto contexto = new Contexto();
            Moras moras;
            try
            {
                
                moras = contexto.Moras.Include(x => x.Detalle)
                    .Where(x => x.MoraId == id)
                    .SingleOrDefault();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return moras;
        }
       
        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Moras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Moras.Any(d => d.MoraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        
    }
}