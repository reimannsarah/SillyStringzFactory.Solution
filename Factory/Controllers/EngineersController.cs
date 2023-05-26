using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

  public class EngineersController : Controller
  {
    private readonly SSFactoryContext _db;
    public EngineersController(SSFactoryContext db)
    {
      _db = db;
    }
  
    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }
  }