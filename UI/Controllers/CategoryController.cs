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
    public class CategoryController : BaseController
    {
        private IGenericRepository<Category> _category;
        public readonly IMapper _mapper;

        public CategoryController(IGenericRepository<Category> category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }




        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new CategoryQuery()));

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _category.GetbyID(id);
        }
        [HttpGet("ByPubId/{publicationID}")]
        public async Task<IActionResult> CategoryByPubId(int publicationID) => Ok(await Mediator.Send(new CategoryByPubIdQuery() { publicationID = publicationID }));


        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDTO Categorydto)
        {
            Category cat = _mapper.Map<Category>(Categorydto);
            
            
            _category.Create(cat);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDTO Categorydto)
        {
            Category Category = _mapper.Map<Category>(Categorydto);
            Category.CategoryID = id;
            _category.Update(Category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Category category = new Category();
            category.CategoryID = id;
            _category?.Delete(category);
        }
    }
}
