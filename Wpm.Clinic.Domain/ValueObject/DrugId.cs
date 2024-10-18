using System;

namespace Wpm.Clinic.Domain.ValueObject;

public record DrugId
{
    public Guid Id { get; init;}

    public DrugId(Guid id)
    {
        Id = id;
    }
}
