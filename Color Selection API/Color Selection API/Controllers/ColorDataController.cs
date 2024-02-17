using Color_Selection_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Color_Selection_API.Controllers
{
    [Route("Color")]
    [ApiController]
    public class ColorDataController : ControllerBase
    {
        private readonly colorcls db;
        public ColorDataController(colorcls context)
        {
            db = context;
        }

        //GET
        //[HttpGet]
        //public IEnumerable<Color> Get([FromQuery] int id)
        //{
        //var x = db.colores.Where();
        //db.SaveChanges();
        //    return x;

        //}

        [HttpGet]
       
        public IEnumerable<Color> getalldata(int id)
        {

            return db.colores.ToList();

        }


        //INSERT DATA
        [HttpPost]
        public IActionResult Post([FromBody] Color clr)
        {
            if (clr == null)
            {
                return BadRequest("Invalid Data..!!");
            }
            else
            {
                try
                {
                    db.colores.Add(clr);
                    db.SaveChanges();
                    return Ok("Data is Add...!!");
                }
                catch (Exception)
                {
                    return Ok("Error...!!!");
                }
            }
        }
        //UPDATE DATA
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Color clr)
        {
            if(clr == null)
            {   
                return BadRequest("Invalid Data");
            }
            else
            {
                try
                {
                    var exite = db.colores.FirstOrDefault(x => x.Id == id);
                    exite.colorName = clr.colorName;
                    exite.colorCode = clr.colorCode;
                    exite.colorHexaCode = clr.colorHexaCode;
                    db.colores.Update(exite);
                    db.SaveChanges();
                    return Ok("Data is Updating SuccessFully");
                }
                catch (Exception)
                {
                    return Ok("Error...!!");
                }
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletecolor = db.colores.Where(x => x.Id == id).FirstOrDefault();
            if(deletecolor == null)
            {
                return BadRequest("Invalid Data...!!!!");
            }
            else
            {
                try
                {
                    db.colores.Remove(deletecolor);
                    db.SaveChanges();
                    return Ok("Data is Deleting SuccessFully");

                }
                catch (Exception)
                {
                    return Ok("Error...!!!");
                }
            }

        }


    }
}
