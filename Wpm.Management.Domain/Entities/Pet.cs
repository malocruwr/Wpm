using Wpm.Management.Domain.Enum;
using Wpm.Management.Domain.Service;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain;
public class Pet: Entity
{
    public string Name { get; init; }
    public int Age{ get; init; }
    public string Color{ get; set; }
    public Weight? Weight { get; private set; }
    public SexOfPet SexOfPet { get; set; }
    public BreedId BreedId { get; init; }
    public WeightEnum WeightEnum { get; private set; }


    public Pet(Guid id, string name, int age, string color, SexOfPet sexOfPet, BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }

    public void SetWeigth(Weight weight, IBreedService breedService){
        Weight = weight;
        SetWeigthEnum(breedService) ;
    }

    private void SetWeigthEnum(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Id);
        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desiredBreed?.MaleIdealWeight.From, desiredBreed?.MaleIdealWeight.To),
            SexOfPet.Female => (desiredBreed?.FemaleIdealWeight.From, desiredBreed?.FemaleIdealWeight.To),
            _ => throw new NotImplementedException(),
        };

        WeightEnum = Weight?.Value switch
        {
            _ when Weight?.Value < from => WeightEnum.Underweight ,
            _ when Weight?.Value > to => WeightEnum.Overweight,
            _ => WeightEnum.Ideal
        };
    }
}
