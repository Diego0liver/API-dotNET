using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apicrud.Models
{
    [Table("funcionarios")]
    public class Funcionarios
    {
        [Key] 
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome {  get; set; }
        public int idade { get; set; }

        public Funcionarios(string nome, string sobrenome, int idade)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.idade = idade;
        }
    }
}
