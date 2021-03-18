using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAllByAPI();

            producto.Productos = result.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {

            ML.Result resultTipos = BL.Tipo.GetAll();

            ML.Producto producto = new ML.Producto();

            producto.Tipo = new ML.Tipo();
            producto.Tipo.Tipos = resultTipos.Objects;

            if (IdProducto == null)
            {

                ViewBag.Titulo = "Agregar producto";
                ViewBag.Accion = "Guardar";

                return View(producto);
            }
            else
            {

                ViewBag.Titulo = "Actualizar producto";
                ViewBag.Accion = "Actualizar";
                producto.IdProducto = IdProducto.Value;

                var result = BL.Producto.GetById(producto.IdProducto);
                producto = (ML.Producto)result.Object;        

                producto.Tipo.Tipos = resultTipos.Objects;

                return View(producto);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if (producto.IdProducto == 0)
            {
                result = BL.Producto.AddByAPI(producto);

                if (result.Correct)
                {
                    ViewBag.Message = "Se agregó correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al agregar.  Error: " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                result = BL.Producto.UpdateByApi(producto);
               
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizó correctamente. ";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al actualizar.  Error: " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }
        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteByAPI(IdProducto);
            if (result.Correct)
            {
                ViewBag.Message = "Eliminado Exitoso!";

            }
            else
            {
                ViewBag.Message = "Ocurrió un error al eliminar. " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult GetAll(ML.Producto producto) 
        {
            ML.Result result = new ML.Result();

            if (producto.Fert == null)
            {
                producto.Fert = "";
            }

            if (producto.Modelo == null)
            {
                producto.Modelo = "";
            }

            result = BL.Producto.ProductoGetBusqueda(producto);

            producto.Productos = result.Objects;

            return View(producto);
        }
    }
}
