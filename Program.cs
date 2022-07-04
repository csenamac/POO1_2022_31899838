using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO1_2022_31899838
{
    class Program
    {
        public const string FECHAINICIAL = "01/01/0001";
        public const int VALORSORTEOINICIAL = -1;

        static void Main(string[] args)
        {
            try
            {
                int cantidadDias = CantidadSorteos();
                DateTime[] mtzFechasSorteos = InicializarFechaSorteos(cantidadDias);
                int[,] mtzNumerosSorteados = InicializarNumerosSorteados(cantidadDias, 20);
                ConsoleKey tecla = new ConsoleKey();

                bool salir = false;

                while (!salir)
                {
                    try
                    {
                        Console.Clear();
                        EscribirMenu();
                        Console.Write("Elige una de las opciones listadas encima: ");
                        int opcion = Convert.ToInt32(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("*** Agregar un sorteo ***");
                                while (true)
                                {
                                    try
                                    {
                                        Console.Write("Ingrese el dia del sorteo: ");
                                        int dia = Convert.ToInt32(Console.ReadLine());
                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            AgregarSorteo(dia, mtzFechasSorteos, mtzNumerosSorteados);
                                            Console.Write("¿Desea seguir ingresando el resto de los sorteos del mes de {0} de {1}? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ", Mes(DateTime.Now.Month), DateTime.Now.Year);
                                            tecla = Console.ReadKey().Key;
                                            if (tecla == ConsoleKey.Enter)
                                            {
                                                for (int i = 0; i < cantidadDias; i++)
                                                {
                                                    AgregarSorteo((i + 1), mtzFechasSorteos, mtzNumerosSorteados);
                                                    Console.Write("¿Desea seguir ingresando el resto de los sorteos del mes de {0} de {1}? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ", Mes(DateTime.Now.Month), DateTime.Now.Year);
                                                    tecla = Console.ReadKey().Key;
                                                    if (tecla != ConsoleKey.Enter)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nEl mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                        }
                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            break;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nSolo son aceptados números, El mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                    }
                                }

                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("*** Modificar un numero dentro de un sorteo ***");
                                while (true)
                                {
                                    try
                                    {
                                        Console.Write("Ingrese el dia del sorteo: ");
                                        int dia = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Ingrese el lugar que ocupa el número en los 20 sorteados: ");
                                        int posicion = Convert.ToInt32(Console.ReadLine());

                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            ModificarNumeroSorteado(dia, posicion, mtzFechasSorteos, mtzNumerosSorteados);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nEl mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                        }

                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            break;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nSolo son aceptados números, El mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                    }
                                }

                                Console.WriteLine("\n\nPresione ENTER para continuar");
                                Console.ReadLine();

                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("*** Mostrar sorteo de una fecha ***");
                                while (true)
                                {
                                    Console.Write("Ingrese el dia del sorteo que desea ver: ");
                                    try
                                    {
                                        int dia = Convert.ToInt32(Console.ReadLine());
                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            MostrarUnSorteo(dia, mtzFechasSorteos, mtzNumerosSorteados);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nEl mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                        }
                                        if (RangoCorrecto(dia, 0, cantidadDias))
                                        {
                                            break;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nSolo son aceptados números, El mes de {0} tiene {1} dias, ingrese un dia en ese rango.\n", Mes(DateTime.Now.Month), cantidadDias);
                                    }
                                }

                                Console.WriteLine("\n\nPresione ENTER para continuar");
                                Console.ReadLine();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("*** Mostrar todos los sorteos del mes ***");

                                MostrarTodosLosSorteos(mtzFechasSorteos, mtzNumerosSorteados);

                                Console.WriteLine("\n\nPresione ENTER para continuar");
                                Console.ReadLine();

                                break;

                            case 5:
                                Console.WriteLine("Presione ENTER para salir de la aplicacion o cualquier otra tecla para continuar");
                                tecla = Console.ReadKey().Key;

                                if (tecla == ConsoleKey.Enter)
                                {
                                    salir = true;
                                }

                                break;

                            default:
                                Console.WriteLine("Elige una opcion entre 1 y 5");
                                Console.WriteLine("\n\nPresione ENTER para continuar");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Solo son aceptados números");
                        Console.WriteLine("\n\nPresione ENTER para continuar");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        private static DateTime[] InicializarFechaSorteos(int cantidadSorteos)
        {
            DateTime[] fSorteos = new DateTime[cantidadSorteos];

            for (int i = 0; i < fSorteos.Length; i++)
            {
                fSorteos[i] = Convert.ToDateTime(FECHAINICIAL);
            }

            return fSorteos;
        }
        private static int[,] InicializarNumerosSorteados(int cantidadSorteos, int cantidadmtzNumerosSorteados)
        {
            int[,] nSorteados = new int[cantidadSorteos, cantidadmtzNumerosSorteados];

            for (int f = 0; f < nSorteados.GetLength(0); f++)
            {
                for (int c = 0; c < nSorteados.GetLength(1); c++)
                {
                    nSorteados[f, c] = VALORSORTEOINICIAL;
                }
            }

            return nSorteados;
        }
        private static void EscribirMenu()
        {
            Console.WriteLine("*************** QUINELA **************");
            Console.WriteLine("**************************************");
            Console.WriteLine("");
            Console.WriteLine(" 1 - Agregar sorteos");
            Console.WriteLine(" 2 - Modificar número de un sorteo");
            Console.WriteLine(" 3 - Mostrar un sorteo");
            Console.WriteLine(" 4 - Mostrar todos los sorteos");
            Console.WriteLine(" 5 - Salir de la aplicación\n\n");
        }
        private static string Mes(int numeroMes)
        {
            switch (numeroMes)
            {
                case 1:
                    return "enero";
                case 2:
                    return "febrero";
                case 3:
                    return "marzo";
                case 4:
                    return "abril";
                case 5:
                    return "mayo";
                case 6:
                    return "junio";
                case 7:
                    return "julio";
                case 8:
                    return "agosto";
                case 9:
                    return "setiembre";
                case 10:
                    return "octubre";
                case 11:
                    return "noviembre";
                case 12:
                    return "diciembre";
                default:
                    return "Número erroneo";
            }
        }
        private static int CantidadSorteos()
        {
            int res = 0;
            int mes = DateTime.Now.Month;
            bool bisiesto = DateTime.IsLeapYear(DateTime.Now.Year);

            if (bisiesto)
            {
                if (mes == 2)
                {
                    res = 29;
                }
            }
            else
            {
                if (mes == 2)
                {
                    res = 28;
                }
            }

            if (mes == 1 || mes == 4 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                res = 31;
            }
            else if (mes == 3 || mes == 6 || mes == 9 || mes == 11)
            {
                res = 30;
            }

            return res;
        }
        private static bool BuscarNumeroLineal(int numero, int[] matriz)
        {
            bool res = false;

            try
            {
                for (int i = 0; i < matriz.Length; i++)
                {
                    if (matriz[i] == numero)
                    {
                        res = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }
        private static bool RangoCorrecto(int numero, int numeroInf, int numeroSup)
        {
            return (numero >= numeroInf && numero <= numeroSup);
        }
        private static bool EsNumero(string numeroIngresado)
        {
            bool res = false;

            for (int i = 0; i < numeroIngresado.Length; i++)
            {
                res = char.IsNumber(numeroIngresado[i]);
            }

            return res;
        }
        private static bool AgregarSorteo(int dia, DateTime[] mtzFechasSorteos, int[,] mtzNumerosSorteados)
        {
            DateTime fechaInicial = Convert.ToDateTime(FECHAINICIAL);
            DateTime fecha = Convert.ToDateTime(dia + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            bool resultado = false;

            int indiceFecha = fecha.Day - 1;
            int[] aux = new int[mtzNumerosSorteados.GetLength(1)];

            for (int a = 0; a < aux.Length; a++)
            {
                aux[a] = -1;
            }

            int numero;

            try
            {
                if (mtzFechasSorteos[indiceFecha] == fechaInicial)
                {
                    mtzFechasSorteos[indiceFecha] = fecha;

                    Console.WriteLine("Ingresaremos los 20 números válidos del sorteo");
                    Console.WriteLine("(Números válidos: enteros, del 0 al 999)");

                    for (int i = 0; i < aux.Length; i++)
                    {
                        while (true)
                        {
                            Console.Write((i + 1) + ": ");
                            string num = Console.ReadLine().Trim();

                            if (EsNumero(num))
                            {
                                numero = Convert.ToInt32(num);
                            }
                            else
                            {
                                numero = -1;
                            }

                            if (RangoCorrecto(numero, 0, 999) && !BuscarNumeroLineal(numero, aux))
                            {
                                aux[i] = numero;
                                Console.WriteLine("OK");
                            }


                            if (aux[i] == -1)
                            {
                                if (numero == -1)
                                {
                                    Console.WriteLine("Letras y caracteres no permitidos. Ingrese un numero valido.");
                                }
                                else if (BuscarNumeroLineal(numero, aux))
                                {
                                    Console.WriteLine("Número repetido. Ingrese un numero valido.");
                                }
                                else if (!RangoCorrecto(numero, 0, 999))
                                {
                                    Console.WriteLine("Número fuera de rango, debe estar entre 0 y 999. Ingrese un numero valido.");
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    for (int f = indiceFecha; f == indiceFecha; f++)
                    {
                        for (int c = 0; c < mtzNumerosSorteados.GetLength(1); c++)
                        {
                            mtzNumerosSorteados[f, c] = aux[c];
                            resultado = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ya hay un sorteo agregado con la fecha {0}", fecha.ToString("d"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;

        }
        private static bool ModificarNumeroSorteado(int dia, int posicionNumero, DateTime[] mtzFechasSorteos, int[,] mtzNumerosSorteados)
        {
            DateTime fechaInicial = Convert.ToDateTime(FECHAINICIAL);
            DateTime fecha = Convert.ToDateTime(dia + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

            bool resultado = false;

            int indiceFecha = fecha.Day - 1;
            int[] aux = new int[mtzNumerosSorteados.GetLength(1)];
            int nuevoNumero;

            try
            {
                if (mtzFechasSorteos[indiceFecha] == fecha)
                {
                    for (int f = indiceFecha; f == indiceFecha; f++)
                    {
                        for (int c = 0; c < mtzNumerosSorteados.GetLength(1); c++)
                        {
                            aux[c] = mtzNumerosSorteados[f, c];
                        }
                    }
                }

                while (true)
                {

                    Console.Write("Ingrese el número para modificar la posicion {0}: ", posicionNumero);
                    string num = Console.ReadLine().Trim();

                    if (EsNumero(num))
                    {
                        nuevoNumero = Convert.ToInt32(num);
                    }
                    else
                    {
                        nuevoNumero = -1;
                    }

                    if (RangoCorrecto(nuevoNumero, 0, 999) && !BuscarNumeroLineal(nuevoNumero, aux))
                    {
                        aux[posicionNumero - 1] = nuevoNumero;
                        Console.WriteLine("Modificado");
                    }

                    if (aux[posicionNumero - 1] != nuevoNumero)
                    {
                        if (nuevoNumero == -1)
                        {
                            Console.WriteLine("Letras y caracteres no permitidos. Ingrese un numero valido.");
                        }
                        else if (BuscarNumeroLineal(nuevoNumero, aux))
                        {
                            Console.WriteLine("Número repetido. Ingrese un numero valido.");
                        }
                        else if (!RangoCorrecto(nuevoNumero, 0, 999))
                        {
                            Console.WriteLine("Número fuera de rango, debe estar entre 0 y 999. Ingrese un numero valido.");
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                for (int f = indiceFecha; f == indiceFecha; f++)
                {
                    for (int c = 0; c < mtzNumerosSorteados.GetLength(1); c++)
                    {
                        mtzNumerosSorteados[f, c] = aux[c];
                        resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }
        private static void MostrarUnSorteo(int dia, DateTime[] mtzFechasSorteos, int[,] mtzNumerosSorteados)
        {
            try
            {
                DateTime fechaInicial = Convert.ToDateTime(FECHAINICIAL);
                DateTime fecha = Convert.ToDateTime(dia + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

                int indiceFecha = fecha.Day - 1;
                int[] aux = new int[mtzNumerosSorteados.GetLength(1)];

                for (int i = 0; i < aux.Length; i++)
                {
                    aux[i] = -1;
                }


                if (mtzFechasSorteos[indiceFecha] == fecha)
                {
                    for (int f = indiceFecha; f == indiceFecha; f++)
                    {
                        for (int c = 0; c < mtzNumerosSorteados.GetLength(1); c++)
                        {
                            aux[c] = mtzNumerosSorteados[f, c];
                        }
                    }
                    for (int a = 0; a < aux.Length / 4; a++)//A MANO, NO ES REUTILIZABLE... PERO FUNCIONA
                    {
                        Console.WriteLine("Posición" + (a + 1) + ": " + aux[a] + "\t" +
                                          "Posición" + (a + 6) + ": " + aux[a + 5] + "\t" +
                                          "Posición" + (a + 11) + ": " + aux[a + 10] + "\t" +
                                          "Posición" + (a + 16) + ": " + aux[a + 15] + "\t");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo hay sorteos registrados para la fecha {0}", fecha.ToString("d"));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static void MostrarTodosLosSorteos(DateTime[] mtzFechasSorteos, int[,] mtzNumerosSorteados)
        {
            DateTime fechaInicial = Convert.ToDateTime(FECHAINICIAL);
            DateTime fecha = new DateTime();
            int indiceFecha = fecha.Day - 1;
            try
            {
                for (int f = 0; f < mtzNumerosSorteados.GetLength(0); f++)
                {
                    if (mtzFechasSorteos[f] != fechaInicial)
                    {
                        Console.Write(mtzFechasSorteos[f].ToString("d") + " - ");
                    }
            
                    for (int c = 0; c < mtzNumerosSorteados.GetLength(1); c++)
                    {
                        if (mtzNumerosSorteados[f, c] != -1)
                        {
                            Console.Write(mtzNumerosSorteados[f, c] + " ");
                        }
                    }
                    if (mtzFechasSorteos[f] != fechaInicial)
                    {
                        Console.WriteLine("");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
