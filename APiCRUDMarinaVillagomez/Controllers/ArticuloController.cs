using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APiCRUDMarinaVillagomez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet]
        [Route("GetArticulos")]
        public IActionResult GetArticulos()
        {
            var articulos = Business.Articulo.GetArticulos();

            return Ok(articulos);
        }

        
        [HttpPost]
        public IActionResult PostArticulo([FromBody] Model.Articulo articulo)
        {
            if (articulo == null) return BadRequest();
            var respuesta = Business.Articulo.AddArticulo(articulo);
            if (respuesta) return Ok(respuesta); else return NotFound();
        }

        
        [HttpPut]
        public IActionResult PutArticulo([FromBody] Model.Articulo articulo)
        {
            if (articulo == null) return BadRequest();
            var respuesta = Business.Articulo.PutArticulo(articulo);
            if (respuesta) return Ok(respuesta); else return NotFound();
        }

  
        [HttpDelete("{idArticulo}")]
        public IActionResult DeleteArticulo(int idArticulo)
        {
            if (idArticulo <= 0) return BadRequest();
            var respuesta = Business.Articulo.DeleteArticulo(idArticulo);
            if (respuesta) return Ok(respuesta); else return NotFound();
        }
    }
}

