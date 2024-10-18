using Wpm.Clinic.Domain.ValueObject;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Tests;

public class ClinicDomainTests
{
    [Fact]
    public void Consulta_debe_estar_iniciada()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        Assert.True(consulta.Status == ConsultationStatus.Started);
    }

    [Fact]
    public void Consulta_no_debe_tener_fecha_de_finalizacion()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        Assert.Null(consulta.ConsultationEnd);
    }

    [Fact]
    public void Consulta_no_debe_finalizar_si_faltan_datos()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(consulta.End);
    }

    [Fact]
    public void Consulta_debe_finalizar_con_datos()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        consulta.SetTratment("Tratamiento");
        consulta.SetWeigth(new Weight(18.5m));
        consulta.SetDiagnosis("Diagnostico");
        consulta.End();
        Assert.True(consulta.Status == ConsultationStatus.Finalized);
    }

    [Fact]
    public void Consulta_no_debe_permitir_cambio_de_peso()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        consulta.SetTratment("Tratamiento");
        consulta.SetWeigth(new Weight(18.5m));
        consulta.SetDiagnosis("Diagnostico");
        consulta.End();
        Assert.Throws<InvalidOperationException>(() => consulta.SetWeigth(new Weight(16.5m)));
    }

    [Fact]
    public void Consulta_no_debe_permitir_cambio_de_diagnostico_cd_consulta_finalizada()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        consulta.SetTratment("Tratamiento");
        consulta.SetWeigth(new Weight(18.5m));
        consulta.SetDiagnosis("Diagnostico");
        consulta.End();
        Assert.Throws<InvalidOperationException>(() => consulta.SetDiagnosis("Nuevo Diagnostico"));
    }

    [Fact]
    public void Consulta_no_debe_permitir_cambio_de_tratamiento_cd_consulta_finalizada()
    {
        var consulta = new Conusltation(Guid.NewGuid());
        consulta.SetTratment("Tratamiento");
        consulta.SetWeigth(new Weight(18.5m));
        consulta.SetDiagnosis("Diagnostico");
        consulta.End();
        Assert.Throws<InvalidOperationException>(() => consulta.SetTratment("Nuevo Tratamiento"));
    }

    [Fact]
    public void Agregar_medicamento(){
        var drugId = new DrugId(Guid.NewGuid());
        var consulta = new Conusltation(Guid.NewGuid());
        var dose  = new Dose(1, UnitOfMeasure.tablet);
        consulta.AdministraterDrug(drugId, dose);
        Assert.True(consulta.AdministrerDrug.Count == 1);
        Assert.True(consulta.AdministrerDrug.First().DrugId == drugId);
    }



}