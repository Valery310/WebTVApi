using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Globalization;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTVApi
{
    

    [Route("[controller]")]//[Route("api/[controller]")]
    [ApiController]
    public class GetMultimediaController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult Get()//GetVideoContent()
        //{
        //    List<List<MultimediaFile>> multimediaFiles = new List<List<MultimediaFile>>();
        //    //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Adv));
        //    //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Photo));
        //    //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Document));

        //    var r = System.Text.Json.JsonSerializer.Serialize(multimediaFiles, new JsonSerializerOptions { WriteIndented = true });
        //    //  var t = System.Text.Json.JsonSerializer.Serialize(multimediaLists.multimediaVideo, new JsonSerializerOptions { WriteIndented = true });
        //    //   var t1 = System.Text.Json.JsonSerializer.Deserialize<List<MultimediaFile>>(t);
        //    return Content(r);
        //}
        //[HttpGet("{stream}")]
        //[Route("[controller]/{stream}")]
        

        [HttpGet]
        public IActionResult Get(string stream, string content, string id, string ip)//GetVideoContent() Get([FromQuery]string stream)
        {
            //List<List<MultimediaFile>> multimediaFiles = new List<List<MultimediaFile>>();
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Adv, value));
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Photo, value));
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Document, value));
            //var r = System.Text.Json.JsonSerializer.Serialize(multimediaFiles, new JsonSerializerOptions { WriteIndented = true });
            //return Content(r);
            if (string.IsNullOrWhiteSpace(stream)
                && string.IsNullOrWhiteSpace(id) && string.IsNullOrWhiteSpace(content))
            {
                
                Program.multimediaFiles = new List<List<MultimediaFile>>();
                Multimedia.UpdateFiles(Program.multimediaFiles, "Stream1");
               // var r = System.Text.Json.JsonSerializer.Serialize(multimediaFiles, new JsonSerializerOptions { WriteIndented = true });
                var obj = JsonConvert.SerializeObject(Program.multimediaFiles);
                return Content(obj);
            }
            else
            {
                string name = "";
                int _id = Convert.ToInt32(id);
                foreach (var items in Program.multimediaFiles)
                {
                    foreach (var item in items)
                    {
                        if (_id==item.id)
                        {
                            name = item.Name;
                            break;
                        }
                    }
                }

                string path = $"./Media/{stream}/{content}/{name}";//Программа шифрования текста. Урок #3, C# для начинающих.mp4";
          
                if (System.IO.File.Exists(path))
                {
                    var file = System.IO.File.Open($"./Media/{stream}/{content}/{name}", FileMode.Open, FileAccess.Read, FileShare.Read);///Media/{stream}/{content}/Программа шифрования текста. Урок #3, C# для начинающих.mp4", FileMode.Open, FileAccess.Read, FileShare.Read);
                    return new FileStreamResult(file, new MediaTypeHeaderValue("video/mp4").MediaType);
                }
            }
          


            return BadRequest();
        }

        [HttpGet]
        [Route("/update")]
        public void Update(string stream, string ip)
        {
        }

        // GET: api/<GetMultimedia>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<GetMultimedia>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetMultimedia>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetMultimedia>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetMultimedia>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
