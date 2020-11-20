using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingAdminService.Data;
using VotingAdminService.Models;
using VotingAdminService.Repositories;

namespace VotingAdminService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContenderController : ControllerBase
    {
        private readonly IRepository<Contender> _contenderRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ContenderController));
        public ContenderController(IRepository<Contender> contenderRepo)
        {
            _contenderRepo = contenderRepo;
        }

        //GET: Contender
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _log4net.Info("Getting all Contenders");
                var contender = _contenderRepo.GetAll();
                return Ok(contender);

            }
            catch
            {
                _log4net.Error("Error in Getting Contenders");
                return new NoContentResult();
            }
        }

        // GET: Contenders/5
        [HttpGet("{id}")]
        public IActionResult GetContender(int id)
        {
            try
            {
                _log4net.Info("Getting Contender by Id" + "(" + id.ToString() + ")");
                var contender = _contenderRepo.GetByID(id);
                return new OkObjectResult(contender);
            }
            catch
            {
                _log4net.Error("Error in Getting Contender of Id " + id.ToString());
                return new NoContentResult();
            }
        }


        // POST: Contenders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult AddContender(Contender contender)
        {
            try
            {
                _log4net.Info("Contender Details Getting Added - " + "ContenderID is " + (contender.ContenderId + 1).ToString());
                if (ModelState.IsValid)
                {

                    var added = _contenderRepo.Add(contender);

                    return CreatedAtAction(nameof(AddContender), new { id = contender.ContenderId }, contender);

                }
                return BadRequest();


            }
            catch
            {
                _log4net.Error("Error in Adding Contender Details " + "ContenderID is " + contender.ContenderId.ToString());
                return new NoContentResult();
            }
        }


    }
}
