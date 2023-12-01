using AppNetCore01.DataLayer.Repository.Interfaces;
using AppNetCore01.Models;
using AppNetCore01.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppNetCore01.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpSert(int? id)
        {
            var productoVm = new ProductoEditVm
            {
                Producto = new Producto(),
                Marcas = _unitOfWork.Marcas
                    .GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.nombre,
                        Value = c.idMarca.ToString()
                    })
            };

            if (id == null || id == 0)
            {
                return View(productoVm);

            }
            else
            {
                productoVm.Producto = _unitOfWork.Productos.Get(p => p.idProducto == id.Value);
                
				return View(productoVm);

            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductoEditVm productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Marcas = _unitOfWork.Marcas
                    .GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.nombre,
                        Value = c.idMarca.ToString()
                    });

                return View(productoVm);
            }
            
            if (productoVm.Producto.idProducto == 0)
            {
                _unitOfWork.Productos.Add(productoVm.Producto);
				_unitOfWork.Save();
				TempData["success"] = "Producto agregado exitosamente!!";
			}
            else
            {
                _unitOfWork.Productos.Update(productoVm.Producto);
				_unitOfWork.Save();
				TempData["success"] = "Producto editado exitosamente!!";
			}
            
			return RedirectToAction("Index");
        }


        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var productoList = _unitOfWork.Productos.GetAll();
            List<ProductoListVm> productoListVm = new List<ProductoListVm>();
            foreach (var producto in productoList)
            {
                var productoVm = new ProductoListVm()
                {
                    id = producto.idProducto,
                    Descripcion = producto.descripcion,
                    Codigo = producto.codigo.ToString(),
                    Marca = (_unitOfWork.Marcas.Get(c => c.idMarca == producto.idMarca)).nombre
                };
                productoListVm.Add(productoVm);

            }
            return Json(new { data = productoListVm });

        }


        [HttpDelete]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return Json(new { success = false, message = "Not Found" });

			}
			var productDelete = _unitOfWork.Productos.Get(p => p.idProducto == id);
			if (productDelete == null)
			{
				return Json(new { success = false, message = "Producto no encontrado" });
			}
			try
			{
				_unitOfWork.Productos.Delete(productDelete);
				_unitOfWork.Save();
                TempData["success"] = "Registro borrado exitosamente!!";
                return Json(new { success = true, message = "Producto Eliminado exitosamente" });
                
            }
			catch (Exception ex)
			{

				return Json(new { success = false, message = ex.Message });
			}
		}
        #endregion
    }
}
