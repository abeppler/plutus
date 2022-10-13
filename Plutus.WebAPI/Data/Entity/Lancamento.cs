namespace Plutus.WebAPI.Data.Entity
{
    public class Lancamento: BaseEntity
    {
        public TipoLancamento TipoLancamento { get; set; }
        public string? Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int ContaId { get; set; }
        public Conta? Conta { get; set; }

        public int GrupoContaId { get; set; }
        public GrupoConta? GrupoConta { get; set; }

    }

    public enum TipoLancamento
    {
        Despesa = 1,
        Receita = 2
    }
}
