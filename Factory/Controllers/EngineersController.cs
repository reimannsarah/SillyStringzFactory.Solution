using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    public ActionResult Create()
    {
      // ViewBag.machineList = _db.Machines.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
  #nullable enable
      EngMachine? joinEntity = _db.EngMachines.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
  #nullable disable 
      if (joinEntity == null && machineId !=0)
      {
        _db.EngMachines.Add(new EngMachine() { MachineId = machineId, EngineerId = engineer.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                                          .Include(eng => eng.JoinEntities)
                                          .ThenInclude(join => join.Machine)
                                          .FirstOrDefault(eng => eng.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngMachine joinEntry = _db.EngMachines.FirstOrDefault(entry => entry.EngMachineId == joinId);
      _db.EngMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }