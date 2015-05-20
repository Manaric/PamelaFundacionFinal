using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PamelaFundacionFinal;

namespace PamelaFundacionFinal.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            return View();
        }

        public void Categoria( int id)
        {
            var x = new PamelaFundacionFinal.Models.PagosBecarios_Result();
            //Aquí va  new PamelaFundacionFinal.Models.PagosBecado_Result();

        }
    }
}