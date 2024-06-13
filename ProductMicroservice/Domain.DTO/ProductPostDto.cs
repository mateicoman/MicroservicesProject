namespace ProductMicroservice.Domain.DTO;

public class ProductPostDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
}

