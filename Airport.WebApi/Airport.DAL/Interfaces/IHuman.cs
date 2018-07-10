namespace Airport.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IHuman<T> : IEntity<T>
    {
        string FirstName { get; set; }
        string SecondName { get; set; }
        DateTime DateOfBirth { get; set; }

        ICollection<ICrew> Crews { get; set; }
    }
}