using Wpm.Management.Api.Application;
using Wpm.Management.Api.Infraestructure;
using Wpm.Management.Domain;

namespace Wpm.Management.Api.Services;

public class ManagementApplicationService
{
    //private readonly IBreedService _breedService;
    private readonly ManagementDbContext _dbContext;

    public ManagementApplicationService( ManagementDbContext context)
    {
        //_breedService = breedService;
        _dbContext = context;
    }

    public async Task Handle(CreatePetCommand createPet){
        var breedId = new BreedId(createPet.BreedId);
        var newPet = new Pet(createPet.Id, createPet.Name, createPet.Age, 
                            createPet.Color, createPet.SexOfPet, breedId);
        await _dbContext.Pets.AddAsync(newPet);
        await _dbContext.SaveChangesAsync();
    }
}
