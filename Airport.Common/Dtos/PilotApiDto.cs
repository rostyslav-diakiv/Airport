namespace Airport.Common.Dtos
{
    using System;

    public class PilotApiDto : HumanApiDto
    {
        public int Exp { get; set; } // TODO: After deserialization convert to TimeSpan

        public PilotApiDto()
        {
        }
    }
}
