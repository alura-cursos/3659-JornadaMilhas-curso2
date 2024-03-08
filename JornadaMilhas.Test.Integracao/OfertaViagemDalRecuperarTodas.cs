using JornadaMilhas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;
[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarTodas
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalRecuperarTodas(ITestOutputHelper output, ContextoFixture fixture)
    {
        context = fixture.Context;
        output.WriteLine(context.GetHashCode().ToString());
    }

}
