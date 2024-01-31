using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Category
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Keywords")]
    public List<string> Keywords { get; set; }
}

public class CategoryConfig
{
    [JsonPropertyName("categories")]
    public List<Category> Categories { get; set; }
}


