using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{
    public class SearchResponseModel
    {
        private readonly string _path;
        private readonly string _filters;
        public IEnumerable<AnimalModel> Items { get; }
        public int TotalNumberOfItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public string NextPage => !HasNextPage() ? null : $"/{_path}?page={Page + 1}&pageNumber={PageSize}{_filters}";

        public string PreviousPage => Page <= 1 ? null : $"/{_path}?page={Page - 1}&pageNumber={PageSize}{_filters}";

        public SearchResponseModel(SearchRequest search, IEnumerable<AnimalModel> items, int totalNumberOfItems, string path)
        {
            Items = items;
            TotalNumberOfItems = totalNumberOfItems;
            Page = search.Page;
            PageSize = search.PageSize;
            _path = path;
            _filters = search.Filters;
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

    // public class PostListResponse : ListResponse<PostResponse>
    // {
    //     private PostListResponse(SearchRequest search, IEnumerable<PostResponse> items, int totalNumberOfItems) 
    //         : base(search, items, totalNumberOfItems, "posts") { }

    //     public static PostListResponse Create(SearchRequest search, IEnumerable<Post> posts, int totalNumberOfItems)
    //     {
    //         var postModels = posts.Select(post => new PostResponse(post));
    //         return new PostListResponse(search, postModels, totalNumberOfItems);
    //     }
    // }
    
    // public class UserListResponse : ListResponse<UserResponse>
    // {
    //     private UserListResponse(SearchRequest search, IEnumerable<UserResponse> items, int totalNumberOfItems) 
    //         : base(search, items, totalNumberOfItems, "users") { }
        
    //     public static UserListResponse Create(SearchRequest search, IEnumerable<User> users, int totalNumberOfItems)
    //     {
    //         var userModels = users.Select(user => new UserResponse(user));
    //         return new UserListResponse(search, userModels, totalNumberOfItems);
    //     }
    // }
    
    // public class InteractionListResponse : ListResponse<InteractionResponse>
    // {
    //     private InteractionListResponse(SearchRequest search, IEnumerable<InteractionResponse> items, int totalNumberOfItems) 
    //         : base(search, items, totalNumberOfItems, "interactions") { }
        
    //     public static InteractionListResponse Create(SearchRequest search, IEnumerable<Interaction> interactions, int totalNumberOfItems)
    //     {
    //         var interactionModels = interactions.Select(i => new InteractionResponse(i));
    //         return new InteractionListResponse(search, interactionModels, totalNumberOfItems);
    //     }
    // }
}