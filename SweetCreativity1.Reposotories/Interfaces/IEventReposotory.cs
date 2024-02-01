
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Interfaces
{
    public interface IEventReposotory : ISave
    {
        Event Get(int id);
        IEnumerable<Event> GetAll();
        void Add(Event obj);
        void Update(Event obj);
        void Delete(Event obj);
        IEnumerable<Event> GetEventsByUserId(string userId);
        Event GetEventByDate(int day, int month, int year);
        IEnumerable<Event> GetEventsForDay(DateTime selectedDate);

    }

}