using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlugaiWEB.Controllers
{
    public class SolicitacaoManutencaoController : Controller
    {

        ISolicotacaoManutencaoService _SolicitacaoManutencaoService;
        IMapper _mapper;

        public SolicitacaoManutencaoController(ISolicotacaoManutencaoService solicotacaoManutencaoService, IMapper mapper)
        {
            _SolicitacaoManutencaoService = solicotacaoManutencaoService;
            _mapper = mapper;
        }

        // GET: SolicitacaoManutencaoController
        public ActionResult Index()
        {
            IEnumerable<Manuntencao> listarManutencao = _SolicitacaoManutencaoService.ObterTodos();
            var listarSolicitacaoManutencaoModel = _mapper.Map<List<SolicitacaoManuntecaoModel>>(listarManutencao);

            return View(listarSolicitacaoManutencaoModel);
        }

        // GET: SolicitacaoManutencaoController/Details/5
        public ActionResult Details(int id)
        {
            Manuntencao SolicitacaoManutencao = _SolicitacaoManutencaoService.Buscar(id);
            SolicitacaoManuntecaoModel solicitacaoManuntecaoModel = _mapper.Map<SolicitacaoManuntecaoModel>(SolicitacaoManutencao);
            return View(solicitacaoManuntecaoModel);
        }

        // GET: SolicitacaoManutencaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitacaoManutencaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoManuntecaoModel solicitacaoManuntecaoModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacaoManutencao = _mapper.Map<Manuntencao>(solicitacaoManuntecaoModel);
                _SolicitacaoManutencaoService.Inserir(solicitacaoManutencao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoManutencaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Manuntencao solicitacaoManutencao = _SolicitacaoManutencaoService.Buscar(id);
            SolicitacaoManuntecaoModel solicitacaoManuntecaoModel = _mapper.Map<SolicitacaoManuntecaoModel>(solicitacaoManutencao);
            return View(solicitacaoManuntecaoModel);
        }

        // POST: SolicitacaoManutencaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SolicitacaoManuntecaoModel solicitacaoManuntecaoModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacaoManutencao = _mapper.Map<Manuntencao>(solicitacaoManuntecaoModel);
                _SolicitacaoManutencaoService.Alterar(solicitacaoManutencao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoManutencaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Manuntencao solicitacaoManutencao = _SolicitacaoManutencaoService.Buscar(id);
            SolicitacaoManuntecaoModel solicitacaoManuntecaoModel = _mapper.Map<SolicitacaoManuntecaoModel>(solicitacaoManutencao);
            return View(solicitacaoManuntecaoModel);
        }

        // POST: SolicitacaoManutencaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SolicitacaoManuntecaoModel solicitacaoManuntecaoModel)
        {
            _SolicitacaoManutencaoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
