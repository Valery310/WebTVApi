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
        Video,
        Document,
        Photo
    }

    public class MultimediaFile
    {
       // public Url url { get; set; }
        public Type type { get; set; }  
        public string Name { get; set; }
        public string Extension { get; set; } 
    }

    public static class Multimedia
    {
        public static void UpdateFiles(List<List<MultimediaFile>> e)
        {
            e.Clear();
            e.Add(GetMultimedia(Type.Video));
            e.Add(GetMultimedia(Type.Photo));
            e.Add(GetMultimedia(Type.Document));
        }

        public static List<MultimediaFile> GetMultimedia(Type e)
        {
            List<MultimediaFile> multimediaFiles = new List<MultimediaFile>();

            foreach (var item in new DirectoryInfo($"./Media/{e}/").GetFiles())
            {
                    var t = new MultimediaFile();
                    t.Name = item.Name;
                    t.Extension = item.Extension;
                    t.type = e;
                    multimediaFiles.Add(t);
            }

            return multimediaFiles;
        }
    }
}
