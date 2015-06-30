using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace BilgeMVC.Models
{
    public class ModelActor
    {
        public List<Actor> Actors  { get; set; }
        public List<Film> Films { get; set; }
    }
}