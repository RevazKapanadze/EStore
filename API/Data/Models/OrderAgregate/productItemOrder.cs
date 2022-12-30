using Microsoft.EntityFrameworkCore;

[Owned]
public class productItemOrdered
{
    public long ItemId { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }
}
