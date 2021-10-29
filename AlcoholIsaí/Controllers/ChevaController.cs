using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlcoholIsaí.Services;
using AlcoholIsaí.Dominio;



namespace AlcoholIsaí.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChevaController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalcularVolumen(Cheva oCheva)
        {
            var srv = new ServicioCheva();

            var totalChevaPorBebidaConsumido = srv.CalcularTotalChevaConsumido(oCheva.bebida, oCheva.cantidad);

            var cantidadChevaSangre = srv.CalcularCantidadChevaSangre(totalChevaPorBebidaConsumido);

            var masa = srv.CalcularMasa(cantidadChevaSangre);

            var volumenSangre = srv.CalcularVolumenSangre(oCheva.peso);

            var volumenCheva = srv.CalcularVolumenCheva(masa, volumenSangre);

            var resultado = srv.Validar(volumenCheva);

            return Ok(resultado);
        }
    }
}
