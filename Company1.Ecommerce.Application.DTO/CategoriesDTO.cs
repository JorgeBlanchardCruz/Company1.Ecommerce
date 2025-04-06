namespace Company1.Ecommerce.Application.DTO;

public class CategoriesDTO
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public byte[] Picture { get; set; } = default!;
}
