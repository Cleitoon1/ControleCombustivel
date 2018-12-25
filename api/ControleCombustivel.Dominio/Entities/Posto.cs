using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Posto : EntityBase
    {
        public Posto(string nome, string cnpj, long lat, long @long, string cep, string rua, string numero, string bairro,
            string cidade, string estado) : base()
        {
            Nome = nome;
            Cnpj = cnpj;
            Lat = lat;
            Long = @long;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Validar();
        }

        public Posto(int id, string nome, string cnpj, long lat, long @long, string cep, string rua, string numero, string bairro,
            string cidade, string estado, bool ativo = true) : base(id, ativo)
        {
            Nome = nome;
            Cnpj = cnpj;
            Lat = lat;
            Long = @long;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Validar();
        }

        public string Nome { get; private set; }

        public string Cnpj { get; private set; }

        public long Lat { get; private set; }

        public long Long { get; private set; }

        public string Cep { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public ICollection<Abastecimento> Abastecimentos { get; private set; }

        public override void Validar()
        {
            new AddNotifications<Posto>(this).IfNotNullOrEmpty(x => x.Nome, "Informe o Nome").IfLengthGreaterThan
                 (x => x.Nome, Configurations.ShortStringLength, "O Nome deve ter no máximo 30 caracteres");
        }
    }
}