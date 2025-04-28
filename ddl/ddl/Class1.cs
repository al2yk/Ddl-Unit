using System;
using System.Collections.Generic;
using System.Linq;

namespace ddl
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } 
        public List<string> Members { get; set; }
        public string Organizer { get; set; }
    }

    public class CalendarManager
    {
        private List<Event> events = new List<Event>();
        private int nextId = 1;
        public int CreateEvent(string title, DateTime date,
            string description, string type,
            List<string> members,
            string organizer)
        {
            var newEvent = new Event
            {
                Id = nextId++,
                Title = title,
                Date = date,
                Description = description,
                Type = type,
                Members = members,
                Organizer = organizer
            };
            events.Add(newEvent);
            return newEvent.Id;
        }

        public bool DeleteEvent(int id)
        {
            var eventToRemove = events.FirstOrDefault(e => e.Id == id);
            return eventToRemove != null && events.Remove(eventToRemove);
        }

        public bool UpdateEvent(int id, string title,
            DateTime date, string description,
            string type, List<string> members,
            string organizer)
        {
            var update = events.FirstOrDefault(e => e.Id == id);
            if (update != null)
            {
                update.Title = title;
                update.Date = date;
                update.Description = description;
                update.Type = type;
                update.Members = members;
                update.Organizer = organizer;
                return true;
            }
            return false;
        }

        public Event GetEventById(int id)
        {
            return events.FirstOrDefault(e => e.Id == id);

        }

        public List<Event> GetAllEvents()
        {
            return events;

        }

        public List<Event> GetEventsByDate(DateTime date)
        {
            return events.Where(e => e.Date.Date == date.Date).ToList();

        }

        public List<Event> GetEventsByType(string type)
        {
            return events.Where(e => e.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public int GetEventCount()
        {
            return events.Count;

        }

        public List<Event> GetEventsByMembers(string members)
        {
            return events.Where(e => e.Members.Contains(members)).ToList();

        }

        public List<Event> GetEventsByOrganizer(string organizer)
        {
            return events.Where(e => e.Organizer.Equals(organizer, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}