using AutoMapper;
using Core.Services;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AlugaiWEB.Models;

namespace AlugaiWEB.Controllers
{
    public class DeclaracaoAluguelController : Controller
    {
        IDeclaracaoAluguelService _declaracaoAluguelService;
        IMapper _mapper;

        public DeclaracaoAluguelController(IDeclaracaoAluguelService declaracaoAluguelService, IMapper mapper)
        {
            _declaracaoAluguelService = declaracaoAluguelService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarDeclaracoes = _declaracaoAluguelService.ObterTodos();
            var listarDeclaracoesModel = _mapper.Map<List<DeclaracaoAluguelModel>>(listarDeclaracoes);

            return View(listarDeclaracoesModel);
        }

        public ActionResult Details(int id)
        {
            Aluguel declaracao = _declaracaoAluguelService.Buscar(id);
            DeclaracaoAluguelModel declaracaoAluguelModel = _mapper.Map<DeclaracaoAluguelModel>(declaracao);
            return View(declaracaoAluguelModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeclaracaoAluguelModel declaracao)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(declaracao);
                _declaracaoAluguelService.Inserir(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Aluguel declaracao = _declaracaoAluguelService.Buscar(id);
            DeclaracaoAluguelModel declaracaoAluguelModel = _mapper.Map<DeclaracaoAluguelModel>(declaracao);
            return View(declaracaoAluguelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeclaracaoAluguelModel declaracao)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(declaracao);
                _declaracaoAluguelService.Alterar(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Aluguel declaracao = _declaracaoAluguelService.Buscar(id);
            DeclaracaoAluguelModel declaracaoAluguelModel = _mapper.Map<DeclaracaoAluguelModel>(declaracao);
            return View(declaracaoAluguelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DeclaracaoAluguelModel declaracao)
        {
            _declaracaoAluguelService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
