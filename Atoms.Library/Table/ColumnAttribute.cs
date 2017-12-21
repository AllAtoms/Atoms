using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atoms.Library.Table
{
    public class ColumnAttribute : Attribute
    {     
        public bool IsKey { get; set; } = false;
        public bool OutInsert { get; set; } = false;
        public bool OutUpdate { get; set; } = false;
    }
}
