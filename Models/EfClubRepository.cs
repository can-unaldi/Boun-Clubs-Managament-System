using BounClubs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class EfClubRepository : IClubRepository
    {
        private ApplicationOtherDbContext context;
        public EfClubRepository(ApplicationOtherDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Club> Clubs => context.Clubs;

        public void CreateClub(Club club)
        {
            context.Clubs.Add(club);
            context.SaveChanges();
        }

        public void DeleteClub(int clubId)
        {
            var club = GetById(clubId);
            if (club != null)
            {
                context.Clubs.Remove(club);
                context.SaveChanges();
            }
        }

        public Club GetById(int clubId)
        {
            return context.Clubs.FirstOrDefault(i => i.ClubId == clubId);
        }

        public void UpdateClub(Club club)
        {
            context.Clubs.Update(club);
            context.SaveChanges();
        }
    }
}
