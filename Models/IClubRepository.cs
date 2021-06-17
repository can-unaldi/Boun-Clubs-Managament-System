using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public interface IClubRepository
    {
        Club GetById(int clubId);
        IQueryable<Club> Clubs { get; }
        void CreateClub(Club club);
        void UpdateClub(Club club);
        void DeleteClub(int clubId);
    }
}
