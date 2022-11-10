using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EStore.API.Data.Models
{
  public class item_Details
  {
    [Key]
    public long Id { get; set; }
    public string Size { get; set; }
    public string Colour { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int Sale { get; set; }
    public long Item_Id { get; set; }
    [ForeignKey("Id")]
    public item item { get; set; }
  }
}