
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Repos
{
    internal class EventNoSQLRepository : IEventReposotory
    {
        public void Add(Event obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event obj)
        {
            throw new NotImplementedException();
        }

        public Event Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEventsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Event obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        public Event GetEventByDate(int day, int month, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEventsForDay(DateTime selectedDate)
        {
            throw new NotImplementedException();
        }
    }
}