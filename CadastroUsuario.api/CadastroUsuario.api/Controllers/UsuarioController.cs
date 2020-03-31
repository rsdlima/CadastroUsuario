using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.api.Domain.Model;
using CadastroUsuario.api.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET api/values
        [HttpGet]
        [EnableCors("ApiCorsPolicy")]
        public ActionResult<IEnumerable<Usuarios>> Get()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ListaUsuarios = _usuarioService.All().ToArray();

            var result = _usuarioService.All();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [EnableCors("ApiCorsPolicy")]
        public ActionResult<Usuario> Get(int id)
        {

            var result = _usuarioService.Buscar(id);
            return result;
        }

        // POST api/values
        [HttpPost]
        [EnableCors("ApiCorsPolicy")]
        public IActionResult Incluir([FromBody] Usuario usuarios)
        {
            _usuarioService.Incluir(usuarios);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        [EnableCors("ApiCorsPolicy")]
        public void Alterar([FromBody] Usuario usuarios)
        {
            _usuarioService.Alterar(usuarios);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [EnableCors("ApiCorsPolicy")]
        public void Excluir(int id)
        {
            _usuarioService.Excluir(id);
        }
    }
}
