using System;
using Wpm.Clinic.Domain.ValueObject;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class DrugAdministration : Entity
{
    public DrugId DrugId { get; init; }
    public Dose Dose  {get; init;}

    public DrugAdministration(DrugId drugId, Dose dose)
    {
        Id = Guid.NewGuid();
        DrugId = drugId;
        Dose = dose;
    }
}

