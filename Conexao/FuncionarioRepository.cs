
using apicrud.Models;

namespace apicrud.Conexao
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ConexaoContext _conexaoContext = new ConexaoContext();
        public void Add(Funcionarios funionario)
        {
            _conexaoContext.Funcionarios.Add(funionario);
            _conexaoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var funcionaioId = _conexaoContext.Funcionarios.FirstOrDefault(f => f.id == id);
            if (funcionaioId != null)
            {
                _conexaoContext.Funcionarios.Remove(funcionaioId);
                _conexaoContext.SaveChanges();
            }
        }

        public List<Funcionarios> Get()
        {
            return _conexaoContext.Funcionarios.ToList();
        }

        public List<Funcionarios> GetById(int id)
        {
            var funcionaioId = _conexaoContext.Funcionarios.FirstOrDefault(f => f.id == id);
            if (funcionaioId != null)
            {
                return new List<Funcionarios> {  funcionaioId };
            }

            return new List<Funcionarios>();
        }

        public void Update(Funcionarios funionario)
        {
            var funcionariosExistente = _conexaoContext.Funcionarios.Find(funionario.id);
            if(funcionariosExistente != null)
            {
                funcionariosExistente.nome = funionario.nome;
                funcionariosExistente.sobrenome = funionario.sobrenome;
                funcionariosExistente.idade = funionario.idade;
                _conexaoContext.Funcionarios.Update(funcionariosExistente);
                _conexaoContext.SaveChanges();
            }
        }
    }
}
