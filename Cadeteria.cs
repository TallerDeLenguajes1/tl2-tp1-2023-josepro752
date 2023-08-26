namespace EspacioCadeteria;

public enum Estado {
    EnCamino,
    Cancelado,
    Entregado
}

public class Cadeteria {
    private string? nombre;
    private int telefono;
    private List<Cadete> cadetes;
    // PROPIEDADES
    public string? Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

    // CONSTRUCTORES
    public Cadeteria(string nombre, int telefono, List<Cadete> cadetes) {
        Nombre = nombre;
        Telefono = telefono;
        Cadetes = cadetes;
    }

    // METODOS
    public void TomarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {
        var aleatorio = new Random();
        Cadetes[aleatorio.Next(0,Cadetes.Count())].AgregarPedido(nombre,direccion,telefono,datos,observacion);
    }
    public void CancelarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

    }
    public void MoverPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

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

    public void AgregarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

    }
    public void CancelarPedido(Estado estado /*datosdel pedido*/) {
        // buscar pedido y modificar
        // List<Pedido>[xx].CambiarEstadoPedido(estado)
    }
    public void EntregarPedido(Estado estado /*datosdel pedido*/) {
        // buscar pedido y modificar
        // List<Pedido>[xx].CambiarEstadoPedido(estado)
    }
    public void LlevandoPedido(Estado estado /*datosdel pedido*/) {
        // buscar pedido y modificar
        // List<Pedido>[xx].CambiarEstadoPedido(estado)
    }
    public void QuitarPedido() {

    }
    public void JornalACobrar() {

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

    public void CambiarEstadoPedido(Estado estado) {

    }
}

public class Cliente {
    private string nombre;
    private string direccion;
    private int telefono;
    private string DatosRefDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string DatosRefDireccion1 { get => DatosRefDireccion; set => DatosRefDireccion = value; }
}