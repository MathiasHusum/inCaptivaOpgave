using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.DAL;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Entities
{
    public class Vagt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VagtId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Medarbejder Medarbejder { get; set; }

        public virtual ICollection<Opgave> Opgaver { get; set; }

        public async Task Create(InCaptivaContext dbContext)
        {
            await dbContext.Vagter.AddAsync(this);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(InCaptivaContext dbContext)
        {
            Vagt vagt = await dbContext.Vagter.SingleOrDefaultAsync(x => x.VagtId == VagtId);
            if (vagt == null)
            {
                throw new NullReferenceException($"Kunne ikke finde Vagt med id = {VagtId}");
            }

            vagt.End = End;
            vagt.Medarbejder = Medarbejder;
            vagt.Opgaver = Opgaver;
            vagt.Start = Start;

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}