using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JornadaMilhas.Dados;
public class JornadaMilhasContext: DbContext
{
    public DbSet<OfertaViagem> OfertasViagem { get; set; }
    public DbSet<Rota> Rotas { get; set; }

    public JornadaMilhasContext() { }

    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhasTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Rota
        modelBuilder.Entity<Rota>().HasKey(e => e.Id);
        modelBuilder.Entity<Rota>()
                        .Property(a => a.Origem);
        modelBuilder.Entity<Rota>()
                        .Property(a => a.Destino);
        modelBuilder.Entity<Rota>().Ignore(a => a.Erros);
        modelBuilder.Entity<Rota>().Ignore(a => a.EhValido);

        //OfertaViagem
        modelBuilder.Entity<OfertaViagem>().HasKey(e => e.Id);
        modelBuilder.Entity<OfertaViagem>()
                        .OwnsOne(o => o.Periodo, periodo =>
                        {
                            periodo.Property(e => e.DataInicial).HasColumnName("DataInicial");
                            periodo.Property(e => e.DataFinal).HasColumnName("DataFinal");
                            periodo.Ignore(e => e.Erros);
                            periodo.Ignore(e => e.EhValido);
                        });
        modelBuilder.Entity<OfertaViagem>()
            .Property(o => o.Preco);
        modelBuilder.Entity<OfertaViagem>().Ignore(a => a.Erros);
        modelBuilder.Entity<OfertaViagem>().Ignore(a => a.EhValido);

        base.OnModelCreating(modelBuilder);
    }


}
