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
    public class HomeController : Controller
    {
        private IRepositoryBase<Question> Questionrepository;
        private IRepositoryBase<Category> Categoryrepository;
        private IRepositoryBase<Level> Levelrepository;
        private IRepositoryBase<Document> Documentrepository;

        public HomeController(IRepositoryBase<Question> Questionrepository, IRepositoryBase<Category> Categoryrepository,
            IRepositoryBase<Level> Levelrepository, IRepositoryBase<Document> Documentrepository)
        {
            this.Questionrepository = Questionrepository;
            this.Categoryrepository = Categoryrepository;
            this.Levelrepository = Levelrepository;
            this.Documentrepository = Documentrepository;
        }

        public ActionResult Index(int id = 0)
        {
            ViewBag.Title = "Home";

            IEnumerable<Question> questions = null;
            if (id != 0)
            {
                Category category = Categoryrepository.GetById(id);
                ViewBag.Title = category.Name;

                questions = Questionrepository.GetAll().Where(x => x.CategoryId == id).OrderBy(x => x.Ratting);
            }
            else
                questions = Questionrepository.GetAll();

            IEnumerable<QuestionViewModel> models = MapToViewModel(questions.ToList());

            return View(models);
        }

        private IEnumerable<QuestionViewModel> MapToViewModel(IEnumerable<Question> questions)
        {
            int count = 1;

            return questions.Select(x =>
                new QuestionViewModel
                {
                    Id = x.Id,
                    Count = count++,
                    Answer = x.Answer,
                    Category = x.Category.Name,
                    Lavel = x.Level.Title,
                    Question = x.Title,
                    Ratting = x.Ratting
                });
        }



        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.CategoryId = new SelectList(Categoryrepository.GetAll(), "Id", "Name");
            ViewBag.LevelId = new SelectList(Levelrepository.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateQuestionModel createQuestionModel)
        {
            Question question = MapToQuestionCreateModel(createQuestionModel);
            Questionrepository.Insert(question);
            Questionrepository.Commit();
            return RedirectToAction("Index/" + question.CategoryId.ToString());
        }

        
        private Question MapToQuestionCreateModel(CreateQuestionModel createQuestionModel)
        {
            Question question = new Question
            {
                Id = createQuestionModel.Id,
                Title = createQuestionModel.Title,
                Answer = createQuestionModel.Answer,
                Source = createQuestionModel.Source,
                Ratting = createQuestionModel.Ratting,
                LevelId = createQuestionModel.LevelId,
                CategoryId = createQuestionModel.CategoryId,
            };

            return question;
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Question question = Questionrepository.GetById(id);
            ViewBag.CategoryId = new SelectList(Categoryrepository.GetAll(), "Id", "Name",question.CategoryId);
            ViewBag.LevelId = new SelectList(Levelrepository.GetAll(), "Id", "Title", question.LevelId);
            return View(question);
        }
        [HttpPost]
        public ActionResult Edit(CreateQuestionModel createQuestionModel)
        {
            Question question = MapToQuestionCreateModel(createQuestionModel);
            Questionrepository.Update(question);
            Questionrepository.Commit();
            return RedirectToAction("Index/"+question.CategoryId.ToString());
        }

        public ActionResult Delete(int id)
        {

            Questionrepository.Delete(id);
            Questionrepository.Commit();
           

            return RedirectToAction("Index");            
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }


        public ActionResult Csharp()
        {
            var questions = Questionrepository.GetAll().Where(x => x.CategoryId == 1);

            IEnumerable<QuestionViewModel> models = MapToViewModel(questions.ToList());

            return View("Index",models);
        }
        public ActionResult ASPNET()
        {
            var questions = Questionrepository.GetAll().Where(x => x.CategoryId == 2);

            IEnumerable<QuestionViewModel> models = MapToViewModel(questions.ToList());

            return View("Index", models);
        }

        public ActionResult MVC()
        {
            var questions = Questionrepository.GetAll().Where(x => x.CategoryId == 2);

            IEnumerable<QuestionViewModel> models = MapToViewModel(questions.ToList());

            return View("Index", models);
        }

        [ChildActionOnly]
        [OutputCache(Duration=10)]
        public ActionResult NavButton()
        {
            NavButtonModel model = new NavButtonModel { 
             Categories = Categoryrepository.GetAll().ToList(),
             Levels = Levelrepository.GetAll().ToList(),
            };
            return PartialView(model);
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // TODO: send the message to HQ
            ViewBag.TheMessage = "Thanks, we got your message!";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            // return new HttpStatusCodeResult(403);
            // return Json(new { name = "serial number", value = "serial" }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }
    }
}