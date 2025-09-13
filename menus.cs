using System.Text;

namespace tiendaDeAna;

public class menus
{
    
    public static void menuTienda()
    {
        List<string> productos = new List<string>{"alfajores", "galletas", "revolcones", "barrilete"};
        List<double> precios = new List<double>{2500, 400, 300, 400};
        List<int> stock = new List<int>{10, 10, 10, 10};
        while (true)
        {
            Console.WriteLine("Bienvenido a la tienda, contamos con los siguientes productos: ");
            for (int i = 0;  i < productos.Count; i++)
            {
                Console.WriteLine($@"
Producto: {productos[i]} 
precio:{precios[i]} 
stock: {stock[i]}");  
            }

            stock = procesos.comprarProductos(productos, precios, stock);
            bool seguir = seguirComprando();
            if (!seguir)
            {
                break;
            }
        }
        
    }

    public static bool seguirComprando()
    {
        Console.WriteLine("Quieres seguir comprando?");
        bool seguir;
        while (true)
        {

            string continuar = Console.ReadLine();
            if (continuar.ToLower()== "si"|| continuar.ToLower()== "s" || continuar.ToLower()== "true")
            {
                seguir = true; 
                break;
            }else if (continuar.ToLower() == "no" || continuar.ToLower() == "n" || continuar.ToLower() == "false")
            {
                seguir = false;
                break;
            }
            else
            {
                Console.WriteLine("Porfavor ingrese una opcion valida (si/no)");
            }
            
        }

        return seguir;
    }

    public static void crearTicket(double totalPago, double pagoConDescuento, List<string> productos, List<double> precios, List<int> cantidadPedido, List<int> ids)
    {
        Console.WriteLine($@"
Facturacion de la compra
Se compraron los siguientes productos:
");
        for (int i = 0; i < ids.Count; i++)
        {
            Console.WriteLine($@"Producto: {productos[ids[i]]}
Precio unitario: {precios[ids[i]]}
Unidades pedidas: {cantidadPedido[i]}
");
        }
        Console.WriteLine($@"Precio a pagar sin descuento: {totalPago}
Precio con descuento (si aplica): {pagoConDescuento}");
    }
}