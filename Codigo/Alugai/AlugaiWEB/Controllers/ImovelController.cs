using AutoMapper;
using Core.Services;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlugaiWEB.Models;

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
