using System.Collections.Generic;
using System.Web.Mvc;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace WebApplication1.Controllers
{
    public class FirmController : Controller
    {
        private readonly IServiceFirm _serviceFirm;

        public FirmController(IServiceFirm serviceFirm)
        {
            _serviceFirm = serviceFirm;
        }

        public IEnumerable<Firm> GetAllFirms()
        {
            return _serviceFirm.GetAll();
        }

        public Firm GetFirm()
        {
            return _serviceFirm.GetById(1);
        }

        public void InsertFirm()
        {
            var firm = new Firm();
            firm.City = "İstanbul";
            firm.Name = "CatTech";

            _serviceFirm.Insert(firm);
        }

        public void UpdateFirm()
        {
            var firm = _serviceFirm.GetById(1);
            firm.City = "Ankara";
            _serviceFirm.Update(firm);
        }
    }
}