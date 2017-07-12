using KidsAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KidsAcademy.Controllers
{
    public class HomeController : Controller
    {
        KidsAcademyEntities db = new KidsAcademyEntities();
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult BooksView()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PoemsView()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LearningView()
        {
            

            return View();
        }

        public ActionResult GamesView()
        {


            return View();
        }
        public ActionResult AdditionActivityView()
        {


            return View();
        }

        public ActionResult AdditionLevelTwoView()
        {


            return View();
        }
        public ActionResult AdditionLevelThreeView()
        {


            return View();
        }
        public ActionResult AdditionLevelFourView()
        {


            return View();
        }
        


        public ActionResult CongratulationsView()
        {


            return View();
        }
        public ActionResult SubtractionActivityView()
        {


            return View();
        }
        public ActionResult SubtractionLevelTwoView()
        {


            return View();
        }
        public ActionResult SubtractionLevelThreeView()
        {


            return View();
        }
        public ActionResult SubtractionLevelFourView()
        {


            return View();
        }
        public ActionResult SubtractionCongratulation()
        {


            return View();
        }
        public ActionResult TouchBallGameView()
        {
            return View();
        }

        public ActionResult SnakeGameView()
        {
            return View();
        }

        public ActionResult BrickGameView()
        {
            return View();
        }

       
        
        public ActionResult CountingView()
        {
            var obj = db.countingTables.ToList();

            return View(obj);
        }
        public ActionResult PoemReadingView()
        {
       
            var obj = db.poemTables.ToList();
            return View(obj);
        }
        
        public ActionResult ContactUsView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUsView(ContactUs obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    WebMail.Send(

                     "adeelaislam84@gmail.com",
                      obj.Name+"'s Message",
                      "<b>Message:  <br/></b>" + obj.Message + "<br/><br/>" + obj.Name + " Mail address is: " + obj.Email,
                      null,
                      null,
                      null,
                      true,
                      null,
                      null,
                      null,
                      null,
                      null,
                      obj.Email
                     );
                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {

                ViewBag.Error = "Problems sending Email!";


            }
            return View();
        }

        


        private void insertKid(string p1, string p2, int p3, string p4)
        {
            //throw new NotImplementedException();
        }
    }
}