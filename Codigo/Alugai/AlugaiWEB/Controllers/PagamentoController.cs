using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AlugaiWEB.Controllers
{
    public class PagamentoController : Controller
    {
        IPagamentoService _pagamentoService;
        IAluguelService _aluguelService;
        IMapper _mapper;

        public PagamentoController(IPagamentoService pagamentoService,
                                   IAluguelService aluguelService, IMapper mapper)
        {
            _pagamentoService = pagamentoService;
            _aluguelService = aluguelService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarPagamentos = _pagamentoService.ObterTodos();
            var listarPagamentoModel = _mapper.Map<List<PagamentoModelcs>>(listarPagamentos);

            return View(listarPagamentoModel);
        }


        public ActionResult Details(int id)
        {
            Pagamento pagamento = _pagamentoService.Buscar(id);
            PagamentoModelcs pagamentoModel = _mapper.Map<PagamentoModelcs>(pagamento);

            return View(pagamentoModel);
        }


        public ActionResult Create()
        {
            IEnumerable<Aluguel> listarAlugueis = _aluguelService.ObterTodos();

            ViewBag.IdAluguel = new SelectList(listarAlugueis, "CodigoAluguel", "Descricao", null);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagamentoModelcs pagamentoModel)
        {
            if (ModelState.IsValid)
            {
                var pagamento = _mapper.Map<Pagamento>(pagamentoModel);
                _pagamentoService.Inserir(pagamento);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            Pagamento pagamento = _pagamentoService.Buscar(id);
            PagamentoModelcs pagamentoModel = _mapper.Map<PagamentoModelcs>(pagamento);

            IEnumerable<Aluguel> listarAlugueis = _aluguelService.ObterTodos();
            ViewBag.IdAluguel = new SelectList(listarAlugueis, "CodigoAluguel", "Descricao", null);

            return View(pagamentoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PagamentoModelcs pagamentoModel)
        {
            if (ModelState.IsValid)
            {
                var pagamento = _mapper.Map<Pagamento>(pagamentoModel);
                _pagamentoService.Alterar(pagamento);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            Pagamento pagamento = _pagamentoService.Buscar(id);
            PagamentoModelcs pagamentoModel = _mapper.Map<PagamentoModelcs>(pagamento);
            return View(pagamentoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PagamentoModelcs pagamentoModel)
        {
            _pagamentoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
