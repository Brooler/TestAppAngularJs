using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAppAngularJs.Models;

namespace TestAppAngularJs.Controllers
{
    public class DirectoryController : ApiController
    {
        public IHttpActionResult GetDirectory(string path)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                DirectoryResponseModel model = new DirectoryResponseModel
                {
                    Directories = new List<DirectoryModel>(),
                    Files = new List<FileModel>(),
                    CurrentPath = path
                };
                try
                {
                    DirectoryInfo parentDirectory = directoryInfo.Parent;
                    model.Directories.Add(new DirectoryModel { Name = "..", Path = parentDirectory.FullName });
                }
                catch (Exception ex)
                {
                    DirectoryInfo parentDirectory = directoryInfo.Parent;
                    model.Directories.Add(new DirectoryModel { Name = "..", Path = "" });
                }
                DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                foreach(var dir in dirs)
                {
                    model.Directories.Add(new DirectoryModel { Name = dir.Name, Path = dir.FullName });
                }
                FileInfo[] files = directoryInfo.GetFiles();
                foreach(var file in files)
                {
                    model.Files.Add(new FileModel { Name = file.Name, Path = file.FullName });
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetDirectory()
        {
            try
            {
                DriveInfo[] disks = DriveInfo.GetDrives();
                DirectoryResponseModel model = new DirectoryResponseModel
                {
                    Directories = new List<DirectoryModel>(),
                    CurrentPath = ""
                };
                foreach(var disk in disks)
                {
                    model.Directories.Add(new DirectoryModel { Path = disk.Name, Name = disk.Name });
                }
                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
