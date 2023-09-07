using Microsoft.AspNetCore.Mvc;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }
        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: primitiivid/aasta
        [HttpGet("aasta/{date}")]
        public int Aasta(DateTime date)
        {
            DateTime dateTime = DateTime.Now.Date;
            if (dateTime.Month >= date.Month)
            {
                if(dateTime.Day >= date.Day)
                {
                    return dateTime.Year - date.Year;
                }       
            }
            return dateTime.Year - date.Year - 1;
        }

        // GET: primitiivid/rnd/333/11
        [HttpGet("rnd/{max}/{min}")]
        public int Rnd(int max,int min)
        {
            var rand = new Random();
            return rand.Next(min,max);
        }

        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }
    }
}
