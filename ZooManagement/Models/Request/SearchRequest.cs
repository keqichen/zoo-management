namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        //page;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        //species;
        private string _speciesName;
        public string? SpeciesName
        { 
            get=>_speciesName?.ToLower();
            set=>_speciesName=value; }

        //classification;
        private string _classificationName;
        public string? ClassificationName
        { 
            get=>_classificationName?.ToLower();
            set=>_classificationName=value; 
        }

        //animal;
        public string? AnimalName { get; set; }
        public int? Age { get; set; }
        public string? Sex { get; set; }
        public string? DateOfAcquirement { get; set; }

    }
}