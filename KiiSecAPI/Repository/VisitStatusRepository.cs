﻿using KiiSecAPI.Intefaces;
using KiiSecAPI.Models;

namespace KiiSecAPI.Data
{
    public class VisitStatusRepository : IVisitStatusRepository
    {
        private readonly DataContext _context;
        public VisitStatusRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<VisitStatus> GetVisitsStatus()
        {
            return _context.VisitsStatus.OrderBy(p => p.ID).ToList();
        }

        public bool VisitStatusExists(int id)
        {
            return _context.VisitsStatus.Any(v => v.ID == id);
        }
    }
}

