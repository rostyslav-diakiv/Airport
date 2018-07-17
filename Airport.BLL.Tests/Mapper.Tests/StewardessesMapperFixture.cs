namespace Airport.BLL.Tests.Mapper.Tests
{
    using AirportEf.BLL.Mapper;

    using AutoMapper;

    public class StewardessesMapperFixture
    {
        public StewardessesMapperFixture()
        {
            //Arrange
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<StewardessProfile>(); });

            //Act

            //Assert
            Mapper.AssertConfigurationIsValid();
        }
    }
}
