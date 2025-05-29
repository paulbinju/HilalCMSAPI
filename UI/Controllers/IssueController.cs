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
    public class IssueController : BaseController
    {
        private IGenericRepository<Issue> _issue;
        public readonly IMapper _mapper;

        public IssueController(IGenericRepository<Issue> issue, IMapper mapper)
        {
            _issue = issue;
            _mapper = mapper;
        }

        // GET: api/<IssueController>
        [HttpGet("{publicationID}")]
        public async Task<IActionResult> GetAll(int publicationID) => Ok(await Mediator.Send(new IssueQuery() { PublicationID = publicationID } ));

        // GET api/<IssueController>/5
        //[HttpGet("{id}")]
        //public async Task<Issue> Get(int id)
        //{
        //    return await _issue.GetbyID(id);
        //}

        // POST api/<IssueController>
        [HttpPost]
        public void Post([FromBody] IssueDTO issuedto)
        {
            issuedto.Published = false;
            _issue.Create(_mapper.Map<Issue>(issuedto));
        }

        // PUT api/<IssueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IssueDTO issuedto)
        {
            Issue issue = _mapper.Map<Issue>(issuedto);
            issue.IssueID = id;

            if (!issuedto.Published)
            {
                issue.Published = false;
                issue.PublishDate = null;
            }
            _issue.Update(issue);
        }

        // DELETE api/<IssueController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Issue issue = new Issue();
            issue.IssueID = id;
            _issue?.Delete(issue);
        }
    }
}
