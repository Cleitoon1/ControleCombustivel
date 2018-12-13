using ControleCombustivel.Utilidades;
using ControleCombustivel.Utilidades.Validacoes;
using Flunt.Validations;
using System.Collections.Generic;
using static ControleCombustivel.Utilidades.Validacoes.CPF;

namespace ControleCombustivel.Dominio.Entities
{
    public class Usuario : Base
    {
        public string NomeCompleto { get; private set; }

        public string Cpf { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public ICollection<Competencia> Competencias { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }

        public Usuario(int id, string nomeCompleto, string cpf, string email, string senha, bool ativo = true) : base(id, ativo)
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
            Validar();
        }

        public Usuario(string nomeCompleto, string cpf, string email, string senha)
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            AlterarSenha(senha);
            Validar();
        }

        public override void Validar()
        {
            AddNotifications(
                new Contract().Requires().IsNullOrEmpty(this.NomeCompleto, this.NomeCompleto, "Informe o Nome Completo")
                .HasMaxLen(this.NomeCompleto, Configurations.MediumStringLength, this.NomeCompleto, "O Nome Completo deve ter no máximo 60 caracteres"),
                
                new Contract().Requires().IsNullOrEmpty(this.Cpf, this.Cpf, "Informe o CPF")
                .IsTrue(CPFValidation.Validar(this.Cpf), this.Cpf, "Informe um CPF válido"),
                
                new Contract().Requires().IsNullOrEmpty(this.Email, this.Email, "Informe o Email")
                .HasMaxLen(this.Email, Configurations.ShortStringLength, this.Email, "O Email da Medida deve ter no máximo 30 caracteres")
                .IsEmailOrEmpty(this.Email, this.Email, "Informe um Email válido")
            );
        }

        public void AlterarSenha(string senha)
        {
            AddNotifications(
                new Contract().Requires().IsNullOrEmpty(this.Senha, this.Senha, "Informe a Senha")
                .HasMaxLen(this.Senha, 12, this.Senha, "A Senha deve ter no máximo 12 caracteres"));
            this.Senha = Password.Encrypt(senha);
        }

        public bool CompararSenha(string pass)
        {
            return Password.Encrypt(pass).Equals(this.Senha);
        }
    }
}