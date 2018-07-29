namespace ClientLight.Requests
{
    using System;
    using ClientLight.Model;

    public class PlaneRequest
    {
        public PlaneRequest(PlaneDto dto)
        {
            Name = dto.Name;
            CreationDate = dto.CreationDate;
            LifeTime = new TimeSpan(dto.LifeTimeAge.Years * 366, 0, 0, 0);
            PlaneTypeId = dto.PlaneType.Id;
        }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }

        public int PlaneTypeId { get; set; }
    }
}
