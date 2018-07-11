namespace Airport.DAL.Entities
{
    using System.Threading;

    using Airport.Common.Requests;

    public sealed class Stewardess : Human<int>
    {
        private static int nextId = 0;

        public override int Id { get; set; }

        public Stewardess() { }

        public static Stewardess FromRequest(StewardessRequest request, int id)
        {
            return new Stewardess()
                       {
                           Id = id,
                           FirstName = request.Name,
                           FamilyName = request.FamilyName,
                           DateOfBirth = request.DateOfBirth
                       };
        }

        public static int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
