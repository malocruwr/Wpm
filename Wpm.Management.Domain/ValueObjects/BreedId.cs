using System;
using Wpm.Management.Domain.Service;

namespace Wpm.Management.Domain;

public record BreedId
{
    private readonly IBreedService breedService;
    public Guid Id { get; init; }

    public BreedId(Guid id)
    {
        //this.breedService = breedService;
        //ValidateBreed(id);
        Id = id;
    }

    public static BreedId Create(Guid id){
        return new BreedId(id);
    }

    /*private BreedId(Guid id)
    {
        Id = id;
    }*/

    private void ValidateBreed(Guid id)
    {
        if(breedService.GetBreed(id) == null){
            throw new ArgumentException("No existe una raza con esta este id");
        }
    }
}
