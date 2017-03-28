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
    public class ImagensProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoApp;
        private readonly IImagensProdutoRepository _ImgProdApp;

        public ImagensProdutoController(IProdutoRepository produtoApp, IImagensProdutoRepository ImgProdApp)
        {
            _produtoApp = produtoApp;
            _ImgProdApp = ImgProdApp;

        }
        //
        // GET: /ImagensProduto/
        public ActionResult Index()
        {

            var ImgProddViewModel = Mapper.Map<IEnumerable<ImagensProduto>, IEnumerable<ImagensProdutoViewModel>>(_ImgProdApp.GetAll());

            int id = 0;

            foreach (var item in ImgProddViewModel.ToList())
            {
                //pego o q preciso aqui

                id = item.ImagemId;
            }
            //pega byte da imagem

            getImg(id);
            return View(ImgProddViewModel);
        }

        public FileContentResult getImg(int id)
        {

            var imgProduto = _ImgProdApp.GetById(id);

            byte[] imgContent = imgProduto.Imagem;
            string contentType =imgProduto.FormatoImg;
            
  

            return imgContent != null ? new FileContentResult(imgContent, contentType) : null;
        }

        public ActionResult BuscaPorNome(string nome)
        {


            var ImgProddViewModel = Mapper.Map<IEnumerable<ImagensProduto>, IEnumerable<ImagensProdutoViewModel>>(_ImgProdApp.BuscaPorNome(nome));

            return View(ImgProddViewModel);
        }


        //
        // GET: /ImagensProduto/Details/5
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
            return View("Error"); // View de erro em 
        }

        //
        // GET: /ImagensProduto/Create
        public ActionResult Create()
        {

            try
            {
                ViewBag.ProdutoId = new SelectList(_produtoApp.GetAll(), "ProdutoId", "Nome"); //dropdowns list
            }
            catch(Exception ex)
            {
                ViewBag.resposta = "Erro: " + ex.Message.ToString();
            }

            return View();
        }

        //
        // POST: /ImagensProduto/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(ImagensProdutoViewModel imgProduto, HttpPostedFileBase uploadFile)
        {
            try
            {

                if (uploadFile.ContentLength > 0)
                {
                    string relativePath = "~/img/" + Path.GetFileName(uploadFile.FileName);
                  
                    //convertendo para byte
                    int fileSizeInBytes = uploadFile.ContentLength;
                    MemoryStream ms = new MemoryStream();
                    uploadFile.InputStream.CopyTo(ms);
                    byte[] data = ms.ToArray();



                    //setando dados para salvar na tabela

                    imgProduto.ImagemTamanho = uploadFile.ContentLength;
                    imgProduto.Imagem = data;
               
                 
                }
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var ImagemProdutoDomain = Mapper.Map<ImagensProdutoViewModel, ImagensProduto>(imgProduto);

                        _ImgProdApp.Add(ImagemProdutoDomain);
                         ViewBag.resposta = "Sucesso";
                        return RedirectToAction("Index");
                    }
                }
            
            catch(Exception ex)
            {
                ViewBag.resposta = "Erro: " + ex.Message.ToString();
            }
            return View(imgProduto);
        }

        //
        // GET: /ImagensProduto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ImagensProduto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ImagensProduto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ImagensProduto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
