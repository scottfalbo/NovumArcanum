///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Mapper;

namespace ArcanumTests.Mapping
{
    [TestClass]
    public class AutoMapperTests
    {
        [TestMethod]
        public void AutoMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config => config.AddProfile<MapperProfile>());
            configuration.AssertConfigurationIsValid();
        }
    }
}