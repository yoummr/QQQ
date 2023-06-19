using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QQQ.DAL;
using QQQ.DAL.Data;
using QQQ.DAL.Repositories;
using QQQ.Model;
using QQQ.Contracts.Repositories;
using QQQ.Mvc5WebUI.Models;

namespace QQQ.Mvc5WebUI.Controllers
{
    public class DocumentController : Controller
    {
        private IRepositoryBase<Document> Documentrepository;
        public DocumentController(IRepositoryBase<Document> Documentrepository)
        {
            this.Documentrepository = Documentrepository;
        }

        public ActionResult Index(int id = 0)
        {
            var documents = Documentrepository.GetAll();

            IEnumerable<DocumentListViewModel> models = MapToDocumentListViewModel(documents, id);

            return View(models);
        }

        private IEnumerable<DocumentListViewModel> MapToDocumentListViewModel(IEnumerable<Document> documents, int id)
        {
            int i = 1;

            if (id == 0)
            {
                return documents.Select(x => new DocumentListViewModel
                {
                    Id = x.Id,
                    Count = i++,
                    Title = x.Title,
                    Contents = x.Contents,
                    Description = x.Description,
                    CreateDate = x.CreateDate,
                    Priority = x.Priority,
                });
            }
            else
            {
                return documents.Select(x => new DocumentListViewModel
                {
                    Id = x.Id,
                    Count = i++,
                    Title = x.Title,
                    Contents = x.Contents.Substring(0, 200),
                    Description = x.Description,
                    CreateDate = x.CreateDate,
                    Priority = x.Priority,
                });
            }



        }

        [HttpGet]
        public ActionResult Create()
        {
            DocumentListViewModel model = new DocumentListViewModel { 
             Contents = "--", Priority =1, Title = "Unknown", Description = "Unknown Description" 
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DocumentListViewModel _document)
        {
            Document document = MapToDocumentModel(_document);
            Documentrepository.Insert(document);
            Documentrepository.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            
            DocumentListViewModel model = MapToMedel(Documentrepository.GetById(id));
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DocumentListViewModel _document)
        {
            Document document = MapToDocumentModel(_document);
            Documentrepository.Update(document);
            Documentrepository.Commit();

            return RedirectToAction("Index");
        }

        private DocumentListViewModel MapToMedel(Document _document)
        {
            return new DocumentListViewModel {
                Id = _document.Id,
                Title = _document.Title,
                Contents = _document.Contents,
                Description = _document.Description,
                Priority = _document.Priority,
            };
        }

        public ActionResult Delete(int id)
        {
            Documentrepository.Delete(id);
            Documentrepository.Commit();
            return RedirectToAction("Index");
        }

        private Document MapToDocumentModel(DocumentListViewModel _document)
        {
            return new Document { 
             Id = _document.Id,
             Title = _document.Title,
             Contents = _document.Contents,
             Description = _document.Description,
             Priority = _document.Priority,
            };
        }

        public ActionResult Details(int id)
        {
            
            return View(Documentrepository.GetById(id));
        }
	}
}