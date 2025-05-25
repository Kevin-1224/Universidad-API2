using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Universidad.Modelos;

    public class DbUniversidadAPIContext : DbContext
    {
        public DbUniversidadAPIContext (DbContextOptions<DbUniversidadAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Universidad.Modelos.Certificado> Certificado { get; set; } = default!;

public DbSet<Universidad.Modelos.Evento> Evento { get; set; } = default!;

public DbSet<Universidad.Modelos.Inscripcion> Inscripcion { get; set; } = default!;

public DbSet<Universidad.Modelos.Pago> Pago { get; set; } = default!;

public DbSet<Universidad.Modelos.Participante> Participante { get; set; } = default!;

public DbSet<Universidad.Modelos.Ponente> Ponente { get; set; } = default!;

public DbSet<Universidad.Modelos.Sesion> Sesion { get; set; } = default!;
    }
