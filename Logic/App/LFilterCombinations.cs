using Entities.App;

namespace Logic.App
{
    public static class FilterCombinations
    {
        public static List<string> GetCombinations(ProductPaginatedParams op)
        {
            var combinations = new List<string>();

            if (op.PriceMin != null || op.PriceMax != null)
                combinations.Add("PriceRange");

            if (op.Review != null)
                combinations.Add("Review");

            if (op.CategoryIds != null)
                combinations.Add("Category");

            if (op.FeatureIds != null)
                combinations.Add("Feature");

            if (op.FilterValue != null)
                combinations.Add("FilterValue");

            if (op.StarTime != null || op.EndTime != null)
                combinations.Add("Time");

            if (op.Serving != null )
                combinations.Add("Serving");

            if (combinations.Count == 6)
            {
                combinations = new List<string>() { "All" };
            }

            return combinations;
        }
    }

}
