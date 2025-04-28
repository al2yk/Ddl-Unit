using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddl;
namespace ddlapp
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarManager calendarManager = new CalendarManager();
            int eventId = calendarManager.CreateEvent("Встреча", DateTime.Now, "Обсуждение проекта", "встреча", new List<string> { "Alice", "Bob" }, "John Doe");
            Console.WriteLine($"Создано событие с ID: {eventId}");
           
            var eventInfo = calendarManager.GetEventById(eventId);
            if (eventInfo != null)
            {
                Console.WriteLine($"Событие: {eventInfo.Title}, Дата: {eventInfo.Date}, Описание: {eventInfo.Description}");
            }
        }
    }
}
