using ControleCombustivel.Utilidades;
using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Usuario : EntityBase
    {
        public string NomeCompleto { get; private set; }

        public string Cpf { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public int IdTipoUsuario { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public ICollection<Competencia> Competencias { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }

        private Usuario()
        {

        }

        public Usuario(int id, string nomeCompleto, string cpf, string email, string senha, int idTipoUsuario, bool ativo = true) : base(id, ativo)
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
            this.IdTipoUsuario = idTipoUsuario;
            Validar();
        }

        public Usuario(string nomeCompleto, string cpf, string email, string senha, int idTipoUsuario)
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.IdTipoUsuario = idTipoUsuario;
            AlterarSenha(senha);
            Validar();
        }

        public override void Validar()
        {
            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.NomeCompleto, "Informe o Nome Completo")
                .IfLengthGreaterThan(x => x.NomeCompleto, Configurations.MediumStringLength, "O Nome Completo deve ter no máximo 60 caracteres");

            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Email, "Informe o Email")
                .IfLengthGreaterThan(x => x.Email, Configurations.MediumStringLength, "O Email deve ter no máximo 30 caracteres")
                .IfNotEmail(x => x.Email, "Informe um Email válido");

            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Cpf, "Informe o Cpf")
            .IfLengthGreaterThan(x => x.Email, 15, "O Cpf deve ter no máximo 15 caracteres")
            .IfNotCpf(x => x.Cpf, "Informe um Cpf válido");

            new AddNotifications<Usuario>(this).IfEqualsZero(x => x.IdTipoUsuario, "Informe o Id do Tipo de Usuário");

        }

        public void AlterarSenha(string senha)
        {
            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Senha, "Informe a Senha")
               .IfLengthGreaterThan(x => x.NomeCompleto, 12, "A Senha deve ter no máximo 12 caracteres");
            this.Senha = Password.Encrypt(senha);
        }

        public bool CompararSenha(string pass)
        {
            return Password.Encrypt(pass).Equals(this.Senha);
        }
    }
}