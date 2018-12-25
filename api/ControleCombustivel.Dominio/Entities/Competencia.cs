using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Competencia : EntityBase
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

            new AddNotifications<Competencia>(this).IfNotRange(x => x.Mes, 1, 12, "O Mês deve ser maior ou igual a 1");
            new AddNotifications<Competencia>(this).IfNotRange(x => x.Ano, (DateTime.Now.Year - 1), DateTime.Now.Year, "Informe um ano válido");
        }
    }
}
