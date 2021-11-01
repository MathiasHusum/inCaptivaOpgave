using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.DAL;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Entities
{
    public class Opgave
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OpgaveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }

        public async Task Create(InCaptivaContext dbContext)
        {
            await dbContext.Opgaver.AddAsync(this);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(InCaptivaContext dbContext)
        {
            Opgave opgave = await dbContext.Opgaver.FirstOrDefaultAsync(x => x.OpgaveId == OpgaveId);

            if (opgave == null)
            {
                throw new NullReferenceException($"Kunne ikke finde Opgave med id = {OpgaveId}");
            }

            opgave.Description = Description;
            opgave.Name = Name;
            opgave.AgeRestriction = AgeRestriction;

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}