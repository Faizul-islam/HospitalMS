using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.PositionModels
{
    public interface IPositionRepository
    {
        Position GetPosition(int id);
        IEnumerable<Position> GetAllPosition();
        Position Add(Position position);
        Position Update(Position positionChanges);
        Position Delete(int id);
    }
}
