using Bogus;

namespace MobileSample.Test.Util
{
    public abstract class BaseTests
    {
        protected readonly EntitiesFactory EntitiesFactory;
        const string CompanyId = "Test";
        const int NumItems = 10; 

        protected BaseTests()
        {
            var faker = new Faker();
            EntitiesFactory = new EntitiesFactory(faker, CompanyId, NumItems);
        }
    }
}