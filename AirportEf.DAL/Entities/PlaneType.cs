namespace AirportEf.DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Airport.Common.Requests;

    public class PlaneType : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PlaneModel { get; set; }

        [Required]
        [Range(2, 1000)]
        public int MaxNumberOfPlaces { get; set; }

        [Required]
        [Range(1000, 1000000)]
        public int MaxCarryingCapacityKg { get; set; }

        public ICollection<Plane> Planes { get; set; }

        public PlaneType() { }

        public PlaneType(PlaneTypeRequest request, int id)
        {
            Id = id;
            PlaneModel = request.PlaneModel;
            MaxNumberOfPlaces = request.MaximalNumberOfPlaces;
            MaxCarryingCapacityKg = request.MaximalCarryingCapacityKg;
        }
    }
}
