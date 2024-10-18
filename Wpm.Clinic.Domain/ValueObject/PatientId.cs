using System;

namespace Wpm.Clinic.Domain.ValueObject;

public record PatientId
{
    public Guid Id { get; init; }

    public PatientId(Guid id)
    {
        if (id == Guid.Empty){
            throw new ArgumentException("Id","El id del paciente no puede ser vacio.");
        }
        Id = id;
    }

    public static implicit operator PatientId(Guid id){
        return new PatientId(id);
    }
}
