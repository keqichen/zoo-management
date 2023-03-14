using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ZooManagement;
using ZooManagement.Models.Database;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;


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
    private readonly IAnimalRepo _animalRepo;

    public AnimalsController(ILogger<AnimalsController> logger, IAnimalRepo animalRepo)
    {
        _logger = logger;
        _animalRepo = animalRepo;
    }

    //ZooManagementDbContext context = new ZooManagementDbContext();

    [HttpGet("time")]
    public DateTime Get()
    {
        var data = DateTime.Now;
        return data;
    }

    //endpoint1: to get the detail of an animal;
    [HttpGet("animal")]
    public  ActionResult<AnimalModel> GetAnimalInfo(int id)
    {
        var animalInfo = _animalRepo.GetAnimalInfo(id);
        return animalInfo;
    }

    //endpoint2: to add an animal;
    [HttpPost]
    public ActionResult<AnimalResponseModel> AddAnimal(AddAnimalModel animal)
    {
        AnimalModel newAnimal = _animalRepo.AddAnimal(animal);
        return new AnimalResponseModel(newAnimal);
    }

    //endpoint3: to get a list of all species of animal;
    [HttpGet("species")]
    public ActionResult<List<SpeciesModel>> GetSpeciesList()
    {
        var speciesList = _animalRepo.GetSpeciesList();
        return speciesList;
    }





    
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
