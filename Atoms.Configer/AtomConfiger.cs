using System;

namespace Atoms.Configer
{
    public class AtomConfiger
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }
    }
}
