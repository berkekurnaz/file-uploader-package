using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.App.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.Test.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        /* This operations add a new file */
        [HttpPost]
        public async Task<IActionResult> FormUpload(IFormFile uploadFile)
        {
            if (uploadFile != null)
            {
                string guidFileName = Guid.NewGuid().ToString();
                if (await FileUploaderOperations.UploadFile(uploadFile, guidFileName, "MyFilesFolder") == true)
                {
                    var fileName = guidFileName + uploadFile.FileName;
                    TempData["MsgResult"] = "Upload operations was succesful. Upload file name : " + fileName;
                }
            }
            return RedirectToAction("Index");
        }

        /* This operations update a new file by file name */
        [HttpPost]
        public async Task<IActionResult> FormUpdate(IFormFile uploadFile, String fileName)
        {
            if (uploadFile != null)
            {
                string guidFileName = Guid.NewGuid().ToString();
                if (await FileUploaderOperations.UpdateFile(uploadFile, guidFileName, "MyFilesFolder", fileName) == true)
                {
                    var newFileName = guidFileName + uploadFile.FileName;
                    TempData["MsgResult"] = "Update operations was succesful. Old file name : " + fileName + " - New file name : " + newFileName;
                }
            }
            return RedirectToAction("Index");
        }

        /* This operations delete a new file by file name */
        [HttpPost]
        public async Task<IActionResult> FormDelete(String fileName)
        {
            if (fileName != null)
            {
                string guidFileName = Guid.NewGuid().ToString();
                if (await FileUploaderOperations.DeleteFile(fileName, "MyFilesFolder") == true)
                {
                    TempData["MsgResult"] = "Delete operations was succesful. Deleted file name : " + fileName;
                }
            }
            return RedirectToAction("Index");
        }

    }
}
