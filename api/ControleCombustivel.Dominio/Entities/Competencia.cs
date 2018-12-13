using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Entities
{
    public class Competencia : Base
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Usuario Usuario { get; private set; }

        public int IdUsuario { get; private set; }

        public int Mes { get; private set; }

        public int Ano { get; private set; }

        public ICollection<Abastecimento> Abastatecimentos { get; set; }

        public Competencia(int mes, int ano, int idUsuario) : base()
        {
            this.Mes = mes;
            this.Ano = ano;
            this.IdUsuario = idUsuario;
            Validar();
        }

        public Competencia(int id, int mes, int ano, int idUsuario, bool ativo = true) : base(id, ativo)
        {
            this.Mes = mes;
            this.Ano = ano;
            this.IdUsuario = idUsuario;
            Validar();
        }

        public override void Validar()
        {
            AddNotifications(
                new Contract().Requires()
                .IsTrue(this.Mes >= 1, this.Mes.ToString(), "O Mês deve ser maior ou igual a 1")
                .IsLowerOrEqualsThan(this.Mes, 12, this.Mes.ToString(), "O Mês deve ser menor ou igual a 12"),

                new Contract().Requires()
                .IsGreaterOrEqualsThan(this.Ano, (DateTime.Now.Year - 1), this.Ano.ToString(), "Informe um ano válido")
                .IsLowerOrEqualsThan(this.Ano, (DateTime.Now.Year + 1), this.Ano.ToString(), "Informe um ano válido"));


        }
    }
}
