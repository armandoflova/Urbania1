using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbaniaApi.Data;
using UrbaniaApi.Dtos;
using UrbaniaApi.Models;

namespace UrbaniaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UrbaniaController : ControllerBase
    {
        public IUrbaniaRepositorio _repo { get; }
        public IMapper _mapper { get; }
        public UrbaniaController(IUrbaniaRepositorio repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> obtenerProyectos()
        {
            var proyectos = await _repo.ObtenerProyectos();
            var proyectosRetornar = _mapper.Map<IEnumerable<ProyectoReturn>>(proyectos);
            return Ok(proyectosRetornar);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerProyecto(int id)
        {
            var proyecto = await _repo.ObtenerProyecto(id);
            var proyectoRetornar = _mapper.Map<ProyectoReturn>(proyecto);
            return Ok(proyectoRetornar);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> editarProyecto(int id, EditarProyecto ediarProyecto)
        {
            var proyecto = await _repo.ObtenerProyecto(id);
            proyecto.FechaModificacion = DateTime.Now;
            _mapper.Map(ediarProyecto , proyecto);
            if(await _repo.GuardarTodo())
                return NoContent();

            throw new Exception("No se pudo actualizar Proyecto");
        }

        [HttpPost]
        public async Task<IActionResult> guardarProyecto(ProyectoGuardar proyectoguardar)
        {
           proyectoguardar.FechaCreacion = DateTime.Now;

           var proyecto = _mapper.Map<Proyecto>(proyectoguardar);

           _repo.Agregar(proyecto);

           if(await _repo.GuardarTodo())
                return NoContent();
            
            throw new Exception("No se pudo guardar");


        }

    }
}