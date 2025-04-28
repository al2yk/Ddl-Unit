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
            int eventId = calendarManager.CreateEvent("Встреча", 
                DateTime.Now, "Обсуждение проекта", "Деловая Встреча",
                new List<string> { "Кирилл", "Максим" }, "Карина Морозова");
            Console.WriteLine($"Создано событие с ID: {eventId}");
           
            var eventInfo = calendarManager.GetEventById(eventId);
            if (eventInfo != null)
            {
                Console.WriteLine($"Событие: {eventInfo.Title}, Дата:" +
                    $" {eventInfo.Date}, Описание: {eventInfo.Description}");
            }
            
            bool isUpdated = calendarManager.UpdateEvent(
                eventId,"Обновленная встреча обсуждения проекта", DateTime.Now.AddDays(2),
                "Обновленная встреча обсуждения проекта",
                "Деловая Встреча№2", new List<string> { "Кирилл", "Валентин", "Алексей" },
                "Олег Григорьев"
            );
            if (isUpdated)
            {
                Console.WriteLine("Событие успешно обновлено");
            }
            else
            {
                Console.WriteLine("Не удалось обновить событие");
            }
            eventInfo = calendarManager.GetEventById(eventId);
            if (eventInfo != null)
            {
                Console.WriteLine($"Событие: {eventInfo.Title}, Дата:" +
                    $" {eventInfo.Date}, Описание: {eventInfo.Description}");
            }

            // Удаляем событие
            bool isDeleted = calendarManager.DeleteEvent(eventId);
            if (isDeleted)
            {
                Console.WriteLine("Событие успешно удалено");
            }
            else
            {
                Console.WriteLine("Не удалось удалить событие");
            }
        }
    }
}
