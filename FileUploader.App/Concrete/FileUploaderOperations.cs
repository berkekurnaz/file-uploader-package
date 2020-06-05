using FileUploader.App.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUploader.App.Concrete
{
    public class FileUploaderOperations : IFileUploader
    {

        /* Yeni Bir Dosya Yukleme */
        public static async Task<bool> UploadFile(IFormFile uploadFile, string uploadFileName, string folderName)
        {
            bool isCompleted = false;
            if (uploadFile == null || uploadFile.Length == 0)
            {
                isCompleted = false;
            }
            else
            {
                string newImage = uploadFileName + uploadFile.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + folderName, newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                isCompleted = true;
            }
            return isCompleted;
        }


        /* Var Olan Bir Dosya Guncelleme */
        public static async Task<bool> UpdateFile(IFormFile uploadFile, string uploadFileName, string folderName, string updatedFileName)
        {
            bool isCompleted = false;
            if (uploadFile == null || uploadFile.Length == 0)
            {
                isCompleted = false;
            }
            else
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\" + folderName + "\\" + updatedFileName))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\" + folderName + "\\" + updatedFileName);
                }

                string newImage = uploadFileName + uploadFile.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\" + folderName, newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                isCompleted = true;
            }
            return isCompleted;
        }

        /* Var Olan Bir Dosya Silme */
        public static async Task<bool> DeleteFile(string deletedFileName, string folderName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\" + folderName + "\\" + deletedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\" + folderName + "\\" + deletedFileName);
            }
            return true;
        }

    }
}
