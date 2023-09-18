using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.DTO;
using Services.Implementation;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private IGenericRepository<Lookup> _lookup;

        public readonly IMapper _mapper;
        public LookupController(IGenericRepository<Lookup> lookup, IMapper mapper)
        {
            this._lookup = lookup;  
            this._mapper = mapper;  
        }
        
        [HttpGet]
        public async Task<IEnumerable<Lookup>> GetAll()
        {
            return await _lookup.GetAll();
        }

        // GET api/<LookupController>/5
        [HttpGet("{id}")]
        public async Task<Lookup> Get(int id)
        {
            return await _lookup.GetbyID(id);
        }

      
        // POST api/<LookupController>
        [HttpPost]
        public void Post([FromBody] LookupDTO lookupdto)
        {
            _lookup.Create(_mapper.Map<Lookup>(lookupdto));
            
        }

        // PUT api/<LookupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LookupDTO lookupdto)
        {
            Lookup lookup = _mapper.Map<Lookup>(lookupdto);
            lookup.LookupID = id;
            _lookup.Update(lookup);
        }

        // DELETE api/<LookupController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Lookup lookup = await _lookup.GetbyID(id);
            _lookup.Delete(lookup);
        }
    }
}
