using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using Services.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private IGenericRepository<User> _user;
        
        private IGenericRepository<Lookup> _lookup;

        public readonly IMapper _mapper;
        public UserController(IGenericRepository<User> user, IMapper mapper, IGenericRepository<Lookup> lookup)
        {
            _user = user;
            _lookup = lookup;
            _mapper = mapper;   
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new UserQuery()));


        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserDTO userDTO) => Ok(await Mediator.Send(new UserCheckQuery() { EmailID = userDTO.EmailID, Password = userDTO.Password }));

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _user.GetbyID(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async void Post([FromBody] UserDTO userdto)
        {
           _user.Create(_mapper.Map<User>(userdto));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO userdto)
        {
            User user = _mapper.Map<User>(userdto);
            user.UserID = id;
            _user.Update(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            User user = new User();
            user.UserID = id;
            _user.Delete(user);   
        }
    }
}
