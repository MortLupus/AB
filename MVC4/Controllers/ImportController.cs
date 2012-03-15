using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using MVC4.Integration.BattleScribe;
using MVC4.ViewModels.Import;

namespace MVC4.Controllers
{
    public class ImportController : RavenController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ImportModel model, HttpPostedFileBase file)
        {
            if (file.ContentLength <= 0)
            {
                ModelState.AddModelError("File", "Missing or empty file uploaded");
            }

            //if (!ModelState.IsValid)
            //    return View();

            if(model.Type == ProgramType.BattleScribe)
                ImportBattleScribe(file.InputStream);
            
            return Json(new {Complete = "true"});

        }

        private void ImportBattleScribe(Stream inputStream)
        {
            var battleScribe = new BattleScribe();

            var xmlSerializer = new XmlSerializer(typeof (Roster));
            var roster = (Roster)xmlSerializer.Deserialize(inputStream);

            battleScribe.Import(roster);
        }
    }
}
