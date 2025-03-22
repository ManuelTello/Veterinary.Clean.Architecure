namespace NET.Veterinary.CA.Domain.AggregateRoots
{
    public sealed class Appointment
    {
        public int Id { get; private set; }

        public bool DidAssist { get; private set; }

        public DateTime DateSelected { get; private set; }

        public string PatientName { get; private set; }

        public int Identification { get; private set; }

        public Appointment(int id, bool didAssist, DateTime dateSelected, string patientName, int identification)
        {
            this.Id = id;
            this.DidAssist = didAssist;
            this.DateSelected = dateSelected;
            this.PatientName = patientName;
            this.Identification = identification;
        }

        private Appointment() { }
    }
}