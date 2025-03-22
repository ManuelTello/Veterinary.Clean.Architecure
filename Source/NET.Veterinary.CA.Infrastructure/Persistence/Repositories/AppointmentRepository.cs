using Microsoft.EntityFrameworkCore;
using NET.Veterinary.CA.Domain.AggregateRoots;
using NET.Veterinary.CA.Domain.IRepositories;
using NET.Veterinary.CA.Infrastructure.Persistence.Context;

namespace NET.Veterinary.CA.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly ApplicationContext _context;
        
        private bool _disposed;

        public AppointmentRepository(ApplicationContext context)
        {
            this._context = context; 
        }
        
        public async Task<ICollection<Appointment>> FetchAppointmentsByCurrentDateAsync(DateTime currentDate, CancellationToken cancellationToken)
        {
            ICollection<Appointment> appointments = await this._context.Appointments
                .Where(a => a.DateSelected.Equals(currentDate))
                .ToListAsync(cancellationToken);
            
            return appointments;
        }

        public async Task<Appointment> FetchAppointmentByIdAsync(int appointmentId, CancellationToken cancellationToken)
        {
            Appointment appointment = await this._context.Appointments.SingleAsync(a => a.Id == appointmentId, cancellationToken);
            return appointment;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            var result = await this._context.Appointments.AddAsync(appointment, cancellationToken); 
            return result.Entity;
        }

        public async Task UpdateAppointmentAssistAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            await this._context.Appointments.Where(a => a.Id == appointment.Id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(b => b.DidAssist, true), cancellationToken);
        }

        public void RemoveAppointment(Appointment appointment)
        {
            this._context.Appointments.Remove(appointment);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}