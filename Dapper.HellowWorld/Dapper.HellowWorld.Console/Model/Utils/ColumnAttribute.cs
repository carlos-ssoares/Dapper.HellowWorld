using System;

namespace Dapper.HellowWorld.Console.Model.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public ColumnAttribute() { }
        public ColumnAttribute(string Name) { this.Name = Name; }
    }
}
