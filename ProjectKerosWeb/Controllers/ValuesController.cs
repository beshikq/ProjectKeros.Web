using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectKerosWeb.Models;

namespace ProjectKerosWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ProjectKerosDbContext context;

        public ValuesController(ProjectKerosDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.UserModel.ToListAsync());
        }

        // GET api/<controller>/
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var userModel = await context.UserModel.FirstOrDefaultAsync(x => x.Id == id);

            if (userModel == null)
                return NotFound();

            return Ok(userModel);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            userModel.Id = 0;

            context.UserModel.Add(userModel);
            await context.SaveChangesAsync();

            return CreatedAtRoute("Get", new { id = userModel.Id }, userModel);
        }

        // PUT api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            var userModelUpdate = await context.UserModel.FirstOrDefaultAsync(x => x.Id == id);
            if (userModelUpdate == null)
                return NotFound();

            userModelUpdate.Name = userModel.Name;
            userModelUpdate.Age = userModel.Age;
            userModelUpdate.Address = userModel.Address;

            //context.UserModel.Update(userModelUpdate);
            context.Entry(userModelUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return new NoContentResult();
        }

        // DELETE api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userModel = await context.UserModel.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            context.UserModel.Remove(userModel);
            await context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
