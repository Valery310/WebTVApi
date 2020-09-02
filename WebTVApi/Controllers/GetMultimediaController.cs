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
        //    //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Video));
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
        public IActionResult Get(string stream, string ip)//GetVideoContent() Get([FromQuery]string stream)
        {
            //List<List<MultimediaFile>> multimediaFiles = new List<List<MultimediaFile>>();
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Video, value));
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Photo, value));
            //multimediaFiles.Add(Multimedia.GetMultimedia(Type.Document, value));
            //var r = System.Text.Json.JsonSerializer.Serialize(multimediaFiles, new JsonSerializerOptions { WriteIndented = true });
            //return Content(r);

            string path = $"./Media/{stream}/Video/Программа шифрования текста. Урок #3, C# для начинающих.mp4";

            if (System.IO.File.Exists(path))
            {
                var file = System.IO.File.Open($"./Media/{stream}/Video/Программа шифрования текста. Урок #3, C# для начинающих.mp4", FileMode.Open, FileAccess.Read, FileShare.Read);
                return new FileStreamResult(file, new MediaTypeHeaderValue("video/mp4").MediaType);
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
