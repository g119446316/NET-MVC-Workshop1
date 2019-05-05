using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using workshop.Models;

namespace workshop.Controllers
{
    public class HOMEController : Controller
    {
        DB_BOOKEntities1 db = new DB_BOOKEntities1();
        // GET: HOME
        [HttpGet]
        public ActionResult Index(string Sbookname,string Sclassname,string Sbrrower,string Sstatus)
        {      
            //書名搜
            var Sbook = from a in db.BOOK_G select a;
            if (!string.IsNullOrEmpty(Sbookname))
            {
                Sbook = Sbook.Where(m => m.BOOK_NAME.Contains(Sbookname));
            }
            //類別搜
            var Sbookclasslist = new List<string>();
            var Sbookclasslist2 = from b in db.BOOK_G orderby b.BOOK_CLASS_NAME select b.BOOK_CLASS_NAME;
            Sbookclasslist.AddRange(Sbookclasslist2.Distinct());
            ViewBag.Sclassname = new SelectList(Sbookclasslist);
            if (!string.IsNullOrEmpty(Sclassname))
            {
                Sbook = Sbook.Where(m => m.BOOK_CLASS_NAME == Sclassname);
            }
            //借閱人搜
            var Sbookbrolist = new List<string>();
            var Sbookbrolist2 = from c in db.BOOK_G orderby c.BOOK_BRROWER select c.BOOK_BRROWER;
            Sbookbrolist.AddRange(Sbookbrolist2.Distinct());
            ViewBag.Sbrrower = new SelectList(Sbookbrolist);
            if (!string.IsNullOrEmpty(Sbrrower))
            {
                Sbook = Sbook.Where(m => m.BOOK_BRROWER == Sbrrower);
            }
            //借閱狀態搜
            var Sstatuslist = new List<string>();
            var Sstatuslist2 = from d in db.BOOK_G orderby d.BOOK_STATUS select d.BOOK_STATUS;
            Sstatuslist.AddRange(Sstatuslist2.Distinct());
            ViewBag.Sstatus = new SelectList(Sstatuslist);
            if (!string.IsNullOrEmpty(Sstatus))
            {
                Sbook = Sbook.Where(m => m.BOOK_STATUS == Sstatus);
            }
            return View(Sbook);
            //var book = db.BOOK_G.OrderBy(m => m.BOOK_ID).ToList();
          //  return View(book);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(BOOK_G vBook)
        {
            db.BOOK_G.Add(vBook);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int BOOK_ID) {
            ViewBag.confirm = "是否刪除";
            var book = db.BOOK_G.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            db.BOOK_G.Remove(book);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}



