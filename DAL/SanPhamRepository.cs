﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamRepository : Repository<SanPham>, ISanPhamRepository
    {
        public SanPhamRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
