using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.DAL;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Entities
{
    public class Medarbejder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MedarbejderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Vagt> Vagter { get; set; }

        public async Task Create(InCaptivaContext dbContext)
        {
            await dbContext.Medarbejdere.AddAsync(this);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(InCaptivaContext dbContext)
        {
            Medarbejder medarbejder =
                await dbContext.Medarbejdere.FirstOrDefaultAsync(x => x.MedarbejderId == MedarbejderId);

            if (medarbejder == null)
            {
                throw new NullReferenceException($"Kunne ikke finde medarbejder med id = {MedarbejderId}");
            }

            medarbejder.Age = Age;
            medarbejder.FirstName = FirstName;
            medarbejder.LastName = LastName;
            medarbejder.Vagter = Vagter;

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}