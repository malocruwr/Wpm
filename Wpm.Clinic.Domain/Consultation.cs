using Wpm.Clinic.Domain.ValueObject;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;
public class Conusltation : AggregateRoot
{
    private readonly List<DrugAdministration> administrationsDrugs = new();
    private readonly List<VitalSings> vitalSingsReadings = new();
    public DateTime ConsultationStart { get; init; }
    public DateTime? ConsultationEnd { get; private set; }
    public PatientId PatientId { get; init; }
    public Text Diagnosis { get; private set; }
    public Text Treatment { get; private set; }
    public Weight CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public IReadOnlyCollection<DrugAdministration> AdministrerDrug => administrationsDrugs;
    public IReadOnlyCollection<VitalSings> VitalSings => vitalSingsReadings;

    public Conusltation(PatientId patientId)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        Status = ConsultationStatus.Started;
        ConsultationStart = DateTime.UtcNow;
    }

    public void RegisterVitalSings(IEnumerable<VitalSings> vitalSings){
        ValidateConsultationStatus();
        vitalSingsReadings.AddRange(vitalSings);
    }

    public void SetWeigth(Weight weight){
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }

    public void SetDiagnosis(Text diagnosis){
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }

    public void SetTratment(Text treatment){
        ValidateConsultationStatus()   ;
        Treatment = treatment;
    }

    public void AdministraterDrug(DrugId drugId, Dose dose){
        ValidateConsultationStatus() ;
        var newDrugAdministrarion = new DrugAdministration(drugId, dose);
        administrationsDrugs.Add(newDrugAdministrarion);
    }

    public void End(){
        ValidateConsultationStatus();
        if(Diagnosis == null || Treatment == null || CurrentWeight == null){
            throw new InvalidOperationException("La consulta no puede ser finalizada.");
        }
        Status = ConsultationStatus.Finalized;
        ConsultationEnd = DateTime.UtcNow;
    }

    private void ValidateConsultationStatus(){
        if (Status == ConsultationStatus.Finalized){
            throw new InvalidOperationException("La consulta está finalizada.");
        }
    }
}

public enum ConsultationStatus
{
    Started,
    Finalized
}