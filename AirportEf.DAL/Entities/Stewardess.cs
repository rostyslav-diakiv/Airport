namespace AirportEf.DAL.Entities
{
    using Airport.Common.Requests;

    public sealed class Stewardess : Human<int>
    {
        public override int Id { get; set; }

        public Stewardess() { }

        public Stewardess(StewardessRequest request, int id = 0)
        {
            Id = id;
            FirstName = request.Name;
            FamilyName = request.FamilyName;
            DateOfBirth = request.DateOfBirth;
        }
    }
}
