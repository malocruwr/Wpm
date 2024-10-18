using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Service;

public interface IBreedService
{
    Breed? GetBreed(Guid id);
}

public class FakeBreedService: IBreedService{
    public static Guid BreedId1 = Guid.NewGuid();
    public static Guid BreedId2 = Guid.NewGuid();
    public readonly List<Breed> breeds = new List<Breed>{
        new(BreedId1, "Beagle", new WeightRange(10m,11m), new WeightRange(9m,11m)),
        new(BreedId2, "Terrier", new WeightRange(28m,40m), new WeightRange(24m,34m))
    };

    public Breed? GetBreed(Guid id){
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException("La raza no es valida");
        }
        var result = breeds.Find(b => b.Id == id);
        return result ?? throw new ArgumentException("La raza no se encontró");
    }
}
