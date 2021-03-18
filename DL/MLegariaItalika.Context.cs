﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MLegariaItalikaEntities1 : DbContext
    {
        public MLegariaItalikaEntities1()
            : base("name=MLegariaItalikaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
    
        public virtual ObjectResult<GetByTipo_Result> GetByTipo(Nullable<int> idTipo)
        {
            var idTipoParameter = idTipo.HasValue ?
                new ObjectParameter("IdTipo", idTipo) :
                new ObjectParameter("IdTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByTipo_Result>("GetByTipo", idTipoParameter);
        }
    
        public virtual int ProductoDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", idProductoParameter);
        }
    
        public virtual ObjectResult<ProductoGet_Result> ProductoGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGet_Result>("ProductoGet");
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual ObjectResult<ProductoGetByModelo_Result> ProductoGetByModelo(string modelo)
        {
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetByModelo_Result>("ProductoGetByModelo", modeloParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string fert, string modelo, Nullable<int> tipo, string numeroDeSerie, Nullable<System.DateTime> fecha)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var numeroDeSerieParameter = numeroDeSerie != null ?
                new ObjectParameter("NumeroDeSerie", numeroDeSerie) :
                new ObjectParameter("NumeroDeSerie", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, fertParameter, modeloParameter, tipoParameter, numeroDeSerieParameter, fechaParameter);
        }
    
        public virtual ObjectResult<TipoGet_Result> TipoGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoGet_Result>("TipoGet");
        }
    
        public virtual int ProductoAdd(string fert, string modelo, Nullable<int> tipo, string numeroDeSerie, Nullable<System.DateTime> fecha)
        {
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(int));
    
            var numeroDeSerieParameter = numeroDeSerie != null ?
                new ObjectParameter("NumeroDeSerie", numeroDeSerie) :
                new ObjectParameter("NumeroDeSerie", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", fertParameter, modeloParameter, tipoParameter, numeroDeSerieParameter, fechaParameter);
        }
    
        public virtual ObjectResult<ProductoGetBusqueda_Result> ProductoGetBusqueda(string fert, string modelo)
        {
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetBusqueda_Result>("ProductoGetBusqueda", fertParameter, modeloParameter);
        }
    }
}
