using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Queries;
using System.Text;
using UserInterface.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewslettersController : BaseController
    {
        private IGenericRepository<Newsletter> _newsletter;
        public readonly IMapper _mapper;
        private IConfiguration configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewslettersController(IGenericRepository<Newsletter> newsletter, IMapper mapper, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _newsletter = newsletter;
            _mapper = mapper;
            this.configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<NewslettersController>

        [HttpGet("{publicationID}")]
        public async Task<IActionResult> GetAll(int publicationID) => Ok(await Mediator.Send(new NewsletterQuery() { PublicationID = publicationID }));


        // GET api/<NewslettersController>/5
        [HttpGet("ById/{newsletterID}")]
        public async Task<IActionResult> ById(int newsletterID) => Ok(await Mediator.Send(new NewsletterById() { NewsletterID = newsletterID }));



        // POST api/<NewslettersController>
        [HttpPost]
        public void Post([FromBody] Newsletter newsletter)
        {
            _newsletter.Create(newsletter);
        }

        // PUT api/<NewslettersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewslettersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            

            Newsletter nl = new Newsletter();
            nl.NewsletterID = id;
            _newsletter?.Delete(nl);
        }

        [HttpGet("DownloadNl/{pub}/{newsletterID}")]
        public async Task<IActionResult> DownloadNl(string pub, int newsletterID)
        {
            string rootPath = _webHostEnvironment.ContentRootPath;
            string templatefile = Path.Combine(rootPath, "Newsletter\\" + pub + ".html");
            string htmlbody = System.IO.File.ReadAllText(templatefile);
            


           IList<NewsletterDetailDTO> nl = await Mediator.Send(new NewsletterDetailsById() { NewsletterID = newsletterID });


            foreach (var n in nl)
            {
            htmlbody = htmlbody.Replace("##topstoryTitle##",n.ArticleTitle);
                htmlbody = htmlbody.Replace("##topstoryDesc##", n.ArticleTitle);

                //  htmlbody = htmlbody.Replace("##businessdescription1##", n.);
            }


            byte[] bytes = Encoding.ASCII.GetBytes(htmlbody);
            return File(bytes, "text/plain", pub + "_" + DateTime.Now.ToShortDateString().Replace(" ", "") + ".html");
        }
        
        
    }
}
