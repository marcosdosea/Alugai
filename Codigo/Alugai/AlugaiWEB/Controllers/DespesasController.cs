using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlugaiWEB.Controllers
{
    public class DespesasController : Controller
    {
        // GET: DespesasController
        IManterDespesasService _despesasService;
        IMapper _mapper;

        public DespesasController(IManterDespesasService despesasService, IMapper mapper)
        {
            _despesasService = despesasService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarDespesas = _despesasService.ObterTodos();
            var listarDespesasModel = _mapper.Map<List<DespesasModel>>(listarDespesas);

            return View(listarDespesasModel);
        }

        public ActionResult Details(int id)
        {
            Despesas despesas = _despesasService.Buscar(id);
            DespesasModel despesasModel = _mapper.Map<DespesasModel>(despesas);

            return View(despesasModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DespesasModel despesasModel)
        {
            if (ModelState.IsValid)
            {
                var despesas = _mapper.Map<Despesas>(despesasModel);
                _despesasService.Inserir(despesas);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Despesas despesas = _despesasService.Buscar(id);
            DespesasModel despesasModel = _mapper.Map<DespesasModel>(despesas);
            return View(despesasModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DespesasModel despesasModel)
        {
            if (ModelState.IsValid)
            {
                var despesas = _mapper.Map<Despesas>(despesasModel);
                _despesasService.Alterar(despesas);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Despesas despesas = _despesasService.Buscar(id);
            DespesasModel despesasModel = _mapper.Map<DespesasModel>(despesas);
            return View(despesasModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DespesasModel despesasModel)
        {
            _despesasService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
