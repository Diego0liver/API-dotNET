using apicrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace apicrud.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository ?? throw new ArgumentNullException(nameof(funcionarioRepository));
        }

        //Criar novo registro
        [HttpPost]
        public IActionResult PostFuncionario(Funcionarios funionario)
        {
            try
            {
                var funcionario = new Funcionarios(funionario.nome, funionario.sobrenome, funionario.idade);
                _funcionarioRepository.Add(funcionario);
                return Ok(new {message = "Funcionario criado com sucesso", funcionario});
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao tentar criar o funcionário.", details = e.Message });
                throw;
            }
        }

        //Pegar todos os registros
        [HttpGet]
        public IActionResult GetFuncionario() 
        {
            var funcionariosAll = _funcionarioRepository.Get();

            return Ok(funcionariosAll);
        }

        //Deletar registro pelo ID
        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            try
            {
                _funcionarioRepository.Delete(id);
                return Ok(new { message = "Funcionário deletado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao tentar deletar o funcionário.", details = e.Message });
                throw;
            }
        }

        //Pegar registro pelo ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var funcionarioId = _funcionarioRepository.GetById(id);
            return Ok(funcionarioId);
        }

        //Atualizar registro
        [HttpPut("{id}")]
        public IActionResult updateFuncionario(int id, Funcionarios funionario)
        {
            try
            {
                if (id != funionario.id)
                {
                    return BadRequest();
                }

                _funcionarioRepository.Update(funionario);
                return Ok(new { message = "Funcionário atualizado com sucesso.", funionario});
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao tentar atualizar o funcionário.", details = e.Message });
                throw;
            }
        }
    }
}
