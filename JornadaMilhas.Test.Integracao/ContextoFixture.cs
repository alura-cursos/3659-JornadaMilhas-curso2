using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace JornadaMilhas.Test.Integracao;
public class ContextoFixture: IAsyncLifetime
{
    public JornadaMilhasContext Context { get; private set; }
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Build();

    public async Task InitializeAsync()
    {
        await _msSqlContainer.StartAsync();
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer(_msSqlContainer.GetConnectionString())
            .Options;

        Context = new JornadaMilhasContext(options);
    }

    public async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync();
    }
}
