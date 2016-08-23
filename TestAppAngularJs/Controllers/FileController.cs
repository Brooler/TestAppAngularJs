using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestAppAngularJs.Controllers
{
    public class FileController : ApiController
    {
        private long less10 = 0;
        private long less50 = 0;
        private long more100 = 0;

        public IHttpActionResult GetFileCounts(string path)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileCheck(info);
                FileCountsResponse model = new FileCountsResponse
                {
                    Less10Mb = less10,
                    More10MbLess50Mb = less50,
                    More100Mb = more100
                };
                return Ok(model);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }


        private void FileCheck(DirectoryInfo dir)
        {
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    try
                    {
                        if (file.Length <= 10485760)
                        {
                            less10++;
                        }
                        else if (file.Length > 10485760 && file.Length <= 52428800)
                        {
                            less50++;
                        }
                        else if (file.Length >= 104857600)
                        {
                            more100++;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                DirectoryInfo[] directories = dir.GetDirectories();
                foreach (var directory in directories)
                {
                    try
                    {
                        FileCheck(directory);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }

    public class FileCountsResponse
    {
        public long Less10Mb { get; set; }
        public long More10MbLess50Mb { get; set; }
        public long More100Mb { get; set; }
    }
}
