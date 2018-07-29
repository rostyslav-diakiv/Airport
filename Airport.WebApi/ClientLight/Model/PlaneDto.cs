namespace ClientLight.Model
{
    using System;
    using ClientLight.Interfaces;

    public class PlaneDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public Age LifeTimeAge { get; set; }

        public PlaneTypeDto PlaneType { get; set; }
    }
}
