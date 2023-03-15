namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    
    public class SpeciesSearchRequest : SearchRequest
    {
        public int? SpeciesName { get; set; }
        public override string Filters => SpeciesName == null ? "" : $"&speciesName={SpeciesName}";
    }

    public class ClassificationSearchRequest : SearchRequest
    {
        public int? ClassificationName { get; set; }
        public override string Filters => ClassificationName == null ? "" : $"&classificationName ={ClassificationName}";
    }

    public class AnimalSearchRequest : SearchRequest
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Sex { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfAcquirement { get; set; }
        public override string Filters
        {
            get
            {
                var filters = "";

                if (Name != null)
                {
                    filters += $"&name={Name}";
                }
                
                if (Age != null)
                {
                    filters += $"&age={Age}";
                }
                
                if (Sex != null)
                {
                    filters += $"&sex={Sex}";
                }

                if (DateOfBirth != null)
                {
                    filters += $"&dateOfBirth={DateOfBirth}";
                }

                if (DateOfAcquirement != null)
                {
                    filters += $"&dateOfAcquirement={DateOfAcquirement}";
                }
                
                return filters;
            }
        }
    }
}