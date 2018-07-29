namespace ClientLight.Requests
{
    using System;

    using ClientLight.Model;

    public class StewardessRequest
    {
        public StewardessRequest() { }

        public StewardessRequest(StewardessDto dto)
        {
            Name = dto.Name;
            FamilyName = dto.FamilyName;
            DateOfBirth = dto.DateOfBirth;
        }
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
