using System;
using System.Collections.Generic;
using System.Linq;
using Vezeeta.Models;
using Vezeeta.ViewModel;

namespace Vezeeta.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentWithPatient(int id);
        IEnumerable<Appointment> GetAppointmentByDoctor(int id);
        IEnumerable<Appointment> GetTodaysAppointments(int id);
        IEnumerable<Appointment> GetUpcommingAppointments(string userId);
        IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate);
        IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel);
        bool ValidateAppointment(DateTime appntDate, int id);
        int CountAppointments(int id);
        Appointment GetAppointment(int id);
        void Add(Appointment appointment);

    }
}