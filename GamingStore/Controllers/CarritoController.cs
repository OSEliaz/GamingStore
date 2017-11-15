using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingStore.Models;




namespace GamingStore.Controllers
{
    public class CarritoController : Controller
    {

        GamingStoreDBEntities db_context = new GamingStoreDBEntities();
        List<Productos> list = new List<Productos>();

        // GET: Carrito
        [HttpGet]
        public ActionResult VerCarro(int id)
        {

            Productos prod = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            return View(prod);
        }





        #region Metodos de Modificación de Items 


        [HttpPost]
        public JsonResult AddProductoCarro(int id)
        {
            Productos prod = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            Productos prodbd = new Productos(prod);
            ProductosCarro objcarrito = new ProductosCarro();

            if (prod != null)
            {
                if (Session["Usuario"] == null)
                {
                    List<ProductosCarro> Listacarrito = new List<ProductosCarro>();
                    Listacarrito.Add(new ProductosCarro { Id = prod.Id, Nombre = prod.Nombre, Descripcion = prod.Descripcion, Cantidad = objcarrito.Cantidad , Precio = prod.Precio });
                    Session["Usuario"] = Listacarrito;
                }
                else
                {

                    List<ProductosCarro> CarroLogeado = (List<ProductosCarro>)Session["Usuario"];
                    ProductosCarro ExisteProducto = CarroLogeado.Where(x => x.Id == prod.Id).FirstOrDefault();
                    {
                        if (ExisteProducto != null)
                        {
                            ExisteProducto.Cantidad += 1;

                        }
                        else
                        {
                            CarroLogeado.Add(new ProductosCarro { Id = prod.Id, Nombre = prod.Nombre, Descripcion = prod.Descripcion, Cantidad = objcarrito.Cantidad = 1, Precio = prod.Precio });

                        }

                        Session["Usuario"] = CarroLogeado;
                    }
                }
            }

            return Json((List<ProductosCarro>)Session["Usuario"]);
        }



        /*  public void ProductoenCero(int id, int Cantidad)
          {
              if (Listacarrito != null && Cantidad == 0)
              {
                  Listacarrito.RemoveAt(id);
                  return;

              }

              ProductosCarro ReduceCantidad = new ProductosCarro();

              foreach (ProductosCarro prod in Listacarrito)
              {
                  if (prod.Equals(ReduceCantidad))
                  {
                      prod.Cantidad = Cantidad;
                      return;
                  }
              }


          }

          [HttpPost]
          public void EliminardeCarrito(int id)
          {

              ProductosCarro ProductoEliminado = new ProductosCarro();
              Listacarrito.Remove(ProductoEliminado);

          }
          public int GetSubTotal()
          {
              int subtotal = 0;
              foreach (ProductosCarro prod in Listacarrito)
              subtotal += prod.PrecioTotal;
              return subtotal;
          }

      }
      */
        #endregion

    }
}