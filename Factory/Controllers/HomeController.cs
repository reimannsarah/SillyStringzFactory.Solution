using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

  public class HomeController : Controller
  {
    private readonly SSFactoryContext _db;

    public HomeController(SSFactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Engineer> engineers = _db.Engineers.ToList();
      List<Machine> machines = _db.Machines.ToList();
      ViewBag.engineers = engineers;
      ViewBag.machines = machines;
      return View();
    }
  }