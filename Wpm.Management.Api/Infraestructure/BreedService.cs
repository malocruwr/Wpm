using System;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Service;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infraestructure;

public interface IBreedService{
    Breed? GetBreed(Guid id);
}

public class BreedService : IBreedService
{
    public readonly List<Breed> breeds = new()
    {
        new Breed(Guid.Parse("dc500674-a81a-484a-a658-f51337390417"), "Test1", new WeightRange(10.8m, 20.6m), new WeightRange(11m,18m) ),
        new Breed(Guid.Parse("15c99e08-50a7-4de1-bb2c-6aaf0907bd2d"), "Test2", new WeightRange(38.8m, 40.6m), new WeightRange(24m,34m) ),
    };

    public BreedService()
    {
    }

    public Breed? GetBreed(Guid id){
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException("La raza no es valida");
        }
        var result = breeds.Find(b => b.Id == id);
        return result ?? throw new ArgumentException("La raza no se encontró");
    }
}
