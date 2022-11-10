using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EStore.API.Data.Models
{
  public class user : IdentityUser
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long User_Id { get; set; }
    public int IsActive { get; set; }
    public int Company_Id { get; set; }
    public company company { get; set; }

  }
}