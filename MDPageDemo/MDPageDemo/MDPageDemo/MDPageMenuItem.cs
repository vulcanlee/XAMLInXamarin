using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPageDemo
{

    public class MDPageMenuItem
    {
        public MDPageMenuItem()
        {
            TargetType = typeof(MDPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}