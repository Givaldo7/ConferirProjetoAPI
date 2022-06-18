using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferirAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private static List<ClienteAPI> Clientes = new List<ClienteAPI>
            {
                new ClienteAPI {
                    Id = 1,
                    Nome = "Givaldo",
                    CPF = "12565889745",
                    Email = "Junior@gmail.com",
                    Telefone = "11940028922",
                    Endereco = "rua sem saida 123 tatuapé/SP",
                    Status = "ativo"

                },

                new ClienteAPI {
                    Id = 2,
                    Nome = "Cleiton",
                    CPF = "13865889748",
                    Email = "djcleiton@gmail.com",
                    Telefone = "82940028933",
                    Endereco = "rua com saida 123 Maceió/Al",
                    Status = "ativo"
                }
            };

        [HttpGet]
        public ActionResult<List<ClienteAPI>> Get()
        {

            return Ok(Clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteAPI> Get(int id)
        {
            var cliente = Clientes.Find(h => h.Id == id);
            if (cliente == null)
                return BadRequest("cliente not found.");
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<List<ClienteAPI>> AddCliente(ClienteAPI cliente)
        {
            Clientes.Add(cliente);
            return Ok(Clientes);
        }

        [HttpPut]
        public ActionResult<List<ClienteAPI>> UpdateCliente(ClienteAPI request, ClienteAPI? cliente)
        {
            ClienteValidator validator = new ClienteValidator();
            var validation = validator.Validate(cliente);
            if (validation.IsValid)
            {
                var cliente = Clientes.Find(h => h.Id == request.Id);
                if (cliente == null)
                    return BadRequest("cliente not found.");

            }
            else
            {
                return BadRequest(validation.ToString());
            }





            cliente.Nome = request.Nome;
            cliente.CPF = request.CPF;
            cliente.Email = request.Email;
            cliente.Telefone = request.Telefone;
            cliente.Endereco = request.Endereco;
            cliente.Status = request.Status;
            return Ok(Clientes);

        }

        [HttpDelete("{id}")]

        public ActionResult<List<ClienteAPI>> Delete(int id)
        {
            var cliente = Clientes.Find(h => h.Id == id);
            if (cliente == null)
                return BadRequest("cliente not found.");

            Clientes.Remove(cliente);
            return Ok(Clientes);

        }


    }

    internal class ClienteValidator
    {
        internal object Validate(ClienteAPI? cliente)
        {
            throw new NotImplementedException();
        }
    }
}
