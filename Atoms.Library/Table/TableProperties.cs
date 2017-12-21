using System;
using System.Collections.Generic;

namespace Atoms.Library.Table
{
    public class TableProperties
    {
        public string TableName { get; set; }
        public List<ColumnProperties> ColumnProperties { get; set; }
    }
    public class ColumnProperties
    {
        public string ColumnName { get; set; }
        public Type ValueType { get; set; }
        public object Value { get; set; }
        public bool IsKey { get; set; }
        public bool OutInsert { get; set; }
        public bool OutUpdate { get; set; }
    }
}
