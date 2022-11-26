using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations.Schema;
namespace EStore.API.Data.Models
{
  public class item
  {
    [Key]
    public long Id { get; set; }
    public string Short_Name { get; set; }
    public string Short_Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int Main_Category { get; set; }
    public int Is_Active { get; set; }
    public string Main_Photo { get; set; }

    //navigation
    public int Category_Id { get; set; }
    public category category { get; set; }
    public int Company_Id { get; set; }
    public company Company { get; set; }
     public ICollection<basketItem> basketItems { get; set; }
    public ICollection<item_Photoes> item_Photoes { get; set; }
    public ICollection<item_Details> item_Details { get; set; }
  }
}