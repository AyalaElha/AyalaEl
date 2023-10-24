using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static List<Event> events = new List<Event> { new Event { Id = 1, Title = "first event", Start = DateTime.Now },new Event { Id=2,Title= "second event",Start= DateTime.Now } };
        static int counter = 3;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event e)
        {
            events.Add(new Event { Title=e.Title,Id=counter,Start=e.Start,End=e.End});
            counter++;

        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            Event e = events.Find(x => x.Id==id); 
            if(e!=null)
            {
                e.Title=eve.Title; 
                e.Start=eve.Start;
                e.End=eve.End;
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var e = events.Find(eve => eve.Id == id);
            events.Remove(e);   
        }
    }
}
