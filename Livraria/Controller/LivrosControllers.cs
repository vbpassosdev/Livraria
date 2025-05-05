
    using Microsoft.AspNetCore.Mvc;
    using LivrariaApi.Services;

    namespace LivrariaApi.Controllers;

    [ApiController]


    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("API da Livraria Online está ativa");
    }


    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _service;

        public LivrosController(LivroService service)
        {
            _service = service;
        }

    [HttpGet]
        public ActionResult<List<Livro>> Get() => _service.ObterTodos();

        [HttpGet("{id}")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = _service.ObterPorId(id);
            return livro is not null ? Ok(livro) : NotFound();
        }

        [HttpPost]
        public ActionResult<Livro> Post(Livro livro)
        {
            var novoLivro = _service.Criar(livro);
            return CreatedAtAction(nameof(Get), new { id = novoLivro.Id }, novoLivro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            if (!_service.Atualizar(id, livro)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Remover(id)) return NotFound();
            return NoContent();
        }
    }
