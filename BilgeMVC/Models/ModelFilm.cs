using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeMVC.Models
{
    public class ModelFilm
    {
        public List<Film> Films { get; set; }

        public List<Actor> Actors { get; set; }

        public List<Director> Directors { get; set; }

        public List<Writer> Writers { get; set; }

        public List<Producer> Producers { get; set; }

        public List<FilmType> FilmTypes { get; set; }
    }
}