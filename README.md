● ¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
    La única relación por composición es la del pedido-cliente, porque el enunciado establece que si se borra el pedido, se borre también el cliente. Todas las demás son por agregación: cadetería-cadete, cadete-pedido.

● ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
    La clase Cadeteria deberia tener:
        - AsignarPedido
        - ListarCadetes
        - MoverPedido
        - CancelarPedido
    La clase Cadete debería tener:
        - TomarPedido
        - EntregarPedido
        - CancelarPedido
        - QuitarPedido
        - JornalACobrar 
● Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados.
    No dejaría campos públicos para que no se corrompa el sistema y alteren información sin autorización.

● ¿Cómo diseñaría los constructores de cada una de las clases?
    Los preestablecería para que no reciban valoren nullos.

● ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
    Si, dentro de Cadeteria tendria una lista de cadetes y una lista de pedidos, y para relacionarlos a estos, dentro de pedido pondria un campo para identificar el cadete asignado y en cadete lo mismo.
