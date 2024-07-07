namespace apicrud.Models
{
    public interface IFuncionarioRepository
    {
        void Add(Funcionarios funionario);

        List<Funcionarios> Get();

        void Delete(int id);

        List<Funcionarios> GetById(int id);

        void Update(Funcionarios funionario);
    }
}
