using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Command;
using Services.DTO;
using Services.Interface;
using Services.Queries;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : BaseController
    {
        private IGenericRepository<Article> _article;
        private IGenericRepository<ArticleExtension> _articleExtension;
        private IGenericRepository<ArticleCategory> _articleCategory;
        private IGenericRepository<ArticleSubCategory> _articleSubcategory;

        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public ArticleController(IGenericRepository<Article> article, IMapper mapper, IConfiguration configuration, IGenericRepository<ArticleExtension> articleExtension
            , IGenericRepository<ArticleCategory> articleCategory, IGenericRepository<ArticleSubCategory> articleSubCategory)
        {
            _article = article;
            _mapper = mapper;
            this.configuration = configuration;
            _articleExtension = articleExtension;
            _articleCategory = articleCategory;
            _articleSubcategory = articleSubCategory;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new ArticleQuery()));

        [HttpGet("{articleID}")]
        public async Task<IActionResult> GetGetbyID(int articleID) => Ok(await Mediator.Send(new ArticleByIdQuery() { articleID = articleID }));

        [HttpGet("ByPubId/{publicationID}/{issueID}")]
        public async Task<IActionResult> ArticleByPubId(int publicationID, int issueID) => Ok(await Mediator.Send(new ArticleByPubId() { publicationID = publicationID, issueID = issueID }));


        [HttpGet("ByCategoryId/{categoryID}")]
        public async Task<IActionResult> ArticleByCategoryId(int categoryID) => Ok(await Mediator.Send(new ArticleByCategoryIdQuery() { categoryID = categoryID }));



        [HttpGet("ByDate/{createdDay}/{createdMonth}/{createdYear}")]
        public async Task<IActionResult> ArticleTaByDate(string createdDay, string createdMonth, string createdYear) => Ok(await Mediator.Send(new ArticlesTaByDate() { createdDate = createdYear + '/' + createdMonth + '/' + createdDay }));

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<Article> Post([FromForm] ArticleDTO articleDTO)
        {

            articleDTO.CreatedDate = Convert.ToString(DateTime.Now);
            Article Article = _mapper.Map<Article>(articleDTO);
            _article.Create(Article);

            string[] catAry = articleDTO.CategoryID.Split(",");
            if (catAry.Length > 0)
            {
                foreach (string cid in catAry)
                {
                    ArticleCategory ac = new ArticleCategory();
                    ac.ArticleID = Article.ArticleID;
                    ac.CategoryID = Convert.ToInt32(cid);
                    _articleCategory.Create(ac);
                }
            }
            string[] subCatAry = articleDTO.SubCategoryID.Split(",");
            if (catAry.Length > 0)
            {
                foreach (string scid in subCatAry)
                {
                    ArticleSubCategory asc = new ArticleSubCategory();
                    asc.ArticleID = Article.ArticleID;
                    asc.SubCategoryID = Convert.ToInt32(scid);
                    _articleSubcategory.Create(asc);
                }
            }

            // saving to   Azure blobcontainer.
            //if (articleDTO.FeaturedImageURL != null)
            //{
            //    string blobstoragestring = "DefaultEndpointsProtocol=https;AccountName=hilalimages;AccountKey=uV0jNFWmkuUNKeLnWdICr4kF2qNevRNJSgc3dMolvIAKHIrZYi3azPFLYTm4SIy1hzOqvUjcCo+u+ASt4gV9Mg==;EndpointSuffix=core.windows.net";
            //    string containername = "hilalcmsimages";
            //    var container = new BlobContainerClient(blobstoragestring, containername);
            //    string dbpath = "source\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
            //    string filename = Article.ArticleID + Path.GetExtension(articleDTO.FeaturedImage.FileName);
            //    string filewithpath = dbpath + filename;

            //    var blob = container.GetBlobClient(filewithpath);
            //    IFormFile fl = articleDTO.FeaturedImage;
            //    FileStream fs = new FileStream(articleDTO.FeaturedImage.FileName, FileMode.Create, FileAccess.ReadWrite);
            //    fl.CopyTo(fs);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    await blob.UploadAsync(fs);
            //    Article.FeaturedImageURL = dbpath + filename;
            //}

            // save to IIS folder
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
            Article Article = _mapper.Map<Article>(articleDTO);
            Article.ArticleID = articleid;

            Mediator.Send(new ArticleCategoriesDelCommand() { ArticleID = articleid });
            Mediator.Send(new ArticleSubCategoriesDelCommand() { ArticleID = articleid });

            string[] catAry = articleDTO.CategoryID.Split(",");
            if (catAry.Length > 0)
            {
                foreach (string cid in catAry)
                {
                    ArticleCategory ac = new ArticleCategory();
                    ac.ArticleID = Article.ArticleID;
                    ac.CategoryID = Convert.ToInt32(cid);
                    _articleCategory.Create(ac);
                }
            }
            string[] subCatAry = articleDTO.SubCategoryID.Split(",");
            if (catAry.Length > 0)
            {
                foreach (string scid in subCatAry)
                {
                    ArticleSubCategory asc = new ArticleSubCategory();
                    asc.ArticleID = Article.ArticleID;
                    asc.SubCategoryID = Convert.ToInt32(scid);
                    _articleSubcategory.Create(asc);
                }
            }

            //if (articleDTO.FeaturedImage != null)
            //{
            //    string blobstoragestring = "DefaultEndpointsProtocol=https;AccountName=hilalimages;AccountKey=uV0jNFWmkuUNKeLnWdICr4kF2qNevRNJSgc3dMolvIAKHIrZYi3azPFLYTm4SIy1hzOqvUjcCo+u+ASt4gV9Mg==;EndpointSuffix=core.windows.net";
            //    string containername = "hilalcmsimages";
            //    var container = new BlobContainerClient(blobstoragestring, containername);
            //    string dbpath = "source\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
            //    string filename = Article.ArticleID + Path.GetExtension(articleDTO.FeaturedImage.FileName);
            //    string filewithpath = dbpath + filename;


            //    var blob = container.GetBlobClient(filewithpath);
            //    IFormFile fl = articleDTO.FeaturedImage;
            //    FileStream fs = new FileStream(articleDTO.FeaturedImage.FileName, FileMode.Create, FileAccess.ReadWrite);
            //    fl.CopyTo(fs);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    await blob.UploadAsync(fs);

            //    //var blob = container.GetBlobClient(filewithpath);
            //    //FileStream fs = System.IO.File.Create(filename);

            //    //if (Path.GetExtension(articleDTO.FeaturedImage.FileName) == ".png")
            //    //{
            //    //    contentType = "image/png";
            //    //}
            //    //else
            //    //{
            //    //    contentType = "image/jpeg";
            //    //}

            //    //BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders
            //    //{
            //    //    ContentType = contentType
            //    //};

            //    //await blob.UploadAsync(fs, blobHttpHeaders);

            //    Article.FeaturedImageURL = dbpath + filename;
            //}

            // save to IIS folder
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

            if (Article.Published == true) {
                    //var mail = new MailMessage();
                    //var client = new System.Net.Mail.SmtpClient("mail.smtp2go.com", 587) //Port 8025, 587 and 25 can also be used.
                    //{
                    //    Credentials = new NetworkCredential("binju.paul@tradearabia.net", "niegR6mxALOHRiKQ"),
                    //    EnableSsl = true
                    //};
                    //mail.From = new MailAddress("binju.paul@tradearabia.net", "HILAL CMS");
                    //mail.To.Add(Article.PREmails);
                    //mail.Subject = "Tradearabia Article Published";
                    //var plainView = AlternateView.CreateAlternateViewFromString("Your article has been successfully published in Tradearabia.", null, "text/plain");
                    //var htmlView = AlternateView.CreateAlternateViewFromString("Dear Sir / Madam, <p>Your article has been successfully published in Tradearabia.</p><p>Click <a href='https://www.tradearabia.com/news/" + Article.ArticleID + ".html'>here</a> to view the article.</p>", null, "text/html");
                    //mail.AlternateViews.Add(plainView);
                    //mail.AlternateViews.Add(htmlView);
                    //client.Send(mail);
            }
            else
            {
                Article.PublishedDate = null;
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
