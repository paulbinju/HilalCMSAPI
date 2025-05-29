using AutoMapper;
using Azure.Storage.Blobs;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleExtensionController : BaseController
    {
        private IGenericRepository<ArticleExtension> _articleExtension;
        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public ArticleExtensionController(IGenericRepository<ArticleExtension> articleExtension, IMapper mapper, IConfiguration configuration)
        {
            _articleExtension = articleExtension;
            _mapper = mapper;
            this.configuration = configuration;
        }

        // GET: api/<ArticleExtensionController>
        [HttpGet]
        public async Task<IEnumerable<ArticleExtension>> GetAll()
        {
            return await _articleExtension.GetAll();
        }

        [HttpGet("{ArticleID}")]
        public async Task<IActionResult> GetAllbyArticleID(int ArticleID) => Ok(await Mediator.Send(new ArticleExtensionQuery() { ArticleID = ArticleID }));


        //[HttpGet("{id}")]
        //public async Task<ArticleExtension> Get(int id)
        //{
        //    return await _articleExtension.GetbyID(id);
        //}

        // POST api/<ArticleExtensionController>
        //[HttpPost]
        //public void Post([FromBody] ArticleExtensionDTO ArticleExtensiondto)
        //{
        //    var isu = _mapper.Map<ArticleExtension>(ArticleExtensiondto);
        //    _articleExtension.Create(isu);
        //}


        [HttpPost]
        public async Task<ArticleExtensionDTO> Post([FromForm] ArticleExtensionDTO articleExtensionDTO)
        {
            if (articleExtensionDTO.TextContent == null)
            {
                articleExtensionDTO.TextContent = "";
            }
            var isu = _mapper.Map<ArticleExtension>(articleExtensionDTO);
            var articlextension = _articleExtension.Create(isu);


            //if (articleExtensionDTO.imageURL != null)
            //{
            //    string blobstoragestring = "DefaultEndpointsProtocol=https;AccountName=hilalimages;AccountKey=uV0jNFWmkuUNKeLnWdICr4kF2qNevRNJSgc3dMolvIAKHIrZYi3azPFLYTm4SIy1hzOqvUjcCo+u+ASt4gV9Mg==;EndpointSuffix=core.windows.net";
            //    string containername = "hilalcmsimages";
            //    var container = new BlobContainerClient(blobstoragestring, containername);

            //    string dbpath = "source/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
            //    string filename = "ext-" + Convert.ToString(articlextension.ArticleExtensionID) + Path.GetExtension(articleExtensionDTO.imageURL.FileName);
            //    string filewithpath = dbpath + filename;
            //    var blob = container.GetBlobClient(filewithpath);
            //    IFormFile fl = articleExtensionDTO.imageURL;
            //    FileStream fs = new FileStream(articleExtensionDTO.imageURL.FileName, FileMode.Create, FileAccess.ReadWrite);
            //    fl.CopyTo(fs);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    long fslen = fs.Length;
            //    await blob.UploadAsync(fs);

            //    isu.MediaURL = dbpath + filename;

            //}


            /* save to IIS folder*/

            if (articleExtensionDTO.imageURL != null)
            {
                string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value;
                string dbpath = "source\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
                string filename = "ext-" + Convert.ToString(articlextension.ArticleExtensionID) + Path.GetExtension(articleExtensionDTO.imageURL.FileName);
                string filewithpath = basepath + dbpath + filename;
                

                DirectoryInfo dir = new DirectoryInfo(basepath + dbpath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                using (FileStream fs = System.IO.File.Create(filewithpath))
                {
                    articleExtensionDTO.imageURL.CopyTo(fs);
                }

                isu.MediaURL = dbpath + filename;
             articleExtensionDTO.TextContent = "";
            }
            
            if (articleExtensionDTO.ArticleExtensionTypeID == 17)
            {
                isu.MediaURL = articleExtensionDTO.MediaURL.Replace("https://www.youtube.com/watch?v=", "https://www.youtube-nocookie.com/embed/");
            }


            _articleExtension.Update(isu);

            return articleExtensionDTO;
        }


        private FileStream ConvertIFormFileToStream(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid or empty file.", nameof(file));
            }

            // Create a MemoryStream and copy the data from the IFormFile into it
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Create a FileStream from the MemoryStream
                // You can specify FileMode, FileAccess, and FileShare options here as needed
                FileStream fileStream = new FileStream("path-to-save-file-on-disk", FileMode.Create, FileAccess.Write);

                // Copy the data from the MemoryStream to the FileStream
                memoryStream.CopyTo(fileStream);

                // You can optionally seek back to the beginning of the FileStream
                fileStream.Seek(0, SeekOrigin.Begin);

                return fileStream;
            }
        }




        // PUT api/<ArticleExtensionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ArticleExtensionDTO ArticleExtensiondto)
        {
            ArticleExtension ArticleExtension = _mapper.Map<ArticleExtension>(ArticleExtensiondto);
            ArticleExtension.ArticleExtensionID = id;
            _articleExtension.Update(ArticleExtension);
        }

        // DELETE api/<ArticleExtensionController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            ArticleExtension ArticleExtension = new ArticleExtension();
            ArticleExtension.ArticleExtensionID = id;
            //await _articleExtension.GetbyID(id);
            _articleExtension.Delete(ArticleExtension);
        }
    }
}
