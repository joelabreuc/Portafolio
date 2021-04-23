using System;

namespace Proyecto__Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentacion();


            #region Declaracion variables
            int fila, columna, aux, vRandom;
            bool correr = true, Confirme = true;

            int[,] sudoku = new int[6, 6];


            #endregion

            //Genera numero aleatorio
            Random r = new Random();
            //Genera un numero entre 1 y 3 (4 no se incluye)
            vRandom = r.Next(1, 4);


            if (vRandom == 1)
            {
                var sudoku1 = new int[6, 6]
                {
                { 5, 0, 0, 0, 4, 0 },
                { 0, 0, 3, 5, 0, 0 },
                { 0, 4, 0, 0, 0, 5 },
                { 6, 0, 0, 4, 0, 0 },
                { 0, 0, 5, 3, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                };



                for (int i = 0; i < sudoku1.GetLength(0); i++)
                {
                    for (int j = 0; j < sudoku1.GetLength(1); j++)
                    {
                        sudoku[i, j] = sudoku1[i, j];
                    }
                }


            }
            else if (vRandom == 2)
            {
                var sudoku1 = new int[6, 6]
                {
                { 0, 3, 5, 1, 4, 2 },
                { 2, 1, 0, 5, 3, 0 },
                { 0, 0, 0, 3, 0, 0 },
                { 0, 5, 0, 2, 0, 4 },
                { 4, 2, 1, 0, 0, 3 },
                { 0, 0, 0, 0, 2, 1 },
                };

                for (int i = 0; i < sudoku1.GetLength(0); i++)
                {
                    for (int j = 0; j < sudoku1.GetLength(1); j++)
                    {
                        sudoku[i, j] = sudoku1[i, j];
                    }
                }
            }
            else if (vRandom == 3)
            {
                var sudoku1 = new int[6, 6]
                {
                { 0, 0, 5, 0, 6, 0 },
                { 6, 0, 0, 0, 0, 0 },
                { 4, 0, 0, 0, 3, 0 },
                { 0, 3, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0, 1 },
                { 0, 5, 0, 2, 0, 0 },
                };

                for (int i = 0; i < sudoku1.GetLength(0); i++)
                {
                    for (int j = 0; j < sudoku1.GetLength(1); j++)
                    {
                        sudoku[i, j] = sudoku1[i, j];
                    }
                }
            }






            int intentos = 0;

            while (correr)
            {
                Impresionsudoku(sudoku);

                Console.SetCursorPosition(63, 5);
                Imprimir("Escriba uno (1) para continuar");
                Console.SetCursorPosition(63, 6);
                Imprimir("Escriba cero (0) para salir del programa");
                Console.SetCursorPosition(63, 7);
                var vSalir = Convert.ToChar(Console.ReadLine());
                if (vSalir == '0')
                {
                    Environment.Exit(0);
                }



                #region Captura de numeros
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Cual fila quieres arreglar?");
                fila = int.Parse(Console.ReadLine());



                if (fila > 6)
                {
                    while (Confirme)
                    {
                        Console.Write("Por favor elija un numero menor o igual a 6: ");
                        fila = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (fila < 7)
                        {
                            Confirme = false;
                        }
                    }
                }
                Confirme = true;

                Console.WriteLine("Cual posicion? ");
                columna = int.Parse(Console.ReadLine());
                if (columna > 6)
                {
                    while (Confirme)
                    {
                        Console.Write("Por favor elija un numero menor o igual a 6: ");
                        columna = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (columna < 7)
                        {
                            Confirme = false;
                        }
                    }
                }
                Confirme = true;

                Console.WriteLine("Ingrese el numero que desea colocar");
                aux = int.Parse(Console.ReadLine());
                if (aux > 6)
                {
                    while (Confirme)
                    {
                        Console.Write("Por favor elija un numero menor o igual a 6: ");
                        aux = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (aux < 7)
                        {
                            Confirme = false;
                        }
                    }
                }
                Confirme = true;
                #endregion


                int[] arrayduplicado1 = new int[6];
                int[] arrayduplicado2 = new int[6];
                int[] arrayduplicado3 = new int[6];
                int[] arrayduplicado4 = new int[6];
                int[] arrayduplicado5 = new int[6];
                int[] arrayduplicado6 = new int[6];

                int[] arrayColumna1 = new int[6];
                int[] arrayColumna2 = new int[6];
                int[] arrayColumna3 = new int[6];
                int[] arrayColumna4 = new int[6];
                int[] arrayColumna5 = new int[6];
                int[] arrayColumna6 = new int[6];

                Trasladar(arrayduplicado1,
                arrayduplicado2, arrayduplicado3, arrayduplicado4, arrayduplicado5, arrayduplicado6,
                arrayColumna1, arrayColumna2, arrayColumna3, arrayColumna4, arrayColumna5, arrayColumna6, sudoku);


                sudoku[fila - 1, columna - 1] = Condiciones(fila, columna, aux, arrayduplicado1,
                arrayduplicado2, arrayduplicado3, arrayduplicado4, arrayduplicado5, arrayduplicado6,
                arrayColumna1, arrayColumna2, arrayColumna3, arrayColumna4, arrayColumna5, arrayColumna6);


                if (sudoku[fila - 1, columna - 1] != 0)
                {
                    Console.WriteLine(intentos);
                }
                else
                {
                    intentos++;
                    if (intentos == 2)
                    {
                        Console.WriteLine("Ten cuidado, llevas {0} fallos, perderas el grado de Exelencia", intentos);
                    }
                    else if (intentos == 5)
                    {
                        Console.WriteLine("Ten cuidado, llevas {0} fallos, perderas el grado de Muy bueno", intentos);
                    }
                    else if (intentos == 7)
                    {
                        Console.WriteLine("Ten cuidado, llevas {0} fallos, perderas el grado de Bueno", intentos);
                    }
                    else if (intentos == 8)
                    {
                        Console.WriteLine("Cuidado, llevas {0} fallos, solo te quedan dos intentos mas", intentos);

                    }
                    else if (intentos == 10)
                    {
                        Imprimir("AGOTASTE TODOS TUS INTENTOS, \n----CERRANDO JUEGO----");
                        System.Threading.Thread.Sleep(5000);
                        Environment.Exit(0);
                    }



                }

                
                Console.ReadKey();
                Console.Clear();

            }

        }
        static int Condiciones(int fila, int columna, int aux,
        int[] arrayduplicado1,
        int[] arrayduplicado2,
        int[] arrayduplicado3,
        int[] arrayduplicado4,
        int[] arrayduplicado5,
        int[] arrayduplicado6,
        int[] arrayColumna1,
        int[] arrayColumna2,
        int[] arrayColumna3,
        int[] arrayColumna4,
        int[] arrayColumna5,
        int[] arrayColumna6)
        {


            int arrayfix;
            int[] variables = { fila, columna, aux };
            #region Condiciones por filas y columnas
            switch (columna)
            {
                case 1:

                    for (var x = 0; x < arrayColumna1.Length; x++)
                    {
                        int a = arrayColumna1[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna1.Length; y++)
                        {
                            int b = arrayColumna1[y];

                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 2:
                    arrayfix = fila - 1;
                    arrayColumna2[arrayfix] = aux;

                    for (var x = 0; x < arrayColumna2.Length; x++)
                    {
                        int a = arrayColumna2[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna2.Length; y++)
                        {
                            int b = arrayColumna2[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 3:
                    arrayfix = fila - 1;
                    arrayColumna3[arrayfix] = aux;

                    for (var x = 0; x < arrayColumna3.Length; x++)
                    {
                        int a = arrayColumna3[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna3.Length; y++)
                        {
                            int b = arrayColumna3[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 4:
                    arrayfix = fila - 1;
                    arrayColumna4[arrayfix] = aux;

                    for (var x = 0; x < arrayColumna4.Length; x++)
                    {
                        int a = arrayColumna4[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna4.Length; y++)
                        {
                            int b = arrayColumna4[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 5:
                    arrayfix = fila - 1;
                    arrayColumna5[arrayfix] = aux;

                    for (var x = 0; x < arrayColumna5.Length; x++)
                    {
                        int a = arrayColumna5[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna5.Length; y++)
                        {
                            int b = arrayColumna5[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 6:
                    arrayfix = fila - 1;
                    arrayColumna6[arrayfix] = aux;

                    for (var x = 0; x < arrayColumna6.Length; x++)
                    {
                        int a = arrayColumna6[x];
                        int c = x + 1;
                        for (int y = c; y < arrayColumna6.Length; y++)
                        {
                            int b = arrayColumna6[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
            }
            switch (fila)
            {
                case 1:
                    arrayfix = columna - 1;
                    arrayduplicado1[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado1.Length; x++)
                    {
                        int a = arrayduplicado1[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado1.Length; y++)
                        {
                            int b = arrayduplicado1[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 2:
                    arrayfix = columna - 1;
                    arrayduplicado2[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado2.Length; x++)
                    {
                        int a = arrayduplicado2[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado2.Length; y++)
                        {
                            int b = arrayduplicado2[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 3:
                    arrayfix = columna - 1;
                    arrayduplicado3[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado3.Length; x++)
                    {
                        int a = arrayduplicado3[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado3.Length; y++)
                        {
                            int b = arrayduplicado3[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 4:
                    arrayfix = columna - 1;
                    arrayduplicado4[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado4.Length; x++)
                    {
                        int a = arrayduplicado4[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado4.Length; y++)
                        {
                            int b = arrayduplicado4[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 5:
                    arrayfix = columna - 1;
                    arrayduplicado5[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado5.Length; x++)
                    {
                        int a = arrayduplicado5[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado5.Length; y++)
                        {
                            int b = arrayduplicado5[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;
                case 6:
                    arrayfix = columna - 1;
                    arrayduplicado6[arrayfix] = aux;

                    for (var x = 0; x < arrayduplicado6.Length; x++)
                    {
                        int a = arrayduplicado6[x];
                        int c = x + 1;
                        for (int y = c; y < arrayduplicado6.Length; y++)
                        {
                            int b = arrayduplicado6[y];
                            Condicion_if(variables, aux, a, b);

                        }
                    }
                    break;

            }

            return variables[2];
            #endregion
        }

        static void Imprimir(String vWrite)
        {
            Console.WriteLine(vWrite);
        }

        static void Presentacion()
        {
            Console.SetWindowSize(120, 30);
            Console.SetCursorPosition(46, 10);
            Imprimir("SUDOKU GRUPO #4");
            Console.SetCursorPosition(33, 11);
            Imprimir("Presione cualquier tecla para continuar...");
            Console.SetCursorPosition(72, 25);
            Imprimir("Realizado por: ");
            Console.SetCursorPosition(72, 26);
            Imprimir("Juan Carlos Guzmán Id:1099991");
            Console.SetCursorPosition(72, 27);
            Imprimir("Joel Abreu Id:1100774");
            Console.SetCursorPosition(72, 28);
            Imprimir("Rafael Brea Id:1099315");


            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(30, 12);
            Imprimir("Generando Sudoku");
            Console.SetCursorPosition(30, 15);
            Imprimir("Espere 5 segundos...");

            System.Threading.Thread.Sleep(4000);
            Console.Clear();
            Console.Beep();
        }

        static void Impresionsudoku(int[,] sudoku)
        {
            //impresion de sudoku
            Console.Write("-----------------\n");
            for (int x = 0; x < sudoku.GetLength(0); x++)
            {

                for (int y = 0; y < sudoku.GetLength(1); y++)
                {
                    Console.Write(sudoku[x, y] + "| ");

                }
                if (x == 1 || x == 3)//if y else if para agregar formato
                {
                    Console.Write("\n");
                    Console.Write("-------|--------|");
                }
                else if (x == 5)
                {
                    Console.Write("\n");
                    Console.Write("----------------|");
                }
                Console.WriteLine();//Separa los niveles del sudoku
            }

        }

        /// <summary>
        /// Metodo para evitar la repeticion de valores en fila y columnas
        /// </summary>
        /// <param name="variables">Valor de retorno</param>
        /// <param name="aux">Valor iterable en posicion n  en fila y columna</param>
        /// <param name="a"> Verifica posicion x en fila y columna </param>
        /// <param name="b"> Verifica posicion y en fila y columna </param>

        static void Condicion_if(int[] variables, int aux, int a, int b)
        {
            if (a == b && a != 0 && b != 0)
            {
                Imprimir("Hay un numero repetido, el valor no sera guardado");
                aux = 0;
                variables[2] = aux;

            }
        }

        static void Trasladar(
        int[] arrayduplicado1,
        int[] arrayduplicado2,
        int[] arrayduplicado3,
        int[] arrayduplicado4,
        int[] arrayduplicado5,
        int[] arrayduplicado6,
        int[] arrayColumna1,
        int[] arrayColumna2,
        int[] arrayColumna3,
        int[] arrayColumna4,
        int[] arrayColumna5,
        int[] arrayColumna6,
        int[,] sudoku)
        {

            for (int i = 0; i < 6; i++)
            {
                int aux0 = sudoku[0, i];
                arrayduplicado1[i] = aux0;

                int aux1 = sudoku[1, i];
                arrayduplicado2[i] = aux1;

                int aux2 = sudoku[2, i];
                arrayduplicado3[i] = aux2;

                int aux3 = sudoku[3, i];
                arrayduplicado4[i] = aux3;

                int aux4 = sudoku[4, i];
                arrayduplicado5[i] = aux4;

                int aux5 = sudoku[5, i];
                arrayduplicado6[i] = aux5;

                int auxC0 = sudoku[i, 0];
                arrayColumna1[i] = auxC0;

                int auxC1 = sudoku[i, 1];
                arrayColumna2[i] = auxC1;

                int auxC2 = sudoku[i, 2];
                arrayColumna3[i] = auxC2;

                int auxC3 = sudoku[i, 3];
                arrayColumna4[i] = auxC3;

                int auxC4 = sudoku[i, 4];
                arrayColumna5[i] = auxC4;

                int auxC5 = sudoku[i, 5];
                arrayColumna6[i] = auxC5;

            }

        }
    }
}
