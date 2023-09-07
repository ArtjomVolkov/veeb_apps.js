using Microsoft.AspNetCore.Mvc;
using veeb.Models;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }
        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = Math.Round(_toode.Price + 1.2,3);
            return _toode;
        }

        // GET: toode/truefasle
        [HttpGet("truefalse")]
        public Toode TrueFalse()
        {
            if(_toode.IsActive== false)
            {
                _toode.IsActive = true;
            }
            else if(_toode.IsActive== true)
            {
                _toode.IsActive = false;
            }
            return _toode;
        }

        // GET: toode/muudatoode
        [HttpGet("muudatoode/{uustoode}")]
        public Toode Muudatoode(string uustoode)
        {
            _toode.Name = uustoode;
            return _toode;
        }

        // GET: toode/muudahind
        [HttpGet("muudahind/{uushind}")]
        public Toode Muudahind(double uushind)
        {
            _toode.Price *= uushind;
            return _toode;
        }
    }
}
