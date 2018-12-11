using ControleCombustivel.Dominio.ObjetosValor;
using Flunt.Validations;
using System.Collections.Generic;
using static ControleCombustivel.Dominio.ObjetosValor.CPF;

namespace ControleCombustivel.Dominio.Entities
{
    public class Usuario : Base
    {
        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public ICollection<Competencia> Competencias { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }

        public Usuario(int id, string nomeCompleto, string cpf, string email, string senha, bool ativo = true)
        {
            this.Id = id;
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
            this.Ativo = ativo;
            Validar();
        }

        public Usuario(string nomeCompleto, string cpf, string email, string senha, bool ativo = true)
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = ValidarSenha(senha);
            this.Ativo = ativo;
            Validar();
        }

        private void Validar()
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

        private string ValidarSenha(string senha)
        {
            return "";
        }
    }
}