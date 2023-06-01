using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreSize.Context;
using NetCoreSize.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.Net;
using Microsoft.Extensions.Logging;

namespace NetCoreSize.Controllers
{
    [ApiController]
    [ResponseCache(CacheProfileName = "oneMinute")]
    [Route("api/[controller]")]
    public class TerminalController : ControllerBase
    {
        private readonly MyContext _context;

 


        public TerminalController( MyContext context)
        {
            _context = context;
       
        }
        [HttpGet("/ExtraInfo", Name = "GetTerminalExtraInfo")]
        public ActionResult<IEnumerable<Terminal>> GetAllExtraInfo()
        {
            try
            {
                var query =
           from terminal in _context.Terminales
           join estado in _context.Estados on terminal.id_estado equals estado.id_estado
           join fabricante in _context.Fabricantes on terminal.id_fab equals fabricante.id_fab
           select new TerminalInformation
           {
               Id = terminal.Id,
               terminal_name = terminal.terminal_name,
               terminal_desc = terminal.terminal_desc,
               fab_name = fabricante.fab_name,
               estado_name = estado.estado_name,
               fecha_fabricacion = terminal.fecha_fabricacion,
               fecha_estado = terminal.fecha_estado
           };

                IEnumerable<TerminalInformation> listTerminales = query;
                return Ok(listTerminales);
            }
            catch (Exception ex)
            {
            
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex.Message);
            }

        }


        [HttpGet("/ExtraInfo/{id}", Name = "GetTerminalExtraInfoById")]
        public ActionResult<IEnumerable<Terminal>> GetAllExtraInfoById(int id)
        {
            try
            {
                var query =
           from terminal in _context.Terminales
           join estado in _context.Estados on terminal.id_estado equals estado.id_estado
           join fabricante in _context.Fabricantes on terminal.id_fab equals fabricante.id_fab
           where terminal.Id == id
           select new TerminalInformation
           {
               Id = terminal.Id,
               terminal_name = terminal.terminal_name,
               terminal_desc = terminal.terminal_desc,
               fab_name = fabricante.fab_name,
               estado_name = estado.estado_name,
               fecha_fabricacion = terminal.fecha_fabricacion,
               fecha_estado = terminal.fecha_estado
           };

                IEnumerable<TerminalInformation> listTerminales = query;
                return Ok(listTerminales);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed,  ex.Message);
            }

        }



        [HttpGet(Name = "GetTerminal")]
        public ActionResult<IEnumerable<Terminal>> GetAll()
        {
            return _context.Terminales.ToList();
        }



        [HttpGet("{id}")]
        public ActionResult<Terminal> GetById(int id)
        {
            var terminal = _context.Terminales.Find(id);
            if (terminal == null)
            {
                return NotFound();
            }
            return terminal;
        }

       
        [HttpPost]
        public ActionResult<Terminal> Create(Terminal terminal)
        {
            _context.Terminales.Add(terminal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = terminal.Id }, terminal);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Terminal terminal)
        {
            if (id != terminal.Id)
            {
                return BadRequest();
            }
            _context.Entry(terminal).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Terminal> Delete(int id)
        {
            var terminal = _context.Terminales.Find(id);
            if (terminal == null)
            {
                return NotFound();
            }
            _context.Terminales.Remove(terminal);
            _context.SaveChanges();
            return terminal;
        }




    }
}