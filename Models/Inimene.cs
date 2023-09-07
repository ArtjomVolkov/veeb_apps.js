namespace veeb.Models
{
    public class Inimene
    {
        public int Id { get; set; }
        public string Isikukood { get; set; }
        public string Kasutajanimi { get; set; }
        public string Parool { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }

        public Inimene(int id, string kood, string nimi, string parool, string eesnimi, string perenimi)
        {
            Id = id;
            Isikukood = kood;
            Kasutajanimi = nimi;
            Parool = parool;
            Eesnimi = eesnimi;
            Perenimi = perenimi;
        }
    }
}
