using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Queries;
using UserInterface.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterDetailController : BaseController
    {

        private IGenericRepository<NewsletterDetail> _newsletterDetail;
        private IGenericRepository<Newsletter> _newsletter;

        public readonly IMapper _mapper;
        private IConfiguration configuration;

        public NewsletterDetailController(IGenericRepository<NewsletterDetail> newsletterDetail, IMapper mapper, IConfiguration configuration, IGenericRepository<Newsletter> newsletter)
        {
            _newsletterDetail = newsletterDetail;
            _mapper = mapper;
            this.configuration = configuration;
            _newsletter = newsletter;
        }

        // GET api/<NewslettersController>/5
        [HttpGet("ById/{newsletterID}")]
        public async Task<IActionResult> ById(int newsletterID) => Ok(await Mediator.Send(new NewsletterDetailsById() { NewsletterID = newsletterID }));


        // POST api/<NewletterDetailController>
        [HttpPost]
        public async Task PostAsync([FromBody] NewsletterDetail newsletterDetail)
        {
            _newsletterDetail.Create(newsletterDetail);

            Newsletter nl = await _newsletter.GetbyID(newsletterDetail.NewsletterID);
            nl.Generated = true;
            _newsletter.Update(nl);
        }

        // PUT api/<NewletterDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewletterDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
