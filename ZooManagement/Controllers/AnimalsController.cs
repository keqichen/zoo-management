using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ZooManagement;
using ZooManagement.Models.Database;


namespace ZooManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    private readonly ILogger<AnimalsController> _logger;

    public AnimalsController(ILogger<AnimalsController> logger)
    {
        _logger = logger;
    }

    ZooManagementDbContext context = new ZooManagementDbContext();

    //endpoint1: to get the detail of an animal;
    [HttpGet]
    public  ActionResult<AnimalModel> GetAnimalInfo(int id)
    {
        return context.Animals.FirstOrDefault(i => i.Id == id);
    }

    //endpoint2: to add an animal;
    [HttpPost]
    public ActionResult<AnimalModel> AddAnimal(AddAnimalModel animal)
    {
        AnimalModel newAnimal = new AnimalModel (animal.SpeciesId,animal.Name,animal.Sex,animal.DateOfBirth,animal.DateOfAcquirement);

        context.Animals.Add(newAnimal);
        context.SaveChanges();
        return newAnimal;
    }

    //endpoint3: to get a list of all species of animal;






    
    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
