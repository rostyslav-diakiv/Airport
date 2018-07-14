namespace AirportEf.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Human<T> : Entity<T>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FamilyName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        protected Human()
        {
        }
    }
}
