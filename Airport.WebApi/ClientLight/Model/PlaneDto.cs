namespace ClientLight.Model
{
    using System;
    using ClientLight.Interfaces;

    public class PlaneDto : IEntity<int>
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now.AddYears(-2);

        public Age LifeTimeAge { get; set; } = new Age();

        public PlaneTypeDto PlaneType { get; set; } = new PlaneTypeDto();
    }
}
