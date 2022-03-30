using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController:ControllerBase
    {
        private readonly ApplicationDbContext _db;
        //en el; contructos ponemos el dbcontext
        public LugaresController(ApplicationDbContext db)
        {
            _db=db;
        }

        [HttpGet]
        //para hacerlos asyncrono toca agregar async y task encerrando todo
        public async Task<ActionResult<List<Lugar>>> GetLugares()
        {
            //al to list hacerlo asyncrono tambien
            var lugares=await _db.Lugar.ToListAsync();
            return Ok(lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            //retornara un solo lugar , le mandamos el id que queremos buscar
            var lugar = await _db.Lugar.FindAsync(id);
            return Ok(lugar);
        }
    }
}
