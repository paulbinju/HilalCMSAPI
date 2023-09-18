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
    public class SubCategoryController : BaseController
    {
        private IGenericRepository<SubCategory> _SubCategory;
        public readonly IMapper _mapper;

        public SubCategoryController(IGenericRepository<SubCategory> SubCategory, IMapper mapper)
        {
            _SubCategory = SubCategory;
            _mapper = mapper;
        }




        // GET: api/<SubCategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new SubCategoryQuery()));

        // GET api/<SubCategoryController>/5
        [HttpGet("{id}")]
        public async Task<SubCategory> Get(int id)
        {
            return await _SubCategory.GetbyID(id);
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        public void Post([FromBody] SubCategoryDTO SubCategorydto)
        {
            SubCategory cat = _mapper.Map<SubCategory>(SubCategorydto);
            
            
            _SubCategory.Create(cat);
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SubCategoryDTO SubCategorydto)
        {
            SubCategory SubCategory = _mapper.Map<SubCategory>(SubCategorydto);
            SubCategory.SubCategoryID = id;
            _SubCategory.Update(SubCategory);
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            SubCategory SubCategory = new SubCategory();
            SubCategory.SubCategoryID = id;
            _SubCategory?.Delete(SubCategory);
        }
    }
}
