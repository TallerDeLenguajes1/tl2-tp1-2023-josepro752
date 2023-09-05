using EspacioCadeteria;
using Microsoft.VisualBasic.FileIO;

namespace EspacioArchivos;
public static class Archivos{
    public static bool Existe(string nombre){
        return File.Exists(nombre+".csv")||File.Exists(nombre+".txt");
    }
    public static Cadeteria LeerCadeteria(string nombre){
        using(TextFieldParser ruta = new TextFieldParser(nombre+".csv")){
            ruta.TextFieldType = FieldType.Delimited;
            ruta.SetDelimiters(",",";");
            while(!ruta.EndOfData){
                string[] filas = ruta.ReadFields();
                if(filas.Count()==2){
                    var nom = filas[0];
                    int tel; 
                    int.TryParse(filas[1],out tel);
                    var Cdria = new Cadeteria(nom,tel);
                    return Cdria;
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
        }
        return null;
    }
    public static void LeerCadetes(string nombre, List<Cadete> Cadts){
        using(TextFieldParser ruta = new TextFieldParser(nombre+".csv")){
            ruta.TextFieldType = FieldType.Delimited;
            ruta.SetDelimiters(",",";");
            while(!ruta.EndOfData){
                string[] filas = ruta.ReadFields();
                if(filas.Count()==4){
                    int id, tel; 
                    var nom = filas[1];
                    var dire = filas[2];
                    int.TryParse(filas[0],out id);
                    int.TryParse(filas[3],out tel);
                    var cad = new Cadete(id,nom,dire,tel);
                    Cadts.Add(cad);
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
        }
    }
    public static void GuardarResumen(Cadeteria Cdtria){
        try{
            // Abre el archivo para escritura (si no existe, lo crea; si existe, sobrescribe el contenido)
            using (StreamWriter arch = new StreamWriter("Resumen.txt")){
                arch.WriteLine(Cdtria.Nombre +"RESUMEN");
                arch.WriteLine("Fecha: "+DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy"));
                arch.WriteLine("PE: pedidos entregados, PSE: pedidos sin entregar, PC: pedidos cancelados, PT: pedidos totales.");
    
                foreach (var c in Cdtria.Cadetes){
                    var id = c.Id;
                    var nombre = c.Nombre;
                    var pE = c.CantidadPedidos(1);
                    var pSE = c.CantidadPedidos(2);
                    var pC = c.CantidadPedidos(3);
                    var TP = c.CantidadPedidos(0);
                    var pago = c.JornalACobrar();
                    arch.WriteLine(id+"| "+nombre+", PE"+pE+" PSE:"+pSE+" PC:"+pC+" PT:"+TP+", JORNAL: "+pago);
                }
                var numeroPed = Cdtria.NumPed-1; 
                arch.WriteLine("Total de pedidos: "+numeroPed+"  Total a pagar: "+Cdtria.TotalaPagar());
            }

            // Console.WriteLine("Arreglo de cadenas escrito en el archivo correctamente.");
        }
        catch (IOException e){
            // Console.WriteLine($"Ocurrió un error al escribir en el archivo: {e.Message}");
        }
    }
    public static void EscribirResumen(){
        if(Existe("Resumen")){
            using(StreamReader read = new StreamReader("Resumen.txt")){
                while(!read.EndOfStream){
                    Console.WriteLine(read.ReadLine());
                }
            }

        }
    }
}