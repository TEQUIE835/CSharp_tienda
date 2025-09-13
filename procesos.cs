using System.Reflection.Metadata.Ecma335;

namespace tiendaDeAna;

public class procesos

{
    public static List<int> comprarProductos(List<string> productos, List<double> precios, List<int> stock)
    {
        List<int> ids = new List<int>();
        List<int> cantidadPedido = new List<int>();
        while (true)
        {
            Console.WriteLine("\nIngrese el producto deseado a comprar: (para dejar de registrar productos escribir 'salir')");
            string productoPedido = Console.ReadLine();
            if (productoPedido.ToLower() == "salir")
            { 
                break;
            }
        
            bool productoEncontrado = false;
            for (int i = 0; i < productos.Count; i++)
            {
                
                if (productos[i].ToLower() == productoPedido.ToLower())
                {
                    Console.WriteLine("Cuantos desea comprar: ");
                    while (true)
                    {
                        try
                        {
                            int cantidadPedida = int.Parse(Console.ReadLine());
                            if (cantidadPedida <= stock[i] && cantidadPedida > 0)
                            {
                                bool bandera = false;
                                for (int id = 0; id<ids.Count; id++)
                                {
                                    if (ids[id] == i)
                                    {
                                        cantidadPedido[id] += cantidadPedida;
                                        bandera = true;
                                    }
                                }

                                if (!bandera)
                                {
                                    ids.Add(i);
                                    cantidadPedido.Add(cantidadPedida);
                                }

                                productoEncontrado = true;
                                stock[i] -= cantidadPedida;
                                break;
                            } else if (cantidadPedida >= stock[i])
                            {
                             Console.WriteLine("No hay suficiente stock para eso");
                            }
                        }
                        catch 
                        {
                            Console.WriteLine("Ingrese una cantidad valida");
                        }
                    }
                
                }
            }

            if (!productoEncontrado)
            {
                Console.WriteLine("No se encontro el producto, verifica que si exista");
            }
        }

        

        if (ids.Count() != 0)
        {
            double totalPago = 0;
            for(int i = 0; i < ids.Count; i++)
            {
                totalPago += precios[ids[i]] * cantidadPedido[i];
            }
            double precioConDescuento = descuentoPrecio(totalPago);
            menus.crearTicket(totalPago, precioConDescuento, productos, precios, cantidadPedido, ids);
        }else if (ids.Count() == 0)
        {
            Console.WriteLine("No se ingreso ningun articulo\n");
        }
       
        return stock;
    }
    public static double descuentoPrecio(double totalPago)
    {
        double porcentaje = 0;
        if ( totalPago <20000 && totalPago>=10000)
        {
            porcentaje += 0.10;
        } else if (totalPago >= 20000)
        {
            porcentaje += 0.20;
        }

        double pagoConDescuento = totalPago * (1 - porcentaje);
        return pagoConDescuento;
    }
}