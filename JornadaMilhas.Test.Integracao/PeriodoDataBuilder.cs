using Bogus;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao;
internal class PeriodoDataBuilder: Faker<Periodo>
{
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }

    public PeriodoDataBuilder()
    {
        CustomInstantiator(f =>
            {
                DateTime dataInicio = DataInicial ?? f.Date.Soon();
                DateTime dataFinal = DataFinal ?? dataInicio.AddDays(30);
                return new Periodo(dataInicio, dataFinal);
            });
    }

    public Periodo Build() => Generate();


}
