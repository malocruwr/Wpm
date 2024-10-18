using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain;

public class Breed : Entity
{
    public string Name { get; init; }
    public WeightRange MaleIdealWeight { get; init; }
    public WeightRange FemaleIdealWeight { get; init; }
    public Breed(Guid breedId ,string name, WeightRange maleIdealWeight, WeightRange femaleIdealWeight)
    {
        Id = breedId;
        Name = name;
        MaleIdealWeight = maleIdealWeight;
        FemaleIdealWeight = femaleIdealWeight;
    }
}


