﻿using System.Collections.Generic;
using Vezeeta.Models;

namespace Vezeeta.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDectors();
        IEnumerable<Doctor> GetAvailableDoctors();
        Doctor GetDoctor(int id);
        Doctor GetProfile(string userId);
        void Add(Doctor doctor);
    }
}