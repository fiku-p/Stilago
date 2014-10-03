using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplication1.DataAccess;
using WebApplication1.Models.Task1;
using WebApplication1.Models.Task2.RssModelClasses;
using WebApplication1.Models.Task3;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region TASK 1

        public ActionResult Task1()
        {
            var randomNumbers = GenerateRandomNumbers.Generate(10);
            return View(randomNumbers);
        }
        #endregion

        #region TASK 2
        public ActionResult Task2()
        {
            const string feedUrl = "http://www.rtvslo.si/novice/rss/";

            using (var feedReader = XmlReader.Create(feedUrl))
            {
                var feedContent = SyndicationFeed.Load(feedReader);

                var syndication = SyndicationFeedProcessor.ProcessSyndication(feedContent);

                return View(syndication);
            }
        }

        #endregion

        #region TASK 3

        public ActionResult Task3()
        {
            var uploadViewModel = new UploadViewModel();

            var result = DatabaseHelper.ExcecuteStoreProcedure("GetFiles");

            var listFiles = (result.Rows.Cast<DataRow>().Select(row => new FileModel
            {
                id = (int)row["id"],
                file_name = row["file_name"].ToString(),
                file_type = row["file_type"].ToString(),
                document = (byte[])row["document"],
            })).ToList();

            uploadViewModel.Files = listFiles;

            return View(uploadViewModel);
        }

        [HttpPost]
        public ActionResult Task3(HttpPostedFileBase fileToUpload)
        {
            var file = fileToUpload.MapFileToDomainObject();

            DatabaseHelper.ExcecuteSaveStoreProcedure("SaveFile", file);

            return RedirectToAction("Task3");
        }

        public FileResult GetFile(int id)
        {
            var result = DatabaseHelper.ExcecuteGetStoreProcedure("GetFileById", id);

            FileModel fileModel = (result.Rows.Cast<DataRow>().Select(row => new FileModel
            {
                id = (int)row["id"],
                file_name = row["file_name"].ToString(),
                file_type = row["file_type"].ToString(),
                document = (byte[])row["document"],
            })).FirstOrDefault();

            if (fileModel != null)
            {
                return File(fileModel.document, System.Net.Mime.MediaTypeNames.Application.Octet, fileModel.file_name);
            }

            return null;
        }

        #endregion

        #region TASK 4

        public ActionResult Task4()
        {
            return View();
        }
        #endregion

        #region Other Default Views
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion


        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                default:
                    return "application/octet-stream";
            }
        }
    }
}