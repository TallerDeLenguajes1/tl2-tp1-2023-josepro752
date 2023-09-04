namespace EspacioCadeteria;
using System.Linq;
public enum Estado {
    SinEntregar,
    Cancelado,
    Entregado
}

public class Cadeteria {
    private string nombre;
    private int telefono;
    private List<Cadete> cadetes;
    private int numPed;
    // PROPIEDADES
    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public int NumPed { get => numPed; set => numPed = value; }

    // CONSTRUCTORES
    public Cadeteria(string nombre, int telefono) {
        Nombre = nombre;
        Telefono = telefono;
        Cadetes = new List<Cadete>();
        NumPed = 1;
    }

    // METODOS
    public Pedido TomarPedido(string nombre, string direccion, int telefono, string datosRef,  string observacion) {
        var cliente = new Cliente(nombre, direccion, telefono,datosRef);
        var pedido = new Pedido(NumPed,observacion,cliente);
        NumPed++;
        return pedido;
    }
    public void AsignarPedido(int id, Pedido ped){
        var cad = Cadetes.FirstOrDefault(c=>c.Id == id);
        cad.Pedidos.Add(ped);
    }
    public void MoverPedido(int numeroPed, int id) {
        Pedido pedido = null;
        foreach (var cad in Cadetes)
        {
            if(cad.Id != id){
                pedido = cad.QuitarPedido(numeroPed);
            }
        }
        if(pedido != null){
            foreach (var cad in Cadetes)
            {
                if(cad.Id == id){
                    cad.Pedidos.Add(pedido);
                }
            }
        }
    }
    public float PedPromedioCad(){
        int pedidos = 0;
        foreach (var c in Cadetes)
        {
            pedidos += c.CantidadPedidos(0); 
        }
        return pedidos/Cadetes.Count();
    }
    public float TotalaPagar(){
        float monto=0;
        foreach (var cad in Cadetes){
            monto = monto + cad.JornalACobrar();
        }
        return monto;
    }
}
public class Cadete {
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> pedidos;


    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Pedidos = new List<Pedido>();
    }
    public void TomarPedido(Pedido p) {
        Pedidos.Add(p);
    }
    public Pedido QuitarPedido(int numPed) {
        foreach (var p in Pedidos){
            if(p.Numero == numPed){
                Pedidos.Remove(p);
                return p;
            }
        }
        return null;
    }
    public float JornalACobrar() {
        return PedidosEntregados()*500;
    }
    private int PedidosEntregados(){
        return Pedidos.Count(p => p.Estado == Estado.Entregado);//uso del LINQ
    }
    public int CantidadPedidos(int op){
        int cant=0;
        switch (op){
            case 1:
                cant = Pedidos.Count(p=> p.Estado == Estado.Entregado);
                break;
            case 2:
                cant = Pedidos.Count(p=> p.Estado == Estado.SinEntregar);
                break;
            case 3:
                cant = Pedidos.Count(p=> p.Estado == Estado.Cancelado);
                break;
        }
        return cant;
    }
}

public class Pedido {
    private int numero;
    private string observacion;
    private Estado estado;
    private Cliente client;


    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Client { get => client; set => client = value; }

    public Pedido(int numero, string observacion, Cliente cliente){
        Numero = numero;
        Observacion = observacion;
        Estado = Estado.SinEntregar;
        Client = cliente;
    }

    public void EntregarPedido() {
        Estado = Estado.Entregado;
    }
    public void CancelarPedido() {
        Estado = Estado.Cancelado;
    }
}

public class Cliente {
    private string nombre;
    private string direccion;
    private int telefono;
    private string datosRefDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string DatosRefDireccion { get => datosRefDireccion; set => datosRefDireccion = value; }
    
    public Cliente (string nombre, string direccion, int telefono, string datosRefDireccion) {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosRefDireccion = datosRefDireccion;
    }
}