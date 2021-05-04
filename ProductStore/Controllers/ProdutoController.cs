﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStore.Models;
using ProductStore.Repository;

namespace ProductStore.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepository respository = new ProdutoRepository();
        private CategoriaRepository categoriaRespository = new CategoriaRepository();
        // GET: Produto
        public ActionResult Index()
        {
            var vm = new VMProduto();
            vm.Lista = respository.GetAll();
            vm.ListaCategoria = categoriaRespository.GetAll();
            vm.Produto = new Produto();
            return View(vm);
        }

        //public ActionResult Index(VMProduto vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        respository.Save(vm.Produto);
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: Produto/Create
        public ActionResult Create()
        {
            //return View();
            return RedirectToAction("Index");
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(VMProduto vm)
        {
            respository.Save(vm.Produto);
            return RedirectToAction("Index");
        }

        public ActionResult Save(VMProduto vm)
        {
            if (vm.Produto.Id > 0)
            {
                respository.Update(vm.Produto);
            }
            else
            {
                respository.Save(vm.Produto);
            }
            
            return RedirectToAction("Index");
        }


        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = respository.GetById(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            var vm = new VMProduto();
            vm.Produto = produto;
            vm.Lista = respository.GetAll();
            vm.ListaCategoria = categoriaRespository.GetAll();
            //return View(produto);
            return View("Index", vm);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                respository.Update(produto);
                return RedirectToAction("Index");
            }
            else
            {
                //return View(produto);
                return RedirectToAction("Index");
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            respository.DeleteById(id);
            //return Json(respository.GetAll());
            return RedirectToAction("Index");
        }
    }
}
