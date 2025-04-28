using ddl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ddlUnit
{
    [TestClass]
    public class CalendarManagerTests
    {
        private CalendarManager calendarManager;

        [TestInitialize]
        public void Setup()
        {
            calendarManager = new CalendarManager();
        }

        [TestMethod]
        public void CreateEvent()
        {
            var calendarManager = new CalendarManager();
            var eventId = calendarManager.CreateEvent("Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Семен Еременко");
            Assert.AreEqual(1, eventId);
        }
        [TestMethod]
        public void DeleteEvent_True()
        {
            var id = calendarManager.CreateEvent("Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Семен Еременко");
            var result = calendarManager.DeleteEvent(id);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteEvent_False()
        {
            var result = calendarManager.DeleteEvent(999); //не существует
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateEvent()
        {
            var id = calendarManager.CreateEvent("Праздник", DateTime.Now, "Новый год", "Встреча на новый год", new List<string>(), "Алина Шаронова");
            var result = calendarManager.UpdateEvent(id, "Новый праздник", DateTime.Now.AddDays(1), "День рождения", "День рождения Организатора", new List<string>(), "Кирилл Васнецов");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetEventById()
        {
            var id = calendarManager.CreateEvent("Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Семен Еременко");
            var eventRetrieved = calendarManager.GetEventById(id);
            Assert.IsNotNull(eventRetrieved);
            Assert.AreEqual("Встреча", eventRetrieved.Title);
        }


        [TestMethod]
        public void GetAllEvents()
        {
            calendarManager.CreateEvent("Бизнес Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Иван Иванов");
            calendarManager.CreateEvent("Бизнес Встреча№2", DateTime.Now, "Бизнес идея№2", "Встреча по бизнес идеям№2", new List<string>(), "Петр Петров");
            var allEvents = calendarManager.GetAllEvents();
            Assert.AreEqual(2, allEvents.Count);
        }

        [TestMethod]
        public void GetEventsByDate()
        {
            var eventId1 = calendarManager.CreateEvent("Бизнес Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Иван Иванов");
            var eventId2 = calendarManager.CreateEvent("Бизнес Встреча№2", DateTime.Now, "Бизнес идея№2", "Встреча по бизнес идеям№2", new List<string>(), "Петр Петров");
            var eventsOnDate = calendarManager.GetEventsByDate(DateTime.Now);
            Assert.AreEqual(2, eventsOnDate.Count);
            Assert.AreEqual(eventId1, eventsOnDate[0].Id);
        }

        [TestMethod]
        public void GetEventCount()
        {
            calendarManager.CreateEvent("Бизнес Встреча", DateTime.Now, "Бизнес идея", "Встреча по бизнес идеям", new List<string>(), "Иван Иванов");
            calendarManager.CreateEvent("Бизнес Встреча№2", DateTime.Now, "Бизнес идея№2", "Встреча по бизнес идеям№2", new List<string>(), "Петр Петров");
            var count = calendarManager.GetEventCount();
            Assert.AreEqual(2, count);
        }
    }
}


