using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

  public class MachinesController : Controller
  {
    private readonly SSFactoryContext _db;
    public MachinesController(SSFactoryContext db)
    {
      _db = db;
    }
  
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
  }