namespace AirportEf.DAL.Entities
{
    using System.Collections.Generic;

    using Airport.Common.Requests;

    public sealed class Stewardess : Human<int>
    {
        public override int Id { get; set; }

        public ICollection<CrewStewardess> CrewStewardess { get; set; }

        public Stewardess() { }

        public Stewardess(StewardessRequest request, int id)
        {
            Id = id;
            FirstName = request.Name;
            FamilyName = request.FamilyName;
            DateOfBirth = request.DateOfBirth;
        }
    }
}
