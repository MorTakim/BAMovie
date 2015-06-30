using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeMVC.Models
{
    public class ModelWriter
    {
        public Writer Writer { get; set; }

        public IEnumerable<Film> Films { get; set; }
    }
}