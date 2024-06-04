using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MPIapi.Data;
using MPIapi.Models;
using MPIapi.Models.Dto;

namespace MPIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        //          --------------------------------------------------------------------------
        //          ESTE SERIA EL METODO QUE UTILIZARIAMOS A PARTIR DEL MODELO DIRECTAMENTE
        //          --------------------------------------------------------------------------
        /*
        //Crear End point 
        [HttpGet]         // Tipo de verbo HTTP

        // (Ejemplo retornando una lista)
        public IEnumerable<Order> GetOrder()
        {
           return new List<Order>
           {
               new Order{Id=1, Name="Primera Orden", cantProductos=5},
               new Order{Id=2, Name="Segunda Orden", cantProductos=10}
           };
        }
        */
        //          --------------------------------------------------------------------------
        //          ESTE SERIA LA OPCION QUE UTILIZARIAMOS A PARTIR DEL MODELO DTO DE ORDER
        //          --------------------------------------------------------------------------
        /*
        //Crear End point 
        [HttpGet] // Tipo de verbo HTTP
                  // Tambien de ejemplo retornando una lista
        public IEnumerable<OrderDto> GetOrderDto()
        {
            return new List<OrderDto>
            {
                new OrderDto{Id=1, Name="Primera OrdenDto", cantProductos=5},
                new OrderDto{Id=2, Name="Segunda OrdenDto", cantProductos=10}
            };
        }
        */


        //          --------------------------------------------------------------------------
        //          Y POR ULTIMO OTRO EJEMPLO CON LA LISTA YA CREADA DESDE EL FICHERO DATA
        //          --------------------------------------------------------------------------
        //                  este será el que trabajaré para seguir creando la API.


        //Crear End point 
        [HttpGet] // Tipo de verbo HTTP
        [ProducesResponseType(StatusCodes.Status200OK)] // buenas practicas, documentar las respuestas
        public ActionResult<IEnumerable<OrderDto>> GetOrderDto()
        {
            return Ok(OrderList.Orders);  // (OK).... devuelve un codigo de estado: 200
        }

        //Name ... Se agrega un nombre al endpoint
        [HttpGet("Id", Name ="GetOrder")] // Id ... Retorna un objeto con ese Id de la lista Orders
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // buenas practicas para desarrolladores....
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> GetOrderDto(int Id)
        {
            if (Id == 0)
            {
                return BadRequest(); // Codigo de estado: 400
            }

            var order = OrderList.Orders.FirstOrDefault(o => o.Id == Id);

            if (order == null)
            {
                return NotFound(); // codigo de estado: 404
            }

            return Ok(order); // codigo 200.
        }

            // endpoint metodo POST (crear)
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // buenas practicas para desarrolladores....
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OrderDto> CreateOrderDto([FromBody] OrderDto orderdto) //FromBody indica recepcion de datos.
        {
            if (!ModelState.IsValid) // si el modelo es valido
            {
                return BadRequest(ModelState);
            }
            if (OrderList.Orders.FirstOrDefault(v=>v.Name.ToLower() == orderdto.Name.ToLower()) !=null)
            {
                ModelState.AddModelError("NombreExiste", "Ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (orderdto == null)
            {
                return BadRequest(orderdto);
            }
            if (orderdto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            orderdto.Id = OrderList.Orders.OrderByDescending(o => o.Id).FirstOrDefault().Id + 1;
            OrderList.Orders.Add(orderdto);
            return CreatedAtRoute("GetOrder", new {id=orderdto.Id}, orderdto);
        }

            // endpoint para el metodo DELETE
        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // buenas practicas para desarrolladores....
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteOrder(int Id) // Actionresult.... Aqui no hace falta el modelo porque devuelve un NoContent()
        {
            if(Id == 0)
            {
                return BadRequest();
            }
            var order = OrderList.Orders.FirstOrDefault(v=>v.Id == Id);
            if(order == null)
            {
                return NotFound();
            }
            OrderList.Orders.Remove(order);
            return NoContent();
        }

        // endpoint para el metodo PUT  (update)
        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // buenas practicas para desarrolladores....

        public IActionResult UpdateOrder(int Id, [FromBody] OrderDto orderdto) // Recibe el Id y el objeto a actualizar
                                                                               //  porque devuelve un NoContent()
        {
            if (orderdto == null)
            {
                return BadRequest();
            }
            var order = OrderList.Orders.FirstOrDefault(v => v.Id == Id);
            order.Name = orderdto.Name;
            order.cantProductos = orderdto.cantProductos;

            return NoContent();
        }


        // endpoint para el metodo PATCH
        [HttpPatch("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // buenas practicas para desarrolladores....

        public IActionResult UpdateOrder(int Id, JsonPatchDocument<OrderDto> patchdto) // Hace referencia a la libreria agregada
        {
            if (patchdto == null || Id==0)
            {
                return BadRequest();
            }

            var order = OrderList.Orders.FirstOrDefault(v => v.Id == Id);
            patchdto.ApplyTo(order, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
