using ContatosApi.Models;
using ContatosApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContatosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ContatoService _contatoService;

        public ContatosController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public ActionResult<List<Contato>> Get() =>
            _contatoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetContatos")]
        public ActionResult<Contato> Get(string id)
        {
            var contato = _contatoService.Get(id);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        [HttpPost]
        public ActionResult<Contato> Create(Contato contato)
        {
            _contatoService.Create(contato);

            return CreatedAtRoute("GetContato", new { id = contato.Id.ToString() }, contato);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Contato contatoIn)
        {
            var contato = _contatoService.Get(id);

            if (contato == null)
            {
                return NotFound();
            }

            _contatoService.Update(id, contatoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var contato = _contatoService.Get(id);

            if (contato == null)
            {
                return NotFound();
            }

            _contatoService.Remove(contato.Id);

            return NoContent();
        }
    }
}