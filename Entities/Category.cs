﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category:BaseEntities
    {
        [Required]
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
