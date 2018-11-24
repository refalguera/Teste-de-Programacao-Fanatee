using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Fanatee
{
    public class Robos
    {
        public _coordenates _coordination;

        //Construtor da classe Robos , inicializa as variáveis qu guardam as informações das coordenadas (x,y) e sua orientação respctivamente;
        public Robos(int x, int y, char orientation)
        {
            this._coordination.X = x;
            this._coordination.Y = y;

            // Relaciona cada ponto cardeal com um valor inteiro;
            if (orientation == 'N')
            {
                this._coordination._ori = 0;
            }
            else if (orientation == 'O')
            {
                this._coordination._ori = 1;
            }
            else if (orientation == 'S')
            {
                this._coordination._ori = 2;
            }
            else if (orientation == 'L')
            {
                this._coordination._ori = 3;
            }
        }

        //Struct que guarda as informações relacioandas as coordenadas (X,Y) e a orientação;
        public struct _coordenates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int _ori { get; set; }

            //Como se associou valores inteiros aos pontos cardias, a função setOrientationName retorna então o char correspondente ao valor inteiro da orientação;
            public char SetOrientationName()
            {
                 if(_ori == 0)
                {
                    return 'N';
                }
                 else if(_ori == 1)
                {
                    return 'O';
                }
                else if (_ori == 2)
                {
                    return 'S';
                }
                else if (_ori == 3)
                {
                    return 'L';
                }

                return '0';
            }
        }

    }

}
