using ML;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Data;
using System.Configuration;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {

                    var ProductoGet = context.ProductoGet();

                    result.Objects = new List<object>();

                    if (ProductoGet != null)
                    {
                        foreach (var Obj in ProductoGet)
                        {

                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = Obj.IdProducto;
                            producto.Fert = Obj.Fert;
                            producto.Modelo = Obj.Modelo;
                            producto.Tipo = new ML.Tipo();
                            producto.Tipo.Nombre = Obj.Nombre;
                            producto.NumeroDeSerie = Obj.NumeroDeSerie;
                            producto.Fecha = Obj.Fecha.Value;

                            result.Objects.Add(producto);

                        }

                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = "No existen coincidencias con los parámetros ingresados.";

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Add(ML.Producto producto)
        {

            ML.Result result = new ML.Result();

            try
            {

                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {

                    var ProductoAdd = context.ProductoAdd(producto.Fert, producto.Modelo, producto.Tipo.IdTipo, producto.NumeroDeSerie, DateTime.Now);

                    if (ProductoAdd >= 1)
                    {

                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";

                    }

                    result.Correct = true;

                }

                return result;

            }

            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {

                    var ProductoGetById = context.ProductoGetById(IdProducto).FirstOrDefault();

                    if (ProductoGetById != null)
                    {

                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = IdProducto;
                        producto.Fert = ProductoGetById.Fert;
                        producto.Modelo = ProductoGetById.Modelo;
                        producto.Tipo = new ML.Tipo();
                        producto.Tipo.IdTipo = ProductoGetById.IdTipo;
                        producto.Tipo.Nombre = ProductoGetById.Nombre;
                        producto.NumeroDeSerie = ProductoGetById.NumeroDeSerie;
                        producto.Fecha = ProductoGetById.Fecha.Value;

                        result.Object = producto;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public static Result Update(ML.Producto producto)
        {

            Result result = new Result();

            try
            {

                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {
                    var ProductoUpdate = context.ProductoUpdate(producto.IdProducto, producto.Fert, producto.Modelo, producto.Tipo.IdTipo, producto.NumeroDeSerie, DateTime.Now);

                    if (ProductoUpdate >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static Result Delete(int IdProducto)
        {

            Result result = new Result();

            try
            {
                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {

                    var query = context.ProductoDelete(IdProducto);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result ProductoGetBusqueda(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MLegariaItalikaEntities1 context = new DL.MLegariaItalikaEntities1())
                {

                    var query = context.ProductoGetBusqueda(producto.Fert, producto.Modelo).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var Obj in query)
                        {
                            ML.Producto item = new ML.Producto();

                            item.IdProducto = Obj.IdProducto;
                            item.Fert = Obj.Fert;
                            item.Modelo = Obj.Modelo;
                            item.Tipo = new ML.Tipo();
                            item.Tipo.Nombre = Obj.Nombre;
                            item.NumeroDeSerie = Obj.NumeroDeSerie;
                            item.Fecha = Obj.Fecha.Value;

                            result.Objects.Add(item);

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        //Mostrar registros
        public static ML.Result GetAllByAPI()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                   string URL= ConfigurationManager.AppSettings["URL_API"];
                    client.BaseAddress = new Uri(URL);        

                    var responseTask = client.GetAsync("Producto/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        result.Objects = new List<object>();
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //Agregar 
        public static ML.Result AddByAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var client = new HttpClient())
                {
                    string URL = ConfigurationManager.AppSettings["URL_API"];

                    client.BaseAddress = new Uri(URL); 

                    var postTask = client.PostAsJsonAsync<ML.Producto>("Producto/Add", producto);
                    postTask.Wait();

                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //Actualizar
        public static ML.Result UpdateByApi(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    string URL = ConfigurationManager.AppSettings["URL_API"];

                    client.BaseAddress = new Uri(URL); 

                    var putTask = client.PutAsJsonAsync<ML.Producto>("Producto/Update", producto);               
                    putTask.Wait();

                    var resultAPI = putTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }
        //Eliminar 
        public static ML.Result DeleteByAPI(int IdProducto)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    string URL = ConfigurationManager.AppSettings["URL_API"];

                    client.BaseAddress = new Uri(URL); 
                    
                
                    var deleteTask = client.DeleteAsync("Producto/Delete/" + IdProducto);

                    deleteTask.Wait();

                    var resultAPI = deleteTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

    }
}
