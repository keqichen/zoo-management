using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{
    public class SearchResponseModel
    {
        private readonly string _path;
      
        public IEnumerable<AnimalModel> Items { get; }
        public int TotalNumberOfItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public string NextPage => !HasNextPage() ? null : $"/{_path}?page={Page + 1}&pageNumber={PageSize}";

        public string PreviousPage => Page <= 1 ? null : $"/{_path}?page={Page - 1}&pageNumber={PageSize}";

        public SearchResponseModel(SearchRequest search, IEnumerable<AnimalModel> items, int totalNumberOfItems, string path)
        {
            Items = items;
            TotalNumberOfItems = totalNumberOfItems;
            Page = search.Page;
            PageSize = search.PageSize;
            _path = path;
        }
        
        private bool HasNextPage()
        {
            return Page * PageSize < TotalNumberOfItems;
        }
        
        public static SearchResponseModel Create(SearchRequest search, IEnumerable<AnimalModel> animals, int totalNumberOfItems)
        {
            //var animalModels = animals.Select(animal => new AnimalModel(animal.SpeciesId,animal.Name,animal.Sex,animal.DateOfBirth,animal.DateOfAcquirement));
            var animalModels = animals.ToList();
            return new SearchResponseModel(search, animalModels, totalNumberOfItems, "Animals");
        }
    }
}