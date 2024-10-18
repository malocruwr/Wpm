using System;

namespace Wpm.Clinic.Domain.ValueObject;

public record Text
{
    public string Value { get; set; }

    public Text(string value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(string value){
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("value","Texto no valido.");
        }

        if(value.Length > 500){
            throw new ArgumentException("Texto demasiado largo.");
        }
    }

    public static implicit operator Text(string value){
        return new Text(value);
    }
}
