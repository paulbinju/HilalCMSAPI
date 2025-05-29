using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Command;
using Services.DTO;
using Services.Interface;
using Services.Queries;
using System.Configuration;
using UserInterface.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private IConfiguration configuration;

        public EventController(IMapper mapper, IGenericRepository<Event> eventRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            this.configuration = configuration; 
        }
        // GET: api/<EventController>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new EventGetAllCommand()));

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromForm] EventDTO eventDTO)
        {
            eventDTO.CreatedDate = DateTime.UtcNow;
            eventDTO.Active = true;
            Event _event = _mapper.Map<Event>(eventDTO);
            _eventRepository.Create(_event);

            if (eventDTO.EventImageFile != null)
            {
                string basepath = configuration.GetSection("FolderPaths").GetSection("sourcefolder").Value;
                string dbpath = "events\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\";
                string filename = _event.EventID + Path.GetExtension(eventDTO.EventImageFile.FileName);
                string filewithpath = basepath + dbpath + filename;

                DirectoryInfo dir = new DirectoryInfo(basepath + dbpath);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                using (FileStream fs = System.IO.File.Create(filewithpath))
                {
                    eventDTO.EventImageFile.CopyTo(fs);
                }

                _event.EventImage = dbpath + filename;
            }
            _eventRepository.Update(_event);

        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Event eventd = new Event();
            eventd.EventID = id;
            _eventRepository.Delete(eventd);
        }
    }
}
