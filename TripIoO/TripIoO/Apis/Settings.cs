// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripIoO.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class Settings : ControllerBase
    {
        ISetting _setting;
        public Settings(ISetting setting)
        {

            _setting = setting;

        }
        // GET: api/<Settings>
        [HttpGet]
        public TbSetting? Get()
        {
            return _setting.Get();
        }

        // GET api/<Settings>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Settings>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Settings>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Settings>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
