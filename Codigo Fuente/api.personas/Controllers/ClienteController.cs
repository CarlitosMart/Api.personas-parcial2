using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services.Logica;

namespace api.Clientes.Controllers
{
    //[ApiController]
    //[Route("/Api/v1/")]
    public class ClienteController : Controller
    {
        private ClienteService ClienteService;
        public ClienteController(IConfiguration configuracion)
        {
            ClienteService = new ClienteService(configuracion.GetConnectionString("postgres"));
        }
        
        [HttpGet("ListC")]
        public async Task<ActionResult<List<ClienteModel>>> List()
        {
            var a=ClienteService.list();
            return ClienteService.list();
        }


        // GET: ClienteController/Create
        [HttpPost("AddC")]
        public ActionResult Add(Repository.Data.ClienteModel Cliente)
        {
            ClienteService.add(Cliente);
            return Ok(new { message = $"El Cliente con nombre {Cliente.Nombre} fue insertado correctamente!!!"});
        }
        [HttpPost("EditC")]
        public ActionResult Edit(Repository.Data.ClienteModel Cliente)
        {
            ClienteService.edit(Cliente);
            return Ok(new { message = $"El Cliente con nombre {Cliente.Nombre} fue actualizado correctamente!!!" });
        }

        [HttpPost("deleteC")]
        public ActionResult delete(int id)
        {
            ClienteService.delete(id);
            return Ok(new { message = $"El Cliente fue eliminado correctamente!!!" });
        }


        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
