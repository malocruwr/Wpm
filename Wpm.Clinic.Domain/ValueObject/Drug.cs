using System;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class Drug : Entity
{
    public Drug(Guid guid)
    {
         Id = guid;
    }

    public string  Name { get; init; }
}
