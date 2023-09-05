using EspacioCadeteria;
using EspacioArchivos;
using Interfaz;


Cadeteria Cadet = Archivos.LeerCadeteria("Cadeteria");
Archivos.LeerCadetes("Cadetes", Cadet.Cadetes);

InterfazVisual.menu(Cadet);

Archivos.GuardarResumen(Cadet);
Archivos.EscribirResumen();