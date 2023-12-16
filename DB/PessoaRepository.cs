using LiteDB;

namespace LiteDb.ConsoleApp.DB
{
    internal class PessoaRepository
    {
        public bool WritePessoa(Pessoa pessoa)
        {
            bool sucess = false;
            try
            {
                // cria a conexão com banco de dados. Se o arquivo 'pessoas.db' não existir ele vai ser criado
                using (var database = new LiteDatabase("pessoas.db"))
                {
                    var pessoaColection = database.GetCollection<Pessoa>("Pessoas"); // uma 'tabela' de Pessoas 
                    pessoaColection.Insert(pessoa);
                    sucess = true;
                }
            }
            catch
            {
                sucess = false;
            }
            return sucess;
        }

        public List<Pessoa>? GetPessoaList()
        {
            List<Pessoa> pessoasList = new List<Pessoa>();
            using (var database = new LiteDatabase("pessoas.db"))
            {               
                var pessoaColection = database.GetCollection<Pessoa>("Pessoas");

                var result = pessoaColection.FindAll();

                result.ToList().ForEach(pessoa => {
                    pessoasList.Add(pessoa);
                });

                return pessoasList;
            }
        }

        public Pessoa? GetByIdPessoa(Guid id)
        {
            using (var database = new LiteDatabase("pessoas.db"))
            {
                var pessoaColection = database.GetCollection<Pessoa>("Pessoas");
                return (Pessoa)pessoaColection.FindById(id);
            }
        }

        public bool EditPessoa(Pessoa novaPessoa)
        {
            bool sucess = false;
            using (var database = new LiteDatabase("pessoas.db"))
            {
                var pessoaColection = database.GetCollection<Pessoa>("Pessoas");
                pessoaColection.Update(novaPessoa);
                sucess = true;
            }
            return sucess;
        }

        public bool RemovePessoa(Pessoa pessoa)
        {
            bool sucess = false;
            using (var database = new LiteDatabase("pessoas.db"))
            {
                var pessoaColection = database.GetCollection<Pessoa>("Pessoas");
                pessoaColection.Delete(pessoa.Id);
                sucess = true;
            }
            return sucess;
        }

    }
}
