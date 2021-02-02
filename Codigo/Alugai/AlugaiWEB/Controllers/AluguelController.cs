using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AlugaiWEB.Controllers
{
    public class AluguelController : Controller
    {
        IAluguelService _aluguelService;
        IStatuspagamentoService _statusPagamentoService;
        IMapper _mapper;

        public AluguelController(IAluguelService aluguelService,
                                 IStatuspagamentoService statuspagamentoService, IMapper mapper)
        {
            _aluguelService = aluguelService;
            _statusPagamentoService = statuspagamentoService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarAlugueis = _aluguelService.ObterTodos();
            var listarAlugueisModel = _mapper.Map<List<AluguelModel>>(listarAlugueis);

            return View(listarAlugueisModel);
        }

        public ActionResult Details(int id)
        {
            Aluguel aluguel = _aluguelService.Buscar(id);
            AluguelModel aluguelModel = _mapper.Map<AluguelModel>(aluguel);

            return View(aluguelModel);
        }

        public ActionResult Create()
        {
            IEnumerable<Statuspagamento> listarStatusPagamento = _statusPagamentoService.ObterTodos();

            ViewBag.IdStatusPagamento = new SelectList(listarStatusPagamento, "CodigoStatusPagamento", "Descricao", null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AluguelModel aluguelModel)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(aluguelModel);
                _aluguelService.Inserir(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Aluguel aluguel= _aluguelService.Buscar(id);
            AluguelModel aluguelModel = _mapper.Map<AluguelModel>(aluguel);

            IEnumerable<Statuspagamento> listarStatusPagamento = _statusPagamentoService.ObterTodos();
            ViewBag.IdStatusPagamento = new SelectList(listarStatusPagamento, "CodigoStatusPagamento", "Descricao", null);

            return View(aluguelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AluguelModel aluguelModel)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(aluguelModel);
                _aluguelService.Alterar(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Aluguel aluguel = _aluguelService.Buscar(id);
            AluguelModel aluguelModel = _mapper.Map<AluguelModel>(aluguel);
            return View(aluguelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AluguelModel aluguelModel)
        {
            _aluguelService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
