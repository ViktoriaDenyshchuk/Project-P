using Microsoft.AspNetCore.Mvc;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Linq;

namespace SweetCreativity1.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventReposotory _eventRepository;

        public EventController(IEventReposotory eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var events = _eventRepository.GetAll();
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                // Додайте інші необхідні дані, наприклад, UserId, якщо це залежить від вашого впровадження
                model.UserId = User.Identity.Name; // Припускаючи, що ви використовуєте ідентифікацію користувача

                _eventRepository.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var @event = _eventRepository.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost]
        public IActionResult Edit(Event model)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Update(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var @event = _eventRepository.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = _eventRepository.Get(id);

            if (@event != null)
            {
                _eventRepository.Delete(@event);
            }

            return RedirectToAction("Index");
        }
    }
}
