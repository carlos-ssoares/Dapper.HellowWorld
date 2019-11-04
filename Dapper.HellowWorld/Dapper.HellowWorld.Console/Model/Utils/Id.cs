using System;

namespace Dapper.HellowWorld.Console.Model.Utils
{
    public class Id
    {
        public Id(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
        public Guid Hash { get; set; } = Guid.NewGuid();
    }
}
