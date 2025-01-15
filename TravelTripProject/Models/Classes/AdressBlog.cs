﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class AdressBlog
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TheAdress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }


    }
}