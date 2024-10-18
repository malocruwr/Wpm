using System;

namespace Wpm.Clinic.Domain.ValueObject;

public record VitalSings
{
    public DateTime ReadingDateTime { get; init; }
    public decimal Temperature { get; init; }
    public int HeartRate { get; init; }
    public int RespiratoryRate { get; init; }

    public VitalSings(DateTime readingDateTime, decimal temperature, int heartRate, int respiratoryRate)
    {
        ReadingDateTime = readingDateTime;
        Temperature = temperature;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }
}
