using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace EStore.Data.Models
{
  public class item
  {
    [Key]
    public long Id { get; set; }
    public string Short_Name {get;set;}
    public string Long_Name {get;set;}

  }
}