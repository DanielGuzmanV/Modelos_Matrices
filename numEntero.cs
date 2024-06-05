using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_De_Examen
{
    class numEntero
    {
        private int number;
        public numEntero()
        {
            number = 0;
        }
        public void cargar(int dato)
        {
            number = dato;
        }
        public int descargar()
        {
            return number;
        }
        public bool espar()
        {
            bool answer = false;
            if(this.number % 2 == 0)
            {
                answer = true;
            }
            return answer;
        }

        public bool esPrimo()
        {
            bool answer = false; int conta = 0;
            for(int idx = 1; idx <= this.number; idx++)
            {
                if (this.number % idx == 0)
                {
                    conta++;
                }
            }
            if(conta == 2)
            {
                answer = true;
            }
            return answer;
        }
    }
}
