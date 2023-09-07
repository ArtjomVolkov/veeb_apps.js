using Microsoft.AspNetCore.Mvc;
using veeb.Models;

namespace veeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
        new Toode(1,"Koola", 1.5, true),
        new Toode(2,"Fanta", 1.0, false),
        new Toode(3,"Sprite", 1.7, true),
        new Toode(4,"Vichy", 2.0, true),
        new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET: tooded
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }
        // GET: tooted/false
        [HttpGet("false")]
        public List<Toode> False()
        {
            foreach (var toode in _tooted)
            {
                toode.IsActive = false;
            }
            return _tooted;
        }
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }
        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            if(index < _tooted.Count())
            {
                _tooted.RemoveAt(index);
                return "Kustutatud!" + _tooted[index].Name;
            }
            else
            {
                return "ERROR!";
            }
        }
        [HttpPost("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
        public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")] // GET /tooted/lisa?id=1&nimi=Koola&hind=1.5&aktiivne=true
        public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }
        [HttpPatch("hind-dollaritesse/{kurss}")] // GET /tooted/hind-dollaritesse/1.5
        public List<Toode> Dollaritesse(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }

        // või foreachina:

        [HttpPatch("hind-dollaritesse2/{kurss}")] // GET /tooted/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooted)
            {
                t.Price = t.Price * kurss;
            }

            return _tooted;
        }
        [HttpDelete("kustutakoik")]
        public List<Toode> DeleteKoik()
        {
            _tooted.Clear();
            return _tooted;
        }
        [HttpGet("otsing/{index}")]
        public string Otsing(int index)
        {
            if (index < _tooted.Count())
            {
                return "Nimi: " + _tooted[index].Name + " Hind: " + _tooted[index].Price + " IsActivity: " + _tooted[index].IsActive;
            }
            else
            {
                return "ERROR!";
            }
        }
        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            Toode maxprice = null;
            double minprice = double.MinValue;

            foreach (var toode in _tooted)
            {
                if (toode.Price > minprice)
                {
                    minprice = toode.Price;
                    maxprice = toode;
                }
            }

            return maxprice;
        }
    }
}
