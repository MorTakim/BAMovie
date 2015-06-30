using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace BilgeMVC.Models
{
    public class ModelProducer
    {
        public List<Producer> Producers  { get; set; }
        public List<Film> Films { get; set; }
    }
}