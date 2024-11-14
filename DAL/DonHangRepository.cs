﻿using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class DonHangRepository : Repository<DonHang>, IDonHangRepository
    {
        public DonHangRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
