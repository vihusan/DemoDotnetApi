using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DemoDotnetApi.Models.Data;
using DemoDotnetApi.Models.Repository;

namespace DemoDotnetApi.Controllers
{
    [Route("api/humano")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private IHumanoRepository _humanoRepository;
        public HumanoController(IHumanoRepository humanoRepository) 
        {
            _humanoRepository = humanoRepository;
        }
        List<Humano> humanos = new List<Humano>
        {
            new Humano{
                id = 1,
                nombre = "Luis Juarez",
                sexo = "Masculino",
                edad = 31,
                altura = 183,
                peso = 75
            },
            new Humano{
                id = 2,
                nombre = "Valdemar",
                sexo = "Masculino",
                edad = 35,
                altura = 180,
                peso = 90
            }
        };

        [HttpGet]
        [Route("listar")]
        public dynamic listarHumanos()
        {
            return this.humanos;
        }


        [HttpGet]
        [ActionName(nameof(GetHumanosAsync))]
        public IEnumerable<Humano> GetHumanosAsync()
        {
            return _humanoRepository.GetHumanos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetHumanoById))]
        public ActionResult<Humano> GetHumanoById(int id)
        {
            var humanoByID = _humanoRepository.GetHumanoById(id);
            if (humanoByID == null)
            {
                return NotFound();
            }
            return humanoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateHumanoAsync))]
        public async Task<ActionResult<Humano>> CreateHumanoAsync(Humano humano)
        {
            await _humanoRepository.CreateHumanoAsync(humano);
            return CreatedAtAction(nameof(GetHumanoById), new { id = humano.id }, humano);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateHumano))]
        public async Task<ActionResult> UpdateHumano(int id, Humano humano)
        {   
            if (id != humano.id)
            {
                return BadRequest();
            }

            await _humanoRepository.UpdateHumanoAsync(humano);

            return NoContent();

        }



    }
}
