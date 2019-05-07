using Microsoft.AspNetCore.Mvc;
using Animal.Models;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace Animal.Controllers
{
  public class FurballsController : Controller
  {

    // [HttpGet("/world/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Counter counter = Counter.Find(id);
    //   return View(counter);
    // }

    [HttpGet("/Furballs/")]
    public ActionResult Index()
    {
        List<Furballs> allCounters = Furballs.GetAll("breed");
        return View(allCounters);
    }

    [HttpGet("/Furballs/date")]
    public ActionResult DateSort()
    {
        List<Furballs> allCounters = Furballs.GetAll("date_of_admittance");
        return View("Index",allCounters);
    }
    [HttpGet("/Furballs/new")]
    public ActionResult New()
    {

        return View();
    }
    [HttpPost("/Furballs/")]
    public ActionResult Create(string type, string name, string breed, string sex)
    {
      Furballs newAnimal = new Furballs();
      newAnimal.SetType(type);
      newAnimal.SetName(name);
      newAnimal.SetBreed(breed);
      newAnimal.SetSex(sex.ToCharArray()[0]);
      Furballs.AddToDB(newAnimal);
      return RedirectToAction("Index");

    }

    // [HttpPost("/game")]
    // public ActionResult Create(string compare, string to)
    // {
    //     if(Regex.IsMatch(compare, @"^[a-zA-Z]+$") == true)
    //     {
    //       Counter theCounter = new Counter(compare, to);
    //     }
    //     return RedirectToAction("Index");
    // }

  }
}
