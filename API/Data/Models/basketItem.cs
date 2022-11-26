using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EStore.API.Data.Models;
namespace EStore.API.Data.Models
{
  [Table("BASKET_ITEMS")]
  public class basketItem
  {
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }

    // navigation properties
    public long ProductId { get; set; }
    public item Product { get; set; }

    public int BasketId { get; set; }
    public basket Basket { get; set; }
  }
}