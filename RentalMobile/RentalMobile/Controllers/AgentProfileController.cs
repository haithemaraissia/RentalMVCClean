﻿using System.Web.Mvc;
using RentalMobile.Helpers;
using RentalMobile.Model.Models;

namespace RentalMobile.Controllers
{
    public class AgentProfileController : Controller
    {
        private readonly RentalContext _db = new RentalContext();


        public ViewResult Index(int id)
        {
            var agent = _db.Agents.Find(UserHelper.GetAgentId(id));
            ViewBag.agentProfile = agent;
            ViewBag.agentId = agent.AgentId;
            ViewBag.agentGoogleMap = agent.GoogleMap;
            return View(agent);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
