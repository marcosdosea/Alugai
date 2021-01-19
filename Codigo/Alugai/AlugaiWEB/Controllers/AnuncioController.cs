using AlugaiWEB.Models;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Controllers
{
    public class AnuncioController : Controller
    {
        IAnuncioService _anuncioService;
        IMapper _mapper;

        public AnuncioController(IAnuncioService anuncioService, IMapper mapper)
        {
            _anuncioService = anuncioService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listarAnuncios = _anuncioService.ObterTodos();
            var listarAnunciosModel = _mapper.Map<List<AnuncioModel>>(listarAnuncios);

            return View(listarAnunciosModel);
        }

        public ActionResult Details(int id)
        {
            Anuncio anuncio = _anuncioService.Buscar(id);
            AnuncioModel anuncioModel = _mapper.Map<AnuncioModel>(anuncio);

            return View(anuncioModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioModel anuncioModel)
        {
            if (ModelState.IsValid)
            {
                var anuncio = _mapper.Map<Anuncio>(anuncioModel);
                _anuncioService.Inserir(anuncio);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Anuncio anuncio = _anuncioService.Buscar(id);
            AnuncioModel anuncioModel = _mapper.Map<AnuncioModel>(anuncio);
            return View(anuncioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnuncioModel anuncioModel)
        {
            if (ModelState.IsValid)
            {
                var anuncio = _mapper.Map<Anuncio>(anuncioModel);
                _anuncioService.Alterar(anuncio);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Anuncio anuncio = _anuncioService.Buscar(id);
            AnuncioModel anuncioModel = _mapper.Map<AnuncioModel>(anuncio);
            return View(anuncioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AnuncioModel anuncioModel)
        {
            _anuncioService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
