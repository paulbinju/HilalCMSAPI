using AutoMapper;
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
    public class ArticleController : BaseController
    {
        private IGenericRepository<Article> _article;
        private IGenericRepository<ArticleExtension> _articleExtension;

        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public ArticleController(IGenericRepository<Article> article, IMapper mapper, IConfiguration configuration, IGenericRepository<ArticleExtension> articleExtension)
        {
            _article = article;
            _mapper = mapper;
            this.configuration = configuration;
            _articleExtension = articleExtension;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new ArticleQuery()));

        [HttpGet("{articleID}")]
        public async Task<IActionResult> GetGetbyID(int articleID) => Ok(await Mediator.Send(new ArticleByIdQuery() { articleID = articleID }));

        [HttpGet("ByPubId/{publicationID}/{issueID}")]
        public async Task<IActionResult> ArticleByPubId(int publicationID, int issueID) => Ok(await Mediator.Send(new ArticleByPubId() { publicationID = publicationID, issueID = issueID }));


        [HttpGet("ByCategoryId/{categoryID}")]
        public async Task<IActionResult> ArticleByCategoryId(int categoryID) => Ok(await Mediator.Send(new ArticlebyCategoryIdQuery() { categoryID = categoryID }));



        [HttpGet("ByDate/{createdDay}/{createdMonth}/{createdYear}")]
        public async Task<IActionResult> ArticleTaByDate(string createdDay, string createdMonth, string createdYear) => Ok(await Mediator.Send(new ArticlesTaByDate() { createdDate = createdYear + '/' + createdMonth + '/' + createdDay }));

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<Article> Post([FromForm] ArticleDTO articleDTO)
        {

            articleDTO.CreatedDate = Convert.ToString(DateTime.Now);
            Article Article = _mapper.Map<Article>(articleDTO);
            _article.Create(Article);


            if (articleDTO.FeaturedImageURL != null)
            {
                string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value;
                string dbpath = "source\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
                string filename = Article.ArticleID + Path.GetExtension(articleDTO.FeaturedImage.FileName);
                string filewithpath = basepath + dbpath + filename;

                DirectoryInfo dir = new DirectoryInfo(basepath + dbpath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                using (FileStream fs = System.IO.File.Create(filewithpath))
                {
                    articleDTO.FeaturedImage.CopyTo(fs);
                }

                Article.FeaturedImageURL = dbpath + filename;
            }


            //if (articleDTO.FeaturedImage != null)
            //{
            //    string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
            //    string filewithpath = Path.Combine(Directory.GetCurrentDirectory(), basepath, Convert.ToString(Article.ArticleID) + Path.GetExtension(articleDTO.FeaturedImage.FileName));

            //    DirectoryInfo dir = new DirectoryInfo(basepath);
            //    if (!dir.Exists)
            //    {
            //        dir.Create();
            //    }
            //    using (FileStream fs = System.IO.File.Create(filewithpath))
            //    {
            //        articleDTO.FeaturedImage.CopyTo(fs);
            //    }
            //}
            _article.Update(Article);
            return Article;
        }

        //[HttpPost("UploadFile")]
        //public async Task<string> UploadFile([FromForm] IFormFile file)
        //{
        //    string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
        //    string filewithpath = Path.Combine(Directory.GetCurrentDirectory(), basepath, Convert.ToString(10) + ".jpg");

        //    if (file != null)
        //    {
        //        DirectoryInfo dir = new DirectoryInfo(basepath);
        //        if (!dir.Exists)
        //        {
        //            dir.Create();
        //        }
        //        using (FileStream fs = System.IO.File.Create(filewithpath))
        //        {
        //            file.CopyTo(fs);
        //        }
        //    }

        //    return file.FileName;
        //}

        // PUT api/<ArticleController>/5
        [HttpPut("{articleid}")]
        public async Task<ArticleDTO> Put([FromForm] ArticleDTO articleDTO, int articleid)
        {
            articleDTO.CreatedDate = Convert.ToString(DateTime.Now);
            Article Article = _mapper.Map<Article>(articleDTO);
            Article.ArticleID = articleid;


            if (articleDTO.FeaturedImage != null)
            {
                string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value;
                string dbpath = "source\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
                string filename = Article.ArticleID + Path.GetExtension(articleDTO.FeaturedImage.FileName);
                string filewithpath = basepath + dbpath + filename;

                DirectoryInfo dir = new DirectoryInfo(basepath + dbpath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                using (FileStream fs = System.IO.File.Create(filewithpath))
                {
                    articleDTO.FeaturedImage.CopyTo(fs);
                }

                Article.FeaturedImageURL = dbpath + filename;
            }


            _article.Update(Article);
            return articleDTO;
        }





        //DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Article article = new Article();
            article.ArticleID = id;
            _article.Delete(article);
        }
    }
}
