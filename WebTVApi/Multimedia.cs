using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace WebTVApi
{
    public enum Type 
    {
        Adv,
        News,
        Photo,
        Statistics
    }

    public class MultimediaFile
    {
        // public Url url { get; set; }
        public int id { get; set; }
        public Type type { get; set; }  
        public string Name { get; set; }
        public string Extension { get; set; } 
    }

    public static class Multimedia
    {
        public static int idFiles = 0;

        public static void UpdateFiles(List<List<MultimediaFile>> e, string stream)
        {
            e.Clear();
            e.Add(GetMultimedia(Type.Adv, stream));
            e.Add(GetMultimedia(Type.Photo, stream));
            e.Add(GetMultimedia(Type.News, stream));
        }

        public static List<MultimediaFile> GetMultimedia(Type e, string stream)
        {
            List<MultimediaFile> multimediaFiles = new List<MultimediaFile>();

            foreach (var item in new DirectoryInfo($"./Media/{stream}/{e}/").GetFiles())
            {
                    var t = new MultimediaFile();
                    t.Name = item.Name;
                    t.Extension = item.Extension;
                    t.type = e;
                    t.id = idFiles;
                    idFiles++;
                    multimediaFiles.Add(t);
            }

            return multimediaFiles;
        }
    }
}
