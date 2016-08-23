using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppAngularJs.Models
{
    public class DirectoryResponseModel
    {
        public List<DirectoryModel> Directories { get; set; }
        public List<FileModel> Files { get; set; }
        public string CurrentPath { get; set; }

    }

    public class DirectoryModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }

    public class FileModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }
}