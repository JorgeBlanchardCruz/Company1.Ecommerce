namespace Company1.Ecommerce.Domain.Entity;

public class Categories
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public byte[] Picture { get; set; } = default!;
}
