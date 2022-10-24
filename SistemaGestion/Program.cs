﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using SistemaGestion.ADO;
using SistemaGestion.Models;
using System.Data;
using System.Data.SqlClient;


//ADO_Usuario _Usuario = new ADO_Usuario();
//_Usuario.TraerUsuario("tcasazza");

class Program
{

    static void Main(string[] args)
    {

        //  a.  Traer usuario
        string nombreUsuario = "tcasazza";
        Usuario infoUsuario = ADO_Usuario.TraerUsuario(nombreUsuario);


        //  b.  Traer producto
        int idUsuarioProducto = 1;
        var listaProductos = new List<Producto>();
        listaProductos = ADO_Producto.TraerProducto(idUsuarioProducto);


        //  c.  Traer productos vendidos
        var listaProductosVendidos = new List<Producto>();
        listaProductosVendidos = ADO_ProductoVendido.TraerProductoVendido(idUsuarioProducto);


        //  d.  Traer ventas
        int idUsuarioPV = 1;
        var listaVentas = new List<Venta>();
        listaVentas = ADO_Venta.TraerVentas(idUsuarioPV);


        //  d.  inicio de sesion
        string contraseña = "SoyTobiasCasazza";
        Usuario Login = ADO_Usuario.IniciarSesion(nombreUsuario, contraseña);


    }

}


