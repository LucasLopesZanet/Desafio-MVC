using Dominio.Advogado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoRepositorio _advogadoRepositorio;

        public AdvogadoController(IAdvogadoRepositorio advogadoRepositorio)
        {
            _advogadoRepositorio = advogadoRepositorio;
        }

        public ActionResult Index()
        {
            var listaDeAdvogados = _advogadoRepositorio.ListarAdvogados();
            return View(listaDeAdvogados);
        }


        public ActionResult IncluirAdvogado()
        {
            ViewBag.Senioridade = ListarSerioridade();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncluirAdvogado(Advogado advogado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Senioridade = ListarSerioridade();
                return View(advogado);
            }
             try
            {
                _advogadoRepositorio.IncluirAdvogado(advogado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AtulizarAdvogado(int id)
        {
            ViewBag.Senioridade = ListarSerioridade();
            var advogado = _advogadoRepositorio.BuscarPorId(id);
            return View(advogado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtulizarAdvogado(Advogado advogado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Senioridade = ListarSerioridade();
                return View();
            }
            try
            {
                _advogadoRepositorio.AtulizarAdvogado(advogado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ExcluirAdvogado(int id)
        {
            try
            {
                _advogadoRepositorio.ExcluirAdvogado(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            
        }
        Dictionary<string,string> ListarSerioridade()
        {
            return  new Dictionary<string, string>()
            {
                {"Sernior", "Senior" },
                {"Plenor", "Plenor" },
                {"Junior", "Junior" }
            };
        }
        
       
    }
}
