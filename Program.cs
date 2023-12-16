using LiteDb.ConsoleApp;
using LiteDb.ConsoleApp.DB;

internal class Program
{
    static PessoaRepository repository = new PessoaRepository();

    private static void Main(string[] args)
    {
        bool exit = false;
        do
        {
            switch (GetOption())
            {
                case 1:
                    RecordPessoa();
                    Console.Clear();
                    break;
                case 2:
                    UpdatePessoa();
                    Console.Clear();
                    break;
                case 3:
                    FindAllPessoa();                   
                    break;
                case 4:
                    RemovePessoaByID();
                    Console.Clear();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    break;
            }
        } while (exit == false);

        Console.Clear();
        Environment.Exit(0);
    }

    private static int GetOption()
    {
        Console.WriteLine("CADASTRO DE PESSOAS: \n\n1- Gravar\n2- Editar\n3- Obter Todas\n4- Remover\n5- Sair\n");
        Console.Write("---> ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private static void RecordPessoa()
    {
        Console.Clear();
        Console.WriteLine("GRAVAR:\n");

        Console.Write("Nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());
        Console.Write("Endereço: ");
        string? endereco = Console.ReadLine();
        Console.Write("Telefone: ");
        string? telefone = Console.ReadLine();

        Pessoa novaPessoa = new Pessoa(Guid.NewGuid(), nome, idade, endereco, telefone);

        if (repository.WritePessoa(novaPessoa))
        {
            Console.Write("\nPessoa inserida com sucesso.");
            Console.ReadKey();
        }
        else
        {
            Console.Write("\nErro ao inserir nova pessoa.");
            Console.ReadKey();
        }
    }

    private static void UpdatePessoa()
    {
        Console.Clear();
        Console.WriteLine("EDITAR:\n");

        Console.WriteLine("LISTA DE PESSOAS: \n\n");
        List<Pessoa> listPessoas = repository.GetPessoaList();
        foreach (var pessoa in listPessoas)
        {
            Console.WriteLine(pessoa.Id);
            Console.WriteLine(pessoa.Nome);
            Console.WriteLine();
        }

        Console.Write("\n\nDigite o ID da pessoa a ser atualizada: ");

        var pessoaAtualizar = repository.GetByIdPessoa(Guid.Parse(Console.ReadLine()));

        if (pessoaAtualizar != null)
        {
            Console.WriteLine();
            Console.Write("Nome: ");
            pessoaAtualizar.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            pessoaAtualizar.Idade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Endereço: ");
            pessoaAtualizar.Endereco = Console.ReadLine();
            Console.Write("Telefone: ");
            pessoaAtualizar.Telefone = Console.ReadLine();
        }

        if (repository.EditPessoa(pessoaAtualizar))
        {
            Console.Write("\nPessoa atualizada com sucesso.");
            Console.ReadKey();
        }
        else
        {
            Console.Write("\nErro ao atualizar pessoa.");
            Console.ReadKey();
        }
    }

    private static void FindAllPessoa()
    {
        Console.Clear();
        Console.WriteLine("LISTA DE PESSOAS: \n\n");
        List<Pessoa> listPessoas = repository.GetPessoaList();
        foreach (var pessoa in listPessoas)
        {
            Console.WriteLine($"ID:       {pessoa.Id}");
            Console.WriteLine($"Nome:     {pessoa.Nome}");
            Console.WriteLine($"Endereço: {pessoa.Endereco}");
            Console.WriteLine($"Telefone: {pessoa.Telefone}");
            Console.WriteLine();
            
        }
        Console.Write("> Tecle para limpar");
        Console.ReadKey();
        Console.Clear();
    }

    private static void RemovePessoaByID()
    {
        Console.Clear();
        Console.WriteLine("REMOVER:\n");

        Console.WriteLine("LISTA DE PESSOAS: \n\n");
        List<Pessoa> listPessoas = repository.GetPessoaList();
        foreach (var pessoa in listPessoas)
        {
            Console.WriteLine(pessoa.Id);
            Console.WriteLine(pessoa.Nome);
            Console.WriteLine();
        }

        Console.Write("\n\nDigite o ID da pessoa a ser removida: ");

        var pessoaRemover = repository.GetByIdPessoa(Guid.Parse(Console.ReadLine()));

        if (repository.RemovePessoa(pessoaRemover))
        {
            Console.Write("\nPessoa removida com sucesso.");
            Console.ReadKey();
        }
        else
        {
            Console.Write("\nErro ao remover pessoa.");
            Console.ReadKey();
        }

    }
}