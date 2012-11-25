using System;
using System.Collections.Generic;
using AcquireLunch.Models;
using System.Web.Mvc;

namespace AcquireLunch.ViewModels
{
    public class IndexViewModel
    {
        public int SelectedPersonId { get; set; }
        public string SelectedPersonFullName { get; set; } 
        public int SelectedRestaurantId { get; set; }
        public int SelectedMenuItemId { get; set; }
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }

        public Dictionary<string, string> Names
        {
            get {
                var names = new Dictionary<string, string>();
                foreach (Person p in People)
                {
                    names.Add(p.PersonId.ToString(), p.FullName);
                }
                return names;
            }
        }

        // public SelectList PeopleSelectList = new SelectList(People)
    }
}