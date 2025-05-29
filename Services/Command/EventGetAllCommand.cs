using Domain.Models;
using MediatR;
using Services.Interface;
using System.Collections.Generic;


namespace Services.Command
{
    public class EventGetAllCommand : IRequest<IList<Event>>
    {
    }
    public class EventGetAllCommandHandler : IRequestHandler<EventGetAllCommand, IList<Event>>
    {
        private readonly IGenericRepository<Event> _event;

        public EventGetAllCommandHandler(IGenericRepository<Event> events)
        {
            _event = events;
        }
        public async Task<IList<Event>> Handle(EventGetAllCommand request, CancellationToken cancellationToken)
        {
            IList<Event> events = (await _event.GetAll()).OrderByDescending(x => x.EventID).ToList();
            return events;
        }
    }
}