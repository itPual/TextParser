using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextParser;
using TextParser.Classes;
using TextParserWebApp.Models;

namespace TextParserWebApp.Controllers
{
    public class HomeController : Controller
    {
        public OptionsList list = new OptionsList();
        public ActionResult Index()
        {
            ViewBag.List = list.List;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pavlo Cheremys.";

            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            string path = "";
            List<string> res = new List<string>();
            KeyValuePair<String, int> pair = new KeyValuePair<string, int>();
            IParse counter = null;

            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                    // сохраняем полное имя файла для дальнейшей обработки
                    path = Server.MapPath("~/Files/" + fileName);
                }
            }

            var tmp = Request.Form.GetValues("action");
            int caseSwitch = int.Parse(tmp[0]);

            switch (caseSwitch)
            {
                case 1:
                    counter = new CountingWords();
                    break;
                case 2:
                    counter = new СountingNumbers();
                    break;
                case 3:
                    counter = new СountingNotNumbers();
                    break;
                case 4:
                    counter = new CountingSentences();
                    break;
                case 5:
                    counter = new FrequentWord();
                    break;
                case 6:
                    counter = new FrequentChar();
                    break;
                default:
                    counter = null;
                    break;
            }

            try
            {
                FileParser parser = new FileParser(path, counter);
                res.Add("File name - " + parser.FileName);
                res.Add("File size - " + parser.FileSize);
                pair = parser.TryParse();
                res.Add(pair.Key + " - " + pair.Value);
            }
            catch (Exception ex)
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
                res.Clear();
                res.Add(ex.Message);
                return Json(res);
            }

            return Json(res);
        }
    }
}