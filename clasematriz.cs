using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_De_Examen
{
    class clasematriz
    {
        private int maxfil = 50;
        private int maxcol = 50;
        private int[,] matriz;
        private int fila, colum;

        public clasematriz()
        {
            matriz = new int[maxfil, maxcol];
            fila = 0; colum = 0;
        }

        public void cargar(int nfil, int ncol, int min, int max)
        {
            Random r = new Random();
            this.fila = nfil; this.colum = ncol;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    matriz[fil, col] = r.Next(min, max + 1);
                }
            }
        }
        public string descargar()
        {
            string sp = "";
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col =1; col <= this.colum; col++)
                {
                    sp = sp + matriz[fil, col] + "\t";
                }
                sp = sp + "\x000d" + "\x000a";
            }
            return sp;
        }

        // Examenes de parciales

        // funcion auxiliar para el orden senozoidal
       public void intercambio(int fil1, int col1, int fil2, int col2)
        {
            int auxi = matriz[fil1, col1];
            matriz[fil1, col1] = matriz[fil2, col2];
            matriz[fil2, col2] = auxi;
        }
        // funcion auxiliar para la pregunta 1
        public void ordensenozoidal()
        {
            int idx;
            for(int fil1 = this.fila; fil1 >= 1; fil1--)
            {
                for(int col1 = this.colum; col1 >= 1; col1--)
                {
                    for(int fil2 = fil1; fil2 >= 1; fil2--)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = this.colum;
                        for(int col2 = idx; col2 >=1; col2--)
                        {
                            if(matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.intercambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // Pregunta 1:
        public void pregunta1()
        {
            this.ordensenozoidal();
            bool change = true;
            for(int fil1 = this.fila; fil1 >= 1; fil1--)
            {
                if (change == true)
                {
                    for(int col1 = this.colum; col1 >= 1; col1--)
                    {
                        for(int col2 = col1; col2 >= 1; col2--)
                        {
                            if(matriz[fil1, col2] < matriz[fil1, col1])
                            {
                                this.intercambio(fil1, col2, fil1, col1);
                            }
                        }
                    }
                }
                else
                {
                    for (int col1 = this.colum; col1 >= 1; col1--)
                    {
                        for (int col2 = col1; col2 >= 1; col2--)
                        {
                            if (matriz[fil1, col2] > matriz[fil1, col1])
                            {
                                this.intercambio(fil1, col2, fil1, col1);
                            }
                        }
                    }
                }
                change = !change;
            }
        }

        // Pregunta 2
        public void pregunta2()
        {
            numEntero number1 = new numEntero();
            numEntero number2 = new numEntero();

            int idx, lin, num;
            for(int col1 = 1; col1 < this.colum; col1++)
            {
                for(int fil1 = this.fila - col1; fil1 >= 1; fil1--)
                {
                    for(int col2 = col1; col2 < this.colum; col2++)
                    {
                        if (col2 == col1)
                            idx = fil1;
                        else
                            idx = this.fila - col2;
                        for(int fil2 = idx; fil2 >=1; fil2--)
                        {
                            number1.cargar(matriz[fil2, col2]);
                            number2.cargar(matriz[fil1, col1]);
                            if( number1.espar() && !number2.espar() ||
                                number1.espar() && number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                !number1.espar() && !number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]))
                            {
                                this.intercambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // Pregunta 3
        public void pregunta3()
        {
            int idx, lin = this.colum, num;
            for(int fil1 = 2; fil1 <= this.fila; fil1++)
            {
                for(int col1 = lin; col1 <= this.colum; col1++)
                {
                    num = lin;
                    for(int fil2 = fil1; fil2 <= this.fila; fil2++)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = num;
                        for(int col2 = idx; col2 <= this.colum; col2++)
                        {
                            if(matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.intercambio(fil2, col2, fil1, col1);
                            }
                        }
                        num--;
                    }
                }
                lin--;
            }
        }

        // pregunta 4
        // funcion 1
        public int numelem(int numfil)
        {
            int frecu = 1, num;
            for(int col1 = 1; col1 < this.colum; col1++)
            {
                num = 0;
                for(int col2 = col1 + 1; col2 <= this.colum; col2++)
                {
                    if(matriz[numfil, col2] == matriz[numfil , col1])
                    {
                        num++;
                    }
                }
                if(num == 0)
                {
                    frecu++;
                }
            }
            return frecu;
        }
        // funcion 2
        public void cambiofilas(int fil1, int fil2)
        {
            for (int col1 = 1; col1 <= this.colum; col1++)
            {
                this.intercambio(fil1, col1, fil2, col1);
            }
        }

        // funcion 3
        public void pregunta4()
        {
            for(int filpos = 1; filpos < this.fila; filpos++)
            {
                for(int fildesp = filpos + 1; fildesp <= this.fila; fildesp++)
                {
                    if(numelem(fildesp) < numelem(filpos))
                    {
                        this.cambiofilas(fildesp, filpos);
                    }
                }
            }
        }

        // pregunta 5
        // funcion 1

        public int numPrimo(int numfila)
        {
            numEntero number1 = new numEntero();
            int conta = 0;
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                number1.cargar(matriz[numfila, col1]);
                if(number1.esPrimo() == true)
                {
                    conta++;
                }
            }
            return conta;
        }

        // funcio 2
        public void cambiofilas2(int fil1, int fil2)
        {
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                this.intercambio(fil1, col1, fil2, col1);
            }
        }

        // funcion 3
        public void pregunta5()
        {
            for(int fil1 = 1; fil1 < this.fila; fil1++)
            {
                for (int fil2 = fil1 + 1; fil2 <= this.fila; fil2++)
                {
                    if(numPrimo(fil2) < numPrimo(fil1))
                    {
                        this.cambiofilas2(fil2, fil1);
                    }
                }
            }
        }

        // Pregunta 6
        public void pregunta6()
        {
            int idx;
            for(int col1 = 1; col1 < this.colum; col1++)
            {
                for(int fil1 = col1 + 1; fil1 <= this.fila; fil1++)
                {
                    for(int col2 = col1; col2 < this.colum; col2++)
                    {
                        if (col2 == col1)
                            idx = fil1;
                        else
                            idx = col2 + 1;
                        for(int fil2 = idx; fil2 <= this.fila; fil2++)
                        {
                            if(matriz[fil2, col2] > matriz[fil1, col1])
                            {
                                this.intercambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // Pregunta 7
        // funcion 1
        public int numElemDifer(int numfil)
        {
            int num, frecu = 0;
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                num = 0;
                for(int col2 = col1 + 1; col2 <= this.colum; col2++)
                {
                    if(matriz[numfil, col2] == matriz[numfil, col1])
                    {
                        num++;
                    }
                }
                if(num == 0)
                {
                    frecu++;
                }
            }
            return frecu;
        }

        // funcion 2
        public void cambioFilas3(int fil1, int fil2)
        {
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                this.intercambio(fil1, col1, fil2, col1);
            }
        }

        // funcion 3
        public void pregunta7()
        {
            for(int fil1 = 2; fil1 < this.fila; fil1++)
            {
                for(int fil2 = fil1 + 1; fil2 < this.fila; fil2++)
                {
                    if(numElemDifer(fil2) < numElemDifer(fil1))
                    {
                        this.cambioFilas3(fil2, fil1);
                    }
                }
            }
        }

        // pregunta 8
        public void pregunta8()
        {
            numEntero number1 = new numEntero();
            numEntero number2 = new numEntero();
            bool change = true;

            int idx, lin =this.fila, num;
            for(int col1 = 2; col1 <= this.colum; col1++)
            {
                for(int fil1 = lin; fil1 <= this.fila; fil1++)
                {
                    if(change == true)
                    {
                        num = lin;
                        for (int col2 = col1; col2 <= this.colum; col2++)
                        {
                            if (col2 == col1)
                                idx = fil1;
                            else
                                idx = num;
                            for (int fil2 = idx; fil2 <= this.fila; fil2++)
                            {
                                number1.cargar(matriz[fil2, col2]);
                                number2.cargar(matriz[fil1, col1]);

                                if (number1.espar() && !number2.espar() ||
                                    number1.espar() && number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                    !number1.espar() && !number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.intercambio(fil2, col2, fil1, col1);
                                }
                            }
                            num--;
                        }
                    }
                    else
                    {
                        num = lin;
                        for (int col2 = col1; col2 <= this.colum; col2++)
                        {
                            if (col2 == col1)
                                idx = fil1;
                            else
                                idx = num;
                            for (int fil2 = idx; fil2 <= this.fila; fil2++)
                            {
                                number1.cargar(matriz[fil2, col2]);
                                number2.cargar(matriz[fil1, col1]);

                                if (!number1.espar() && number2.espar() ||
                                    !number1.espar() && !number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                    number1.espar() && number2.espar() && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.intercambio(fil2, col2, fil1, col1);
                                }
                            }
                            num--;
                        }
                    }
                    change = !change;
                }
                lin--;
            }
        }

        // Pregunta 9
        // funcion 1
        public int elemFrecuCol(int numcol)
        {
            int frecu = 1, num;
            for(int fil1 = 1; fil1 < this.fila; fil1++)
            {
                num = 0;
                for(int fil2 = fil1 + 1; fil2 <= this.fila; fil2++)
                {
                    if(matriz[fil2, numcol] == matriz[fil1, numcol])
                    {
                        num++;
                    }
                }
                if(num == 0)
                {
                    frecu++;
                }
            }
            return frecu;
        }
        // funicon 2
        public void filamplia()
        {
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                matriz[this.fila + 1, col1] = elemFrecuCol(col1);
            }
            this.fila++;
        }

        // funcion 3
        public void cambioCols(int col1, int col2)
        {
            for(int fil1 = 1; fil1 <= this.fila; fil1++)
            {
                this.intercambio(fil1, col1, fil1, col2);
            }
        }

        // funcion 4
        public void pregunta9()
        {
            for(int col1 = 1; col1 < this.colum; col1++)
            {
                for(int col2 = col1 + 1; col2 <= this.colum; col2++)
                {
                    if(matriz[this.fila, col2] < matriz[this.fila, col1])
                    {
                        this.cambioCols(col2, col1);
                    }
                }
            }
        }


        // pregunta 10
        public void pregunta10()
        {
            int idx, num, lin = 2 ;
            for(int col1 = this.colum; col1 >= 2; col1--)
            {
                for(int fil1 = lin; fil1 <= this.fila; fil1++)
                {
                    num = lin;
                    for(int col2 = col1; col2 >=2; col2--)
                    {
                        if (col2 == col1)
                            idx = fil1;
                        else
                            idx = num;
                        for(int fil2 = idx; fil2 <= this.fila; fil2++)
                        {
                            if(matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.intercambio(fil2, col2, fil1, col1);
                            }
                        }
                        num++;
                    }
                }
                lin++;
            }
        }

        // pregunta 11
        // funcion 1
        public int elemento(int numfil)
        {
            int frecu, mayor = 0, numele, numfrecu = 0;
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                frecu = 0;
                numele = matriz[numfil, col1];
                for (int col2 = col1; col2 <= this.colum; col2++)
                {
                    if(matriz[numfil, col2] == numele)
                    {
                        frecu++;
                    }
                }
                if(frecu > mayor && frecu != 1)
                {
                    mayor = frecu;
                    numfrecu = numele;
                }
            }
            return numfrecu;
        }

        // funcion 1.1
        public int frecuencia(int numfil)
        {
            int frecu, mayor = 0, numele, numfrecu = 0;
            for (int col1 = 1; col1 <= this.colum; col1++)
            {
                frecu = 0;
                numele = matriz[numfil, col1];
                for (int col2 = col1; col2 <= this.colum; col2++)
                {
                    if (matriz[numfil, col2] == numele)
                    {
                        frecu++;
                    }
                }
                if (frecu > mayor && frecu != 1)
                {
                    mayor = frecu;
                }
            }
            return mayor;
        }

        // funcion 2
        public void pregunta11()
        {
            int maxcol = 1, maxcol2 = maxcol + 1;
            for(int fil1 = 1; fil1 <= this.fila; fil1++)
            {
                matriz[fil1, this.colum + maxcol] = this.elemento(fil1);
                matriz[fil1, this.colum + maxcol2] = this.frecuencia(fil1);
            }
            this.colum = this.colum + maxcol2;
        }
    }
}
