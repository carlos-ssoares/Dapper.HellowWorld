using Dapper.HellowWorld.Console.Model.Utils;

namespace Dapper.HellowWorld.Console.Model
{
    public class Inscription
    {
        public Inscription()
        { }

        public Inscription(Id id, string descrition, Livraison livraison)
        {
            Id = id;
            Descr = descrition;
            Livraison = livraison;
        }

        // sans set; ca ne marche pas

        [Column(Name = "NO_FICH")]
        public Id Id { get; set; }

        [Column(Name = "DESCR_FICH")]
        public string Descr { get; set; }

        public Livraison Livraison { get; set; }
    }
}
