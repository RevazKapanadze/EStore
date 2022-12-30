using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EStore.API.Data.Models
{
    public class user : IdentityUser<int>
    {
        public int IsActive { get; set; }
        public int Company_Id { get; set; }
        public company company { get; set; }
        public userAdress userAdress { get; set; }
    }
}
