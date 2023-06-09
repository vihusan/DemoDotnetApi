using DemoDotnetApi.Models.Data;
using DemoDotnetApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoDotnetApi.Controllers
{
    [Route("api/operacion")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        [HttpPost]
        [ActionName(nameof(PostOperacion))]
        public dynamic PostOperacion(double arg1, double arg2, string ope)
        {
            double resultado = 0;

            switch (ope) {
                case "+":
                    resultado = arg1 + arg2;
                    break;
                case "-":
                    resultado = arg1 - arg2;
                    break;
                case "*":
                    resultado = arg1 * arg2;
                    break;
                case "/":
                    resultado = arg1 / arg2;
                    break;
            }

            return new { 
                success = true,
                message = "operacion realizada correctamente",
                result = resultado
            };
        }

        [HttpGet]
        [ActionName(nameof(GetOperacion))]
        public dynamic GetOperacion()
        {
            double arg1 = Convert.ToDouble(Request.Headers.Where(x => x.Key == "arg1").FirstOrDefault().Value);
            double arg2 = Convert.ToDouble(Request.Headers.Where(x => x.Key == "arg2").FirstOrDefault().Value);
            string? ope = Request.Headers.Where(x => x.Key == "ope").FirstOrDefault().Value;

            double resultado = 0;

            switch (ope)
            {
                case "+":
                    resultado = arg1 + arg2;
                    break;
                case "-":
                    resultado = arg1 - arg2;
                    break;
                case "*":
                    resultado = arg1 * arg2;
                    break;
                case "/":
                    resultado = arg1 / arg2;
                    break;
            }

            return new
            {
                success = true,
                message = "operacion realizada correctamente",
                result = resultado
            };
        }

    }
}
