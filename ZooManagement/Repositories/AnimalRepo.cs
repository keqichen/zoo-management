using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement;

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        AnimalModel GetAnimalInfo(int id);
        AnimalModel AddAnimal(AddAnimalModel animal);
        List<SpeciesModel> GetSpeciesList();
        List<AnimalModel> GetAnimalList();
        IEnumerable<AnimalResponseModel> Search(SearchRequest search);
        int Count(List<AnimalResponseModel> animals);
    }

    public class AnimalRepo : IAnimalRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public AnimalModel GetAnimalInfo(int id)
        {
            return _context.Animals.FirstOrDefault(i => i.Id == id);
        }

        // public ClassificationModel AddClassification (AddClassificationModel classification)
        // {
        //     ClassificationModel newClassification = new ClassificationModel(classification.Name);
        //     _context.Classifications.Add(newClassification);
        //     _context.SaveChanges();
        //     return newClassification;
        // }

        // public SpeciesModel AddSpecies (string name, int id)
        // {
        //     SpeciesModel newSpecies = new SpeciesModel(name,id);
        //     _context.Species.Add(newSpecies);
        //     _context.SaveChanges();
        //     return newSpecies;
        // }


        public AnimalModel AddAnimal(AddAnimalModel animal)
        {
            // check whether the species id/classfication id exists;
            // if (!animal.SpeciesId)
            // {
            //     AddSpecies();
            // }

            AnimalModel newAnimal = new AnimalModel(animal.SpeciesId, animal.Name, animal.Sex, DateTime.Parse(animal.DateOfBirth), DateTime.Parse(animal.DateOfAcquirement));
            _context.Animals.Add(newAnimal);
            _context.SaveChanges();
            return newAnimal;
        }

        public List<SpeciesModel> GetSpeciesList()
        {
            return _context.Species.ToList();
        }

        public List<AnimalModel> GetAnimalList()
        {
            return _context.Animals.ToList();
        }

        // EF can't recognise your own methods;
        // public static int AgeConverter (DateTime dateOfBirth)
        // {
        //     int age = DateTime.Now.Year-dateOfBirth.Year;
        //     return age+1;
        // }

//one search method;
        public IEnumerable<AnimalResponseModel> Search(SearchRequest search)
        {
            
            return _context.Animals
                //search classification;
                .Where(p => search.ClassificationName == null ||
                                (
                                    p.Species.Classification.Name.ToLower().Contains(search.ClassificationName) 
                                    
                                ))
                //search species;
                .Where(p => search.SpeciesName == null ||
                                    (
                                        p.Species.Name.ToLower().Contains(search.SpeciesName) 
                                    ))
                //search animals;
                .Where(p => search.AnimalName == null ||
                                    (
                                        p.Name.ToLower().Contains(search.AnimalName) 
                                    ))
                .Where(p => search.Age == null ||
                                    (
                                        search.Age==(DateTime.Now.Year-p.DateOfBirth.Year)+1
                                    ))
            
                .Where(p => search.Sex == null ||
                                    (
                                        search.Sex==p.Sex
                                    ))
                .Where(p => search.DateOfAcquirement == null ||
                                    (
                                        DateTime.Parse(search.DateOfAcquirement)==p.DateOfAcquirement
                                    ))
                
                .Include(p=>p.Species)
                    .ThenInclude(s=>s.Classification)
                .Select(x => new AnimalResponseModel (x)) 
                .AsEnumerable()
                .OrderBy(p => p.Id)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public int Count(List<AnimalResponseModel> animals)
        {
            return animals
                .Count();
        }
    }
}