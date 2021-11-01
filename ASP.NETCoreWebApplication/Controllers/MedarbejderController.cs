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
    [Route("api/medarbejder")]
    public class MedarbejderController : ControllerBase
    {
        private readonly InCaptivaContext _inCaptivaContext;

        public MedarbejderController(InCaptivaContext inCaptivaContext)
        {
            _inCaptivaContext = inCaptivaContext;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MedarbejderModel>> Index()
        {
            try
            {
                IQueryable<Medarbejder> medarbejderQuery = _inCaptivaContext.Medarbejdere.AsQueryable();

                List<Medarbejder> medarbejdereList = await medarbejderQuery.ToListAsync();
                List<MedarbejderModel> medarbejdere = new List<MedarbejderModel>();
                medarbejdereList.ForEach(medarbejder =>
                {
                    medarbejdere.Add(new MedarbejderModel
                    {
                        Age = medarbejder.Age,
                        FirstName = medarbejder.FirstName,
                        LastName = medarbejder.LastName,
                        MedarbejderId = medarbejder.MedarbejderId,
                        Vagter = medarbejder.Vagter
                    });
                });
                return medarbejdere;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<string> Create(MedarbejderModel medarbejderCreateModel)
        {
            try
            {
                Medarbejder medarbejder = new Medarbejder
                {
                    Age = medarbejderCreateModel.Age,
                    FirstName = medarbejderCreateModel.FirstName,
                    LastName = medarbejderCreateModel.LastName,
                    Vagter = medarbejderCreateModel.Vagter
                };
                await medarbejder.Create(_inCaptivaContext);
                return (
                    $"Medarbejder: {medarbejderCreateModel.FirstName} {medarbejderCreateModel.LastName} blev oprettet");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<MedarbejderModel> Read(int id)
        {
            Medarbejder medarbejder =
                await _inCaptivaContext.Medarbejdere.SingleOrDefaultAsync(x => x.MedarbejderId == id);

            if (medarbejder != null)
            {
                MedarbejderModel medarbejderModel = new MedarbejderModel
                {
                    MedarbejderId = medarbejder.MedarbejderId,
                    Age = medarbejder.Age,
                    FirstName = medarbejder.FirstName,
                    LastName = medarbejder.LastName,
                    Vagter = medarbejder.Vagter
                };
                return medarbejderModel;
            }

            return null;

        }
        [HttpPut]
        public async Task<string> Update(MedarbejderModel medarbejderUpdateModel)
        {
            try
            {
                Medarbejder medarbejder =
                    await _inCaptivaContext.Medarbejdere.SingleOrDefaultAsync(x =>
                        x.MedarbejderId == medarbejderUpdateModel.MedarbejderId);

                if (medarbejder != null)
                {
                    medarbejder.Age = medarbejderUpdateModel.Age;
                    medarbejder.FirstName = medarbejderUpdateModel.FirstName;
                    medarbejder.LastName = medarbejderUpdateModel.LastName;
                    medarbejder.Vagter = medarbejderUpdateModel.Vagter;

                    await medarbejder.Update(_inCaptivaContext);
                }

                return ($"Medarbejder med ID {medarbejderUpdateModel.MedarbejderId} er blevet opdateret");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}