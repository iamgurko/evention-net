﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Evention.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Event Event { get; private set; }

        protected Notification()
        {
        }

        private Notification(NotificationType type, Event @event)
        {
            if (@event == null)
                throw new ArgumentNullException("event");

            Type = type;
            Event = @event;
            DateTime = DateTime.Now;
        }

        public static Notification EventCreated(Event @event)
        {
            return new Notification(NotificationType.EventCreated, @event);
        }

        public static Notification EventUpdated(Event newEvent, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.EventUpdated, newEvent);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            
            return notification;
        }

        public static Notification EventCanceled(Event @event)
        {
            return new Notification(NotificationType.EventCanceled, @event);
        }
    }
}