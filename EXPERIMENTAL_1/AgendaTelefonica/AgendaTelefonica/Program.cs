Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("  ESTRUCTURA DE DATOS - AGENDA TELEFÓNICA - EXPERIMENTAL 1");
Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

// Crear una agenda con capacidad para 20 contactos
AgendaTelefonica agenda = new AgendaTelefonica(20);

// Agregar contactos de familia
agenda.AgregarContacto(new ContactoFamilia("Mamá", "María González", "0998765432", "maria.gonzalez@email.com", true));
agenda.AgregarContacto(new ContactoFamilia("Hermano", "Carlos López", "0987654321", "carlos.lopez@email.com", true));
agenda.AgregarContacto(new ContactoFamilia("Prima", "Ana Pérez", "0976543210", "ana.perez@email.com", false));

// Agregar contactos de trabajo
agenda.AgregarContacto(new ContactoTrabajo("Juan Martínez", "0965432109", "juan.martinez@empresa.com", false, "TechCorp S.A."));
agenda.AgregarContacto(new ContactoTrabajo("Laura Sánchez", "0954321098", "laura.sanchez@empresa.com", true, "Innovatech"));
agenda.AgregarContacto(new ContactoTrabajo("Pedro Torres", "0943210987", "pedro.torres@empresa.com", false, "Solutions Inc."));

Console.WriteLine("\n");

// Ordenar los contactos por nombre
agenda.OrdenarPorNombre();

// Mostrar todos los contactos
agenda.MostrarContactos();

// Mostrar solo los favoritos
agenda.MostrarFavoritos();

// Buscar un contacto por nombre
Console.WriteLine("\n");
agenda.BuscarPorNombre("María");

Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
Console.ReadKey();
