using ControleCombustivel.Dominio.Entities.Base;
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
                .IfNullOrInvalidLength(x => x.NomeCompleto, 10, Configurations.MediumStringLength, "O Nome Completo deve ter entre 10 e 60 caracteres");

            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Email, "Informe o Email")
                .IfNullOrInvalidLength(x => x.Email, 10, Configurations.MediumStringLength, "O Email deve ter entre 10 e 30 caracteres")
                .IfNotEmail(x => x.Email, "Informe um Email válido");

            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Cpf, "Informe o Cpf")
                .IfNullOrInvalidLength(x => x.Cpf, 11, Configurations.MediumStringLength, "O Cpf deve ter entre 10 e 15 caracteres")
                .IfNotCpf(x => x.Cpf, "Informe um Cpf válido");

            new AddNotifications<Usuario>(this).IfEqualsZero(x => x.IdTipoUsuario, "Informe o Id do Tipo de Usuário");

        }

        public void AlterarSenha(string senha)
        {
            new AddNotifications<Usuario>(this).IfNotNullOrEmpty(x => x.Senha, "Informe a Senha")
               .IfNullOrInvalidLength(x => x.Senha, 6, 12, "A Senha deve ter entre 6 e 12 caracteres");
            this.Senha = Password.Encrypt(senha);
        }

        public bool CompararSenha(string pass)
        {
            return Password.Encrypt(pass).Equals(this.Senha);
        }
    }
}