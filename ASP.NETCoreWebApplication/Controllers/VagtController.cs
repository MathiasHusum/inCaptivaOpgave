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
    [Route("api/vagter")]
    public class VagtController : ControllerBase
    {
        private readonly InCaptivaContext _inCaptivaContext;

        public VagtController(InCaptivaContext inCaptivaContext)
        {
            _inCaptivaContext = inCaptivaContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<VagtModel>> Index()
        {
            try
            {
                IQueryable<Vagt> vagtQuery = _inCaptivaContext.Vagter.AsQueryable();

                List<Vagt> vagtList = await vagtQuery.ToListAsync();
                List<VagtModel> vagter = new List<VagtModel>();
                vagtList.ForEach(vagt =>
                {
                    vagter.Add(new VagtModel
                    {
                        End = vagt.End,
                        Medarbejder = vagt.Medarbejder,
                        Opgaver = vagt.Opgaver,
                        Start = vagt.Start,
                        VagtId = vagt.VagtId
                    });
                });
                return vagter;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<string> Create(VagtModel vagtCreateModel)
        {
            try
            {
                Vagt vagt = new Vagt
                {
                    End = vagtCreateModel.End,
                    Medarbejder = vagtCreateModel.Medarbejder,
                    Opgaver = vagtCreateModel.Opgaver,
                    Start = vagtCreateModel.Start
                };
                await vagt.Create(_inCaptivaContext);

                return ($"Vagt med følgende opgaver er blevet oprettet: {vagtCreateModel.Opgaver}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<VagtModel> Read(int id)
        {
            Vagt vagt = await _inCaptivaContext.Vagter.SingleOrDefaultAsync(x => x.VagtId == id);

            if (vagt != null)
            {
                VagtModel vagtModel = new VagtModel
                {
                    End = vagt.End,
                    Medarbejder = vagt.Medarbejder,
                    Opgaver = vagt.Opgaver,
                    Start = vagt.Start,
                    VagtId = vagt.VagtId
                };
                return vagtModel;
            }

            return null;
        }

        [HttpPut]
        [Route("")]
        public async Task<string> Update(VagtModel vagtUpdateModel)
        {
            try
            {
                Vagt vagt = await _inCaptivaContext.Vagter.SingleOrDefaultAsync(x =>
                    x.VagtId == vagtUpdateModel.VagtId);

                if (vagt != null)
                {
                    VagtModel vagtModel = new VagtModel
                    {
                        End = vagt.End,
                        Medarbejder = vagt.Medarbejder,
                        Opgaver = vagt.Opgaver,
                        Start = vagt.Start

                    };
                    await vagt.Update(_inCaptivaContext);
                }

                return ($"Vagt med VagtId: {vagtUpdateModel.VagtId} er blevet opdateret"); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}