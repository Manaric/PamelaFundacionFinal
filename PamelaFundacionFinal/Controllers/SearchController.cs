using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PamelaFundacionFinal.Models;

namespace PamelaFundacionFinal.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Becario(string buscar)
        {
            var list = new List<DatosBecadoPorNombre_Result>();

            using (var context = new PamelaFundacionEntities())
            {
                var x2 = context.DatosBecadoPorNombre(buscar);
                list = x2.ToList();
            }

            return View(list);
        }

        public void PagoDeBecario(int id) 
        {

            using (var context = new PamelaFundacionEntities())
            {
                context.PagosBecado(id);
            }
        }
    }

    
}