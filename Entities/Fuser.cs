using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Fuser:BaseEntities
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? Image { get; set; }
      

    }
}
