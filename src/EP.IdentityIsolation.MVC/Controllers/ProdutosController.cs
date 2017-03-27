using AutoMapper;
using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.Domain.Interface.Repository;
using EP.IdentityIsolation.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EP.IdentityIsolation.MVC.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {

        private readonly IProdutoRepository _produtoApp;
        private readonly IClienteRepository _clienteApp;

        public ProdutosController(IProdutoRepository produtoApp, IClienteRepository clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;

        }
        //
        // GET: /Produtos/
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());


            return View(produtoViewModel);
        }

        //
        // GET: /Produtos/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var produto = _produtoApp.GetById(id);
                var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

                return View(produtoViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.resposta = "Erro: " + ex.Message.ToString();
            }
            return View(); // View de erro em 
        }



        public ActionResult BuscaPorNome(string nome)
        {


            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.BuscaPorNome(nome));

            return View(produtoViewModel);
        }

        //
        // GET: /Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome"); //dropdowns list
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }
            return View(produto);
        }
       
        //
        // GET: /Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome"); //dropdowns list
            return View(produtoViewModel);
        }

        //
        // POST: /Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                //  return Redirect("Index");

            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome"); //dropdowns list
            return View(produto);
        }

        //
        // GET: /Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        //
        // POST: /Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);

            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}
