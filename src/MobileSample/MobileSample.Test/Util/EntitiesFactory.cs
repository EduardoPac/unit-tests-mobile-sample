using System.Collections.Generic;
using Bogus;
using BurgerMonkeys.Tools;
using MobileSample.Core.Enums;
using MobileSample.Core.Models;

namespace MobileSample.Test.Util
{
    public class EntitiesFactory
    {
        readonly Faker _faker;
        readonly string _companyId;

        public EntitiesFactory(Faker faker, string companyId)
        {
            _faker = faker;
            _companyId = companyId;
        }


        public Manufacturer GetNewManufacturer()
        {
            return new Manufacturer
            {
                Id = Generator.GetId(8),
                Name = _faker.Vehicle.Manufacturer(),
                CompanyId = _companyId,
                Country = _faker.Address.Country()
            };
        }

        public Manufacturer GetNewManufacturerParameterized(string id, string companyId, string name, string country)
        {
            return new Manufacturer
            {
                Id = id,
                Name = name,
                CompanyId = companyId,
                Country = country
            };
        }

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

        public User GetNewUserParameterized(string id, string companyId, string name, string[] vehiclesIds,
                                            List<Vehicle> vehicles = null)
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

        public Vehicle GetNewVehicle()
        {
            return new Vehicle
            {
                Id = Generator.GetId(8),
                Name = _faker.Vehicle.Model(),
                CompanyId = _companyId,
                ManufacturerId = Generator.GetId(8),
                Manufacturer = null,
                VehicleClass = GetRandomEVehicleClass(_faker.Random.Int(0, 4))
            };
        }

        public Vehicle GetNewVehicleParametrized(string id, string name, string companyId, string manufacturerId)
        {
            return new Vehicle
            {
                Id = id,
                Name = name,
                CompanyId = companyId,
                ManufacturerId = manufacturerId,
                Manufacturer = null,
                VehicleClass = GetRandomEVehicleClass(_faker.Random.Int(0, 4))
            };
        }

        static EVehicleClass GetRandomEVehicleClass(int index)
        {
            return index switch
            {
                0 => EVehicleClass.Exotic,
                1 => EVehicleClass.Muscle,
                2 => EVehicleClass.Tuner,
                3 => EVehicleClass.OffRoad,
                _ => EVehicleClass.Tuner
            };
        }

        static EConductorClass GetRandomEConductorClass(int index)
        {
            return index switch
            {
                0 => EConductorClass.A,
                1 => EConductorClass.B,
                2 => EConductorClass.C,
                3 => EConductorClass.D,
                4 => EConductorClass.E,
                5 => EConductorClass.AB,
                6 => EConductorClass.AC,
                7 => EConductorClass.AD,
                8 => EConductorClass.AE,
                _ => EConductorClass.None
            };
        }

        public string[] GetArrayStringIds(int count)
        {
            var ids = new List<string>();
            for (int i = 0; i < count; i++)
            {
                ids.Add(Generator.GetId(8));
            }

            return ids.ToArray();
        }
    }
}