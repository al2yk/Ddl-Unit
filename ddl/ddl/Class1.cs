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
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(int id, string title,
            DateTime date, string description,
            string type, List<string> members,
            string organizer)
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int id)
        {
            throw new NotImplementedException();

        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();

        }

        public List<Event> GetEventsByDate(DateTime date)
        {
            throw new NotImplementedException();

        }

        public List<Event> GetEventsByType(string type)
        {
           throw new NotImplementedException();
        }

        public int GetEventCount()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventsByMembers(string members)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventsByOrganizer(string organizer)
        {
            throw new NotImplementedException();
        }
    }
}