using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.DAL;
using ASP.NETCoreWebApplication.Entities;
using ASP.NETCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Controllers
{
    [ApiController]
    [Route("api/opgave")]
    public class OpgaveController : ControllerBase
    {
        private readonly InCaptivaContext _inCaptivaContext;

        public OpgaveController(InCaptivaContext inCaptivaContext)
        {
            _inCaptivaContext = inCaptivaContext;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OpgaveModel>> Index()
        {
            try
            {
                IQueryable<Opgave> opgaveQuery = _inCaptivaContext.Opgaver.AsQueryable();

                List<Opgave> opgaverList = await opgaveQuery.ToListAsync();
                List<OpgaveModel> opgaver = new List<OpgaveModel>();
                opgaverList.ForEach(opgave =>
                {
                    opgaver.Add(new OpgaveModel
                    {
                        AgeRestriction = opgave.AgeRestriction,
                        Description = opgave.Description,
                        Name = opgave.Name,
                        OpgaveId = opgave.OpgaveId
                    });
                });
                return opgaver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<string> Create(OpgaveModel opgaveCreateModel)
        {
            try
            {
                Opgave opgave = new Opgave
                {
                    Name = opgaveCreateModel.Name,
                    Description = opgaveCreateModel.Description,
                    AgeRestriction = opgaveCreateModel.AgeRestriction
                };
                await opgave.Create(_inCaptivaContext);

                return ($"Opgave {opgaveCreateModel.Name} er blevet oprettet");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OpgaveModel> Read(int id)
        {
            Opgave opgave = await _inCaptivaContext.Opgaver.SingleOrDefaultAsync(x => x.OpgaveId == id);

            if (opgave != null)
            {
                OpgaveModel opgaveModel = new OpgaveModel
                {
                    AgeRestriction = opgave.AgeRestriction,
                    Description = opgave.Description,
                    Name = opgave.Name,
                    OpgaveId = opgave.OpgaveId
                };
                return opgaveModel;
            }

            return null;
        }

        [HttpPut]
        [Route("")]
        public async Task<string> Update(OpgaveModel opgaveUpdateModel)
        {
            try
            {
                Opgave opgave =
                    await _inCaptivaContext.Opgaver.SingleOrDefaultAsync(x => x.OpgaveId == opgaveUpdateModel.OpgaveId);
                if (opgave != null)
                {
                    opgave.Description = opgaveUpdateModel.Description;
                    opgave.Name = opgaveUpdateModel.Name;
                    opgave.AgeRestriction = opgaveUpdateModel.AgeRestriction;

                    await opgave.Update(_inCaptivaContext);
                }

                return ($"Opgave med navn: {opgaveUpdateModel.Name} er blevet opdateret");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}