using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plutus.WebAPI.Data;
using Plutus.WebAPI.Data.Entity;

namespace Plutus.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly PlutusDbContext _context;

        public LancamentoController(PlutusDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var lancamentos = _context.Set<Lancamento>().AsNoTracking();
            return Ok(lancamentos);
        }
    }
}
