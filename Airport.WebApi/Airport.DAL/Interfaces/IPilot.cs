namespace Airport.DAL.Interfaces
{
    using System;

    public interface IPilot : IHuman<int>
    {
        TimeSpan Experience { get; set; }
    }
}