using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vezeeta.Models;

namespace Vezeeta.Services
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
    }
    public class PatientService : IPatientService
    {
        private readonly VezeetaIdentity VezeetaIdentity;
        public PatientService()
        {
            VezeetaIdentity = new VezeetaIdentity();
        }
        public Patient Create(Patient patient)
        {
            VezeetaIdentity.Patients.Add(patient);
            var savingResult= VezeetaIdentity.SaveChanges();
            if(savingResult > 0)
            {
                return patient;

            }
            return null;
        }
    }
}