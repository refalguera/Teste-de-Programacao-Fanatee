using System;
using System.Collections.Generic;

namespace Teste_Fanatee
{
    public class Robos
    {
        public IDictionary<int, char> _orientation = { (0, 'N'), (1, 'O'), (2, 'S'), ('L', 3) };
        public _coordenates _cor;

        public Robos(int x, int y, char orientation)
        {
            this._cor.x = x;
            this._cor.y = y;

            if (orientation == 'N')
            {
                this._cor._ori = 0;
            }
            else if (orientation == 'O')
            {
                this._cor._ori = 1;
            }
            else if (orientation == 'S')
            {
                this._cor._ori = 2;
            }
            else if (orientation == 'L')
            {
                this._cor._ori = 3;
            }
        }

        public struct _coordenates
        {
            public int x { get; set; }
            public int y { get; set; }
            public int _ori { get; set; }
        }

    }
}