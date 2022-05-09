using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentManagementAPI.Extensions
{
    public static class SourcePath
    {
        private static IWebHostEnvironment _hostingEnvironment;

        public static bool IsInitialized { get; private set; }

        public static void Initialize(IWebHostEnvironment hostEnvironment)
        {
            if (IsInitialized)
                throw new InvalidOperationException("Object already initialized");

            _hostingEnvironment = hostEnvironment;
            IsInitialized = true;
        }

        public static async Task SaveFileAsync(IFormFileCollection files, string Folder, int Id)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Object is not initialized");
            var path =  $"{_hostingEnvironment.ContentRootPath}/uploads/{Folder}/{Id}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            foreach(var file in files)
            {
                var filePath = path+"\\"+ file.FileName;
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            } 
        }


    }
}
