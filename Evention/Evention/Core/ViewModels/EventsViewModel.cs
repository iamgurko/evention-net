﻿using System.Collections.Generic;
using System.Linq;
using Evention.Core.Models;

namespace Evention.Core.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}