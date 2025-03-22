using NET.Veterinary.CA.Domain.AggregateRoots;

namespace NET.Veterinary.CA.Domain.IRepositories
{
    public interface IAppointmentRepository:IDisposable
    {
        public Task<ICollection<Appointment>> FetchAppointmentsByCurrentDateAsync(DateTime currentDate, CancellationToken cancellationToken);
        
        public Task<Appointment> FetchAppointmentByIdAsync(int appointmentId, CancellationToken cancellationToken);
        
        public Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken cancellationToken);
        
        public Task UpdateAppointmentAssistAsync(Appointment appointment, CancellationToken cancellationToken);
        
        public void RemoveAppointment(Appointment appointment);
        
        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}