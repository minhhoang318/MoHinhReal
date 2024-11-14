﻿using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class NguoiDungRepository : Repository<NguoiDung>, INguoiDungRepository
    {
        public NguoiDungRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}