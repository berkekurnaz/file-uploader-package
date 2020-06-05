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

        /// <summary>
        ///  Upload a new file
        /// </summary>
        /// <param name="uploadFile">The file you want to upload</param>
        /// <param name="uploadFileName">The name you want to give to the file you want to upload</param>
        /// <param name="folderName">The folder where you want to upload the file</param>
        /// <returns></returns>
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


        /// <summary>
        /// Update a file by file name
        /// </summary>
        /// <param name="uploadFile">The file you want to upload</param>
        /// <param name="uploadFileName">The name you want to give to the file you want to upload</param>
        /// <param name="folderName">The folder where you want to upload the file</param>
        /// <param name="updatedFileName">Name of the image that will be updated</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a file by file name
        /// </summary>
        /// <param name="uploadFileName">The name you want to give to the file you want to delete</param>
        /// <param name="folderName">The folder where you want to upload the file</param>
        /// <returns></returns>
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
