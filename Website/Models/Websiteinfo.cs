using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class Websiteinfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName{get;set;}
        public int Age{get;set;}
        public string Gender { get; set; }
        public string Hobbies{get;set;}
        
    }
}