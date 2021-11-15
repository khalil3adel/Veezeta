using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace Vezeeta.Models
{
    public class VezeetaIdentity : IdentityDbContext<MyIdentityUser>
    {
        public VezeetaIdentity():base("VezeetaIdentity")
        {
                
        }
        public virtual DbSet<Admin> Admins { set; get; }
        public virtual DbSet<Patient> Patients { set; get; }
        public virtual DbSet<Doctor> Doctors { set; get; }
        public virtual DbSet<Rating> Ratings { set; get; }
        public virtual DbSet<Appointment> Appointments { set; get; }
        public virtual DbSet<Insurance> Insurances { set; get; }
        public virtual DbSet<InsuranceDoctor> InsuranceDoctors { set; get; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Area> Areas { set; get; }
       // public virtual DbSet<MyIdentityUser> MyIdentityUsers { set; get; }

        public System.Data.Entity.DbSet<Vezeeta.ViewModel.AppointmentFormViewModel> AppointmentFormViewModels { get; set; }

    }
    public class MyIdentityUser : IdentityUser
    {

    }

}