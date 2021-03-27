﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext db;

        public PieRepository(AppDbContext appDbContext)
        {
            db = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return db.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return db.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return db.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
