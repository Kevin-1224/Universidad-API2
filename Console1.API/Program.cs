using Universidad.Api.Comsumer;
using Universidad.Modelos;

namespace Console1.API
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Probar las operaciones con Eventos
            ProbarEvento();
            ProbarSesion();
            ProbarPonente();
            ProbarParticipante();
            ProbarInscripcion();
            ProbarPago();
            ProbarCertificado();

            Console.ReadLine();
        }

        private static void ProbarEvento()
        {
            Crud<Evento>.EndPoint = "https://localhost:7196/api/Eventoes"; // URL base + entidad "Eventos"
            var evento = new Evento
            {
                Id = 0,
                Nombre = "Conferencia sobre IA",
                Fecha = DateTime.Now+" ",
                Lugar = "Auditorio A",
                Tipo = "Conferencia"
            };

            // Crear un evento
            var eventoCreado = Crud<Evento>.Create(evento);

            // Obtener todos los eventos
            var eventos = Crud<Evento>.GetAll();

            // Mostrar eventos
            foreach (var e in eventos)
            {
                Console.WriteLine($"ID: {e.Id}, Nombre: {e.Nombre}, Fecha: {e.Fecha}");
            }
        }

        private static void ProbarSesion()
        {
            Crud<Sesion>.EndPoint = "https://localhost:7196/api/Sesiones"; // URL base + entidad "Sesiones"
            var sesion = new Sesion
            {
                Id = 0,
                Nombre = "Introducción a la IA",
                Horario = "10:00 AM",
                Sala = "Sala 101",
                IdEvento = 1 // Suponiendo que el evento tiene ID 1
            };

            // Crear una sesión
            var sesionCreada = Crud<Sesion>.Create(sesion);

            // Obtener todas las sesiones
            var sesiones = Crud<Sesion>.GetAll();

            // Mostrar sesiones
            foreach (var s in sesiones)
            {
                Console.WriteLine($"ID: {s.Id}, Nombre: {s.Nombre}, Horario: {s.Horario}, Sala: {s.Sala}");
            }
        }

        private static void ProbarPonente()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7196/api/Ponentes"; // URL base + entidad "Ponentes"
            var ponente = new Ponente
            {
                Id = 0,
                Nombre = "Carlos López",
                Apellido = "Gómez",
                añoDenacimiento = 1980
            };

            // Crear un ponente
            var ponenteCreado = Crud<Ponente>.Create(ponente);

            // Obtener todos los ponentes
            var ponentes = Crud<Ponente>.GetAll();

            // Mostrar ponentes
            foreach (var p in ponentes)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre} {p.Apellido}");
            }
        }

        private static void ProbarParticipante()
        {
            Crud<Participante>.EndPoint = "https://localhost:7196/api/Participantes"; // URL base + entidad "Participantes"
            var participante = new Participante
            {
                Id = 0,
                Nombre = "Ana María",
                Apellido = "Rodríguez",
                Telefono = 123456789,
                Correo = "ana@gmail.com"
            };

            // Crear un participante
            var participanteCreado = Crud<Participante>.Create(participante);

            // Obtener todos los participantes
            var participantes = Crud<Participante>.GetAll();

            // Mostrar participantes
            foreach (var p in participantes)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre} {p.Apellido}");
            }
        }

        private static void ProbarInscripcion()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7196/api/Inscripcions"; // URL base + entidad "Inscripciones"
            var inscripcion = new Inscripcion
            {
                Id = 0,
                IdEvento = 1, // Suponiendo que el evento tiene ID 1
                IdParticipante = 1, // Suponiendo que el participante tiene ID 1
                FechaInscripcion = DateTime.Now+" ",
                Estado = "Confirmada"
            };

            // Crear una inscripción
            var inscripcionCreada = Crud<Inscripcion>.Create(inscripcion);

            // Obtener todas las inscripciones
            var inscripciones = Crud<Inscripcion>.GetAll();

            // Mostrar inscripciones
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"ID: {i.Id}, Evento ID: {i.IdEvento}, Participante ID: {i.IdParticipante}, Estado: {i.Estado}");
            }
        }

        private static void ProbarPago()
        {
            Crud<Pago>.EndPoint = "https://localhost:7196/api/Pagoes"; // URL base + entidad "Pagos"
            var pago = new Pago
            {
                Id = 0,
                InscripcionId = 1, // Suponiendo que la inscripción tiene ID 1
                Monto = 100,
                FechaPago = DateTime.Now+" ",
                MetodoPago = "Tarjeta de Crédito"
            };

            // Crear un pago
            var pagoCreado = Crud<Pago>.Create(pago);

            // Obtener todos los pagos
            var pagos = Crud<Pago>.GetAll();

            // Mostrar pagos
            foreach (var p in pagos)
            {
                Console.WriteLine($"Pago ID: {p.Id}, Inscripción ID: {p.InscripcionId}, Monto: {p.Monto}, Fecha: {p.FechaPago}, Método: {p.MetodoPago}");
            }
        }

        private static void ProbarCertificado()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7196/api/Certificadoes"; // URL base + entidad "Certificados"
            var certificado = new Certificado
            {
                Id = 0,
                IdInscripcion = 1, // Suponiendo que la inscripción tiene ID 1
                FechaEmision = DateTime.Now+" ",
                Estado = "Emitido"
            };

            // Crear un certificado
            var certificadoCreado = Crud<Certificado>.Create(certificado);

            // Obtener todos los certificados
            var certificados = Crud<Certificado>.GetAll();

            // Mostrar certificados
            foreach (var c in certificados)
            {
                Console.WriteLine($"Certificado ID: {c.Id}, Inscripción ID: {c.IdInscripcion}, Estado: {c.Estado}");
            }
        }
    }
}
