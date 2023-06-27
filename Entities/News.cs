using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class News:BaseEntities
    {
        public string Picture { get; set; }
        public DateTime Time { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
