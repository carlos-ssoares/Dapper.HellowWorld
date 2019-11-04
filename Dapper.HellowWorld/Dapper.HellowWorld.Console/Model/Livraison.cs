using Dapper.HellowWorld.Console.Model.Utils;
using System;

namespace Dapper.HellowWorld.Console.Model
{
    public class Livraison
    {
        [Column(Name = "NO_LIVR")]
        public Id Id { get; set; }
        [Column(Name = "DESCR_LIVR")]
        public string Descr { get; set; }
        [Column(Name = "DAT_LIVR")]
        public DateTime Date { get; set; }
    }
}
