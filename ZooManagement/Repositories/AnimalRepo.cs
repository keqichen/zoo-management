using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement;

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        AnimalModel GetAnimalInfo(int id);
        AnimalModel AddAnimal(AddAnimalModel animal);
        List<SpeciesModel> GetSpeciesList();
        List<AnimalModel> GetAnimalList();
        IEnumerable<AnimalModel> Search(SearchRequest search);
        int Count();
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

        public IEnumerable<AnimalModel> Search(SearchRequest search)
        {
            return _context.Animals
                .OrderBy(p => p.Id)
                //.Where(p => search.PostedBy == null || p.UserId == search.PostedBy)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public int Count()
        {
            return _context.Animals
                .Count();
        }


    }
}