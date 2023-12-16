using System;

namespace LiteDb.ConsoleApp
{
    internal class Pessoa
    {
        public Pessoa(Guid id, string nome, int idade, string endereco, string telefone)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return string.Format($"ID: {Id}\nNome: {Nome}\nIdade: {Idade}\nEndereco {Endereco}\nTelefone: {Telefone}");
        }
    }
}
