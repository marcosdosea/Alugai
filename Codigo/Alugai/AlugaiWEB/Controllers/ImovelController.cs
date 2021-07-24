using AutoMapper;
using Core.Services;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AlugaiWEB.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlugaiWEB.Controllers
{
    public class ImovelController : Controller
    {
        IImovelService _imovelService;
        IMapper _mapper;
        public ImovelController(IImovelService imovelService, IMapper mapper)
        {
            _imovelService = imovelService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarImoveis = _imovelService.ObterTodos();
            var listarImoveisModel = _mapper.Map<List<ImovelModel>>(listarImoveis);

            return View(listarImoveisModel);
        }

        public ActionResult Details(int id)
        {
            Imovel imovel = _imovelService.Buscar(id);
            ImovelModel imovelModel = _mapper.Map<ImovelModel>(imovel);

            return View(imovelModel);
        }


        public ActionResult Create()
        {

            var tiposImoveis = new[]
            {
                new SelectListItem { Value = "Apartamento", Text = "Apartamento" },
                new SelectListItem { Value = "Casa", Text = "Casa" },
                new SelectListItem { Value = "Casa de condominio", Text = "Casa de Condominio" },
                new SelectListItem { Value = "Garagem", Text = "Garagem" },
                new SelectListItem { Value = "Galpão/Depósito", Text = "Galpão/Depósito" },
                new SelectListItem { Value = "Terreno/Lote", Text = "Terreno/Lote" },
                new SelectListItem { Value = "Loja/Salão", Text = "Loja/Salão" },
            };

            ViewBag.TiposImoveis = new SelectList(tiposImoveis, "Value", "Text");
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImovelModel imovelModel)
        {
            if(ModelState.IsValid)
            {
                var imovel = _mapper.Map<Imovel>(imovelModel);
                _imovelService.Inserir(imovel);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Imovel imovel = _imovelService.Buscar(id);
            ImovelModel imovelModel = _mapper.Map<ImovelModel>(imovel);
            return View(imovelModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ImovelModel imovelModel)
        {
            if (ModelState.IsValid)
            {
                var imovel = _mapper.Map<Imovel>(imovelModel);
                _imovelService.Alterar(imovel);
            }
            return RedirectToAction(nameof(Index));
        }

        
        public ActionResult Delete(int id)
        {
            Imovel imovel = _imovelService.Buscar(id);
            ImovelModel imovelModel = _mapper.Map<ImovelModel>(imovel);
            return View(imovelModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ImovelModel imovelModel)
        {
            _imovelService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
