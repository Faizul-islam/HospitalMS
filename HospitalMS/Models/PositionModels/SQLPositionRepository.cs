using HospitalMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PositionModels
{
    public class SQLPositionRepository : IPositionRepository
    {
        private readonly AppDbContext context;

        public SQLPositionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Position Add(Position position)
        {
            throw new NotImplementedException();
        }

        public Position Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetAllPosition()
        {
            return context.Position;
        }

        public Position GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public Position Update(Position positionChanges)
        {
            var position = context.Position.Attach(positionChanges);
            position.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return positionChanges;
        }
    }
}
