
using Wpm.Management.Domain;
using Wpm.Management.Domain.Enum;
using Wpm.Management.Domain.Service;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Tests;

public class PetTest
{
    /*
    [Fact]
    public void Pet_debe_ser_igual()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Tom", 10, "Broun", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Jen", 13, "Black", SexOfPet.Female, breedId);
        Assert.True(pet1.Equals(pet2));
    }*/

    [Fact]
    public void Peso_debe_ser_igual()
    {
        var peso1 = new Weight(20.5m);
        var peso2 = new Weight(20.5m);
        Assert.True(peso1.Equals(peso2));
    }

    [Fact]
    public void Rango_peso_debe_ser_igual()
    {
        var peso1 = new WeightRange(20.5m, 10.5m);
        var peso2 = new WeightRange(20.5m, 10.5m);
        Assert.True(peso1.Equals(peso2));
    }
/*
    [Fact]
    public void BreedId_debe_ser_igual()
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_debe_ser_no_valido()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentException>(() => {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeigthEnum_debe_ser_underweigth()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Tom", 10, "Broun", SexOfPet.Male, breedId);
        pet1.SetWeigth(new Weight(8.5m), breedService);
        Assert.True(pet1.WeightEnum == WeightEnum.Underweight);
    }

    [Fact]
    public void WeigthEnum_debe_ser_over()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Tom", 10, "Broun", SexOfPet.Male, breedId);
        pet1.SetWeigth(new Weight(28.5m), breedService);
        Assert.True(pet1.WeightEnum == WeightEnum.Overweight);
    }
    
    [Fact]
    public void WeigthEnum_debe_ser_ideal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Tom", 10, "Broun", SexOfPet.Male, breedId);
        pet1.SetWeigth(new Weight(10.11m), breedService);
        var xxx = pet1.WeightEnum;
        Assert.True(pet1.WeightEnum == WeightEnum.Ideal);
    }
*/
}

