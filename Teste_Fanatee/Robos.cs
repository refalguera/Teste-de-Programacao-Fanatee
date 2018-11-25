using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Fanatee
{
    public class Robos
    {
        //Irá se associar valores inteiros aos pontos cardias, assim cria-se um Dicionário para guardar essa associação;
        //Quando for necessário saber em char, a orientação do robô, é so acessar o dicionário;
        //Irá ser usado na mostra das orientações finais dos robôs;
        public Dictionary<int, char> _orientation = new Dictionary<int, char>() { { 0, 'N'}, { 1, 'O'}, { 2, 'S'}, { 3,'L'} };

        //Variável que guardará as irnformações referentes as coordenadas e orientação do robô;
        public _coordenates _coordination;

        //Construtor da classe Robos , armazena na variável _coordination as informações das coordenadas (x,y) e sua orientação respctivamente;
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

        //Struct relacionada as informações das coordenadas (X,Y) e a orientação em valor inteiro;
        public struct _coordenates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int _ori { get; set; }
        }

    }

}
