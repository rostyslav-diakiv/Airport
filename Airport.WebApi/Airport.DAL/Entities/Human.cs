namespace Airport.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    using Airport.DAL.Interfaces;

    public abstract class Human<T> : Entity<T>, IHuman<T>
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<ICrew> Crews { get; set; }
    }
}
