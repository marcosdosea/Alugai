using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlugaiWEB.Controllers
{
    public class StatuspagamentoController : Controller
    {
        IStatuspagamentoService _statuspagamentoService;
        IMapper _mapper;

        public StatuspagamentoController(IStatuspagamentoService statuspagamentoService, IMapper mapper)
        {
            _statuspagamentoService = statuspagamentoService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarStatuspagamento = _statuspagamentoService.ObterTodos();
            var listarStatuspagamentoModel = _mapper.Map<List<StatuspagamentoModel>>(listarStatuspagamento);

            return View(listarStatuspagamentoModel);
        }


        public ActionResult Details(int id)
        {
            Statuspagamento statuspagamento= _statuspagamentoService.Buscar(id);
            StatuspagamentoModel statuspagamentoModel = _mapper.Map<StatuspagamentoModel>(statuspagamento);

            return View(statuspagamentoModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StatuspagamentoModel statuspagamentoModel)
        {
            if (ModelState.IsValid)
            {
                var statuspagamento = _mapper.Map<Statuspagamento>(statuspagamentoModel);
                _statuspagamentoService.Inserir(statuspagamento);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            Statuspagamento statuspagamento= _statuspagamentoService.Buscar(id);
            StatuspagamentoModel statuspagamentoModel = _mapper.Map<StatuspagamentoModel>(statuspagamento);
            return View(statuspagamentoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StatuspagamentoModel statuspagamentoModel)
        {
            if (ModelState.IsValid)
            {
                var statuspagamento = _mapper.Map<Statuspagamento>(statuspagamentoModel);
                _statuspagamentoService.Alterar(statuspagamento);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            Statuspagamento statuspagamento= _statuspagamentoService.Buscar(id);
            StatuspagamentoModel statuspagamentoModel = _mapper.Map<StatuspagamentoModel>(statuspagamento);
            return View(statuspagamentoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StatuspagamentoModel statuspagamentoModel)
        {
            _statuspagamentoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
