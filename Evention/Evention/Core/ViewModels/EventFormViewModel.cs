﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using Evention.Controllers;
using Evention.Core.Models;

namespace Evention.Core.ViewModels
{
    public class EventFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Yer")]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        [Display(Name = "Tarih")]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        [Display(Name = "Zaman")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Tür")]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        
        public string Heading { get; set; }
        
        public string Action
        {
            get
            {
                Expression<Func<EventsController, ActionResult>> update = 
                    (c => c.Update(this));

                Expression<Func<EventsController, ActionResult>> create = 
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}