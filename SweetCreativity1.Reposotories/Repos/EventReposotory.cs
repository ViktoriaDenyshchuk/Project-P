using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetCreativity1.Reposotories.Repos
{
    public class EventReposotory : IEventReposotory
    {
        private SweetCreativity1Context _context;

        public EventReposotory(SweetCreativity1Context context)
        {
            _context = context;
        }

        public void Add(Event obj)
        {
            _context.Events.Add(obj);
            Save();
        }

        public void Delete(Event obj)
        {
            _context.Set<Event>().Remove(obj);
            Save();
        }

        public Event Get(string id)
        {
            return _context.Events.Find(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public IEnumerable<Event> GetEventsByUserId(string userId)
        {
            return _context.Events.Where(e => e.UserId == userId).ToList();
        }

        public void Update(Event obj)
        {
            _context.Events.Update(obj);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Event Get(int id)
        {
            throw new NotImplementedException();
        }
        public Event GetEventByDate(int day, int month, int year)
        {
            return _context.Events.FirstOrDefault(e => e.Date.Day == day && e.Date.Month == month && e.Date.Year == year);
        }

        public IEnumerable<Event> GetEventsForDay(DateTime selectedDate)
        {
            return _context.Events
                .Include(e => e.User) // Якщо вам потрібні дані користувача для подій
                .Where(e => e.Date.Date == selectedDate.Date)
                .ToList();
        }
    }
}
