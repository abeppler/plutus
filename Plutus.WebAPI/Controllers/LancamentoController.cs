using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plutus.WebAPI.Data;
using Plutus.WebAPI.Data.Entity;
using Plutus.WebAPI.Extensions;

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
            var query = from lancamentos in _context.Set<Lancamento>().AsNoTracking()
                        join contas in _context.Set<Conta>().AsNoTracking() on lancamentos.ContaId equals contas.Id
                        join grupoContas in _context.Set<GrupoConta>().AsNoTracking() on lancamentos.GrupoContaId equals grupoContas.Id
                        select new
                        {
                            tipoLancamentoDescricao = lancamentos.TipoLancamento.GetDescription(),
                            contaDescricao = contas.Descricao,
                            grupoContaDescricao = grupoContas.Descricao,
                            historico = lancamentos.Historico,
                            dataFormatada = lancamentos.Data.ToString("dd/MM/yyyy"),
                            valorFormatado = lancamentos.Valor.ToString("N2")
                        };

            return Ok(query);
        }
    }
}
