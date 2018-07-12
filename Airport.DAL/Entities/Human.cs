namespace Airport.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    public abstract class Human<T> : Entity<T>
    {
        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Crew> Crews { get; set; }

        protected Human()
        {
        }
    }
}
