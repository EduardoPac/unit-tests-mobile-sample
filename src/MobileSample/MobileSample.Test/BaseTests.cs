using System;
using Bogus;
using MobileSample.Test.Util;

namespace MobileSample.Test
{
    public abstract class BaseTests
    {
        protected readonly EntitiesFactory EntitiesFactory;
        const string CompanyId = "Test";

        protected BaseTests()
        {
            var faker = new Faker();
            EntitiesFactory = new EntitiesFactory(faker, CompanyId);
        }
    }
}