using MessageUserAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Lista para almacenar los datos en memoria
        private static List<User> Users = new List<User>();

        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            // Validar datos
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.PhoneNumber))
            {
                return BadRequest("Name and PhoneNumber are required.");
            }

            // Guardar datos
            Users.Add(user);

            // Simular el envío de mensaje
            Console.WriteLine($"Mensaje de bienvenida enviado a {user.Name} al número {user.PhoneNumber}");

            // Responder confirmación
            return Ok(new { message = "Datos recibidos y mensaje enviado exitosamente." });
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(Users);
        }
    }
}
