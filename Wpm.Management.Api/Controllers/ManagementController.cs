using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;
using Wpm.Management.Api.Services;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : ControllerBase
{
    private readonly ManagementApplicationService _managementApplicationService;
    //private readonly IBreedService _breedService;
    public ManagementController(ManagementApplicationService managementApplicationService){
        _managementApplicationService = managementApplicationService;
        //_breedService = breedService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreatePetCommand createPet){
        await _managementApplicationService.Handle(createPet);
        return Ok();
    }
}
