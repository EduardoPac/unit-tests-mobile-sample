# Unit test framework guidelines to mobile projects

The use of unit tests is a necessary practice for our codes to ensure that the expected behavior of each component of the system is performed correctly. In the mobile world, the importance of this practice becomes **inevitable**, as we are talking about several devices with different configurations. After testing a code, we can predict errors before we even release a new version of the application.

The sera from the guidelines were divided into:

- Packages used for testing 
- Good test creation practices
- Structure of the test project
- Nomenclature standards
- Test class structure
- Test method structure

##Packages used for testing

Pacotes utilizados no projeto de tests

Packages | Version | Description
:-|:-:|:-
xUnit| [2.4.1](https://www.nuget.org/packages/xunit/) | .Net testing framework
Bogus|[29.0.2](https://www.nuget.org/packages/Bogus/)| Fake object generator to papulate entity data
BurgerMonkeys.Tools| [1.1.0](https://www.nuget.org/packages/BurgerMonkeys.Tools/) | Gerador de Ids string
Moq|[4.14.1](https://www.nuget.org/packages/Moq/) | Mocking Framework for .Net
FluentAssertions|[5.10.3](https://www.nuget.org/packages/FluentAssertions/)| The assertions look beautiful, natural and, most importantly, extremely readable


##Good test creation practices

Unit tests should be simple to write and rewrite when necessary; in that case, always use the **KISS** principle (keep it simple, stupid). If the test is getting too big to be mounted on the Arrange, the method being tested is very complex and needs to be refactored.

A test should be **legible** to the point that someone can see the test code and understand what it does, even without knowing the business rule you are testing.

The test coverage does not have to be 100% of the project, but we will use the **80/20** principle to know that 20% of the project code is equivalent to 80% of the possible causes of errors when they are changed. This must be taken into account when creating the tests.

A unit test should simulate the method being tested in two ways.
- **The Valid Test** - You must simulate the perfect flow for which the code was designed
- **The invalid test** - It is necessary to simulate possible errors in the code flow, such as mandatory parameters that are not as they should be and possible returns, if this occurs.


##Structure of the test project

For the unit tests proposed in this guideline, we will structure our test project in two folders **Tests** and **Util**.
- Tests: Project tests will be grouped.
- Util: Will be where we will put the classes and interfaces used for the tests.

In tests we have the separation of two test areas:
- Services: We will create the tests for the service class methods.
- Entities: We will create the entity tests, such as validation of mandatory properties.

**Tests**

**Services**

The proposed structure for mobile applications at its core is the pattern **Service/Repository**. In MVVM projects the **ViewModel** layer will communicate with the services to get and save the data.
In services we will do all the treatment of the objects coming from the VM and thus communicate with the API or even with the **Repository** that will make Crud with the chosen database.

**Entities**

In the proposed structure, we are no longer responsible for the entity, validating the data being tested. With the **ValidatePropertiesRequired** method.

````
public bool ValidatePropertiesRequired()
{
    return !string.IsNullOrWhiteSpace(Id) &&
           !string.IsNullOrWhiteSpace(Name) &&
           !string.IsNullOrWhiteSpace(CompanyId) &&
           !string.IsNullOrWhiteSpace(Country);
}
`````
**Util**

In the Util folder of the project we have the following classes and interfaces created:
- BaseTests - Where we configure the properties used in all tests
- EntitiesFactory - Class for creating entities.
- IBaseEntitiesTests - Interface used for entity testing
- IBaseServiceTests - Insterface used for testing services

**BaseTests**

In this class we started the **EntitiesFactory** used in the tests and specifications, some properties that we will use to generate the entities.

````
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
````

**EntitiesFactory**

In this class we create the methods to create a test object. For this guideline we will separate in 3 methods for each entity.
- Get[Entity]
- Ger[Entity]Parameterized
- Get[Entity]List

````
public User GetNewUser()
{
    return new User
    {
        Id = Generator.GetId(8),
        Name = _faker.Person.FullName,
        CompanyId = _companyId,
        Age = _faker.Random.Int(1, 100),
        Email = _faker.Person.Email,
        ConductorClass = GetRandomEConductorClass(_faker.Random.Int(0, 6)),
        Vehicles = null,
        VehicleIds = GetArrayStringIds(_faker.Random.Int(1, 10))
    };
}

public User GetNewUserParameterized(string id, string companyId, string name, string[] vehiclesIds, List<Vehicle> vehicles = null)
{
    return new User
    {
        Id = id,
        Name = name,
        CompanyId = companyId,
        Age = _faker.Random.Int(1, 100),
        Email = _faker.Person.Email,
        ConductorClass = GetRandomEConductorClass(_faker.Random.Int(0, 6)),
        Vehicles = vehicles,
        VehicleIds = vehiclesIds
    };
}

public List<User> GetUserList()
{
    var users = new List<User>();
    for (int i = 0; i < _numItems; i++)
    {
        users.Add(GetNewUser());
    }

    return users;
}
````
In this method to generate random data we use two packages:
- Bogus - When creating the **Faker** object, we can generate numerous types of data. More information [here](https://github.com/bchavez/Bogus)
- BurgerMonkeys.Tools - We use a library method to generate dynamic string Ids. More information [here](https://github.com/BurgerMonkeys/burgermonkeystools)

**Interfaces**
Both interfaces will be used later in the tests. The methods on these interfaces are used regardless of which entity will be tested.

**IBaseEntitiesTests**
````
public interface IBaseEntitiesTests
{
    public void PropertiesRequiredValid();
}
````

**IBaseServiceTests**
````
public interface IBaseServiceTests
{
    void GetAllValid();
    void GetByCompanyIdValid();
    void GetByIdValid();
    void ImportValid();
    void SaveValid();
    void RemoveValid();
}
````

##Nomenclature standards



##Test class structure



##Test method structure


