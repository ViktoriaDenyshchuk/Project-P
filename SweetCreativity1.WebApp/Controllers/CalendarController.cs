using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;

namespace SweetCreativity1.WebApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IEventReposotory _eventRepository;

        public CalendarController(IEventReposotory eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IActionResult Index(int? selectedDay, int? selectedMonth, int? selectedYear)
        {
            CalendarModel model = new CalendarModel();

            if (selectedDay.HasValue && selectedMonth.HasValue && selectedYear.HasValue)
            {
                // Опціонально: Ви можете передати в модель обрану дату
                model.SelectedDay = selectedDay.Value;
                model.SelectedMonth = selectedMonth.Value;
                model.SelectedYear = selectedYear.Value;
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Відповідь для асинхронного запиту (AJAX)
                return PartialView("_CalendarPartial", model);
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                // Передайте модель події сервісу для збереження
                _eventRepository.Add(model);

                return RedirectToAction(nameof(Index));
            }

            // Логіка для обробки невірно введених даних
            return View(model);
        }


        [HttpPost]
        public IActionResult AddEvent([FromBody] Event eventData)
        {
            try
            {
                // Validate the input
                if (eventData == null || string.IsNullOrWhiteSpace(eventData.Text) || eventData.Date == default)
                {
                    return Json(new { status = "error", message = "Invalid event data." });
                }

                // Create a new event object
                var newEvent = new Event
                {
                    UserId = eventData.UserId, // You might want to validate the UserId as well
                    Date = eventData.Date,
                    Text = eventData.Text
                };

                // Add the event to the repository
                _eventRepository.Add(newEvent);

                return Json(new { status = "success", message = "Event added successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                return Json(new { error = "An error occurred while saving the entity changes." });
            }
        }





        [HttpPost]
        public IActionResult DeleteEvent(int day, int month, int year)
        {
            // Отримати подію за вказаною датою
            var eventToDelete = _eventRepository.GetEventByDate(day, month, year);

            if (eventToDelete != null)
            {
                _eventRepository.Delete(eventToDelete);
                return Json(new { status = "success", message = "Подію видалено успішно." });
            }

            return Json(new { status = "error", message = "Подію не знайдено." });
        }
        [HttpGet]
        public IActionResult GetEventsForDay(int day, int month, int year)
        {
            DateTime selectedDate = new DateTime(year, month, day);
            var eventsForDay = _eventRepository.GetEventsForDay(selectedDate);
            return Json(eventsForDay);
        }

        [HttpPost]
        public IActionResult AddNewEvent([FromBody] Event eventData)
        {
            var @event = new Event
            {
                UserId = eventData.UserId,
                Date = eventData.Date,
                Text = eventData.Text
            };

            _eventRepository.Add(@event);

            return Json(new { status = "success", message = "Нову подію додано успішно." });
        }
        [HttpGet]
        public IActionResult GetEventByDate(int day, int month, int year)
        {
            var existingEvent = _eventRepository.GetEventByDate(day, month, year);

            return Json(existingEvent);
        }


    }
    // Додайте цей клас в той же файл, де ви визначаєте ваш клас CalendarController
    //public class EventViewModel
    //{
    //    public DateTime Date { get; set; }
    //    public string Description { get; set; }
    //}

    public class CalendarModel
    {
        // Додайте нові властивості для обраної дати
        public int? SelectedDay { get; set; }
        public int? SelectedMonth { get; set; }
        public int? SelectedYear { get; set; }

        // Решта коду залишається незмінним
        // ...
    

    public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        public List<List<int?>> CalendarDays { get; set; }

        public CalendarModel()
        {
            DateTime currentDate = DateTime.Now;
            CurrentYear = currentDate.Year;
            CurrentMonth = currentDate.Month;
            CalendarDays = GenerateCalendarDays(CurrentYear, CurrentMonth);
        }

        private List<List<int?>> GenerateCalendarDays(int year, int month)
        {
            List<List<int?>> calendarDays = new List<List<int?>>();
            DateTime firstDay = new DateTime(year, month, 1);
            int startingDay = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Виправлення для коректної індексації днів тижня
            if (startingDay == 0)
            {
                startingDay = 6; // Неділя в JavaScript
            }
            else
            {
                startingDay -= 1; // Коректне відображення понеділка як початкового дня
            }

            int day = 1 - startingDay;

            for (int i = 0; i < 6; i++)
            {
                List<int?> week = new List<int?>();

                for (int j = 0; j < 7; j++)
                {
                    if (day > 0 && day <= daysInMonth)
                    {
                        week.Add(day);
                    }
                    else
                    {
                        week.Add(null);
                    }
                    day++;
                }

                calendarDays.Add(week);
            }

            return calendarDays;
        }

    }
}
