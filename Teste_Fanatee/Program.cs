using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Fanatee
{
   class Program
    {
        //Função que realiza o movimento do robô baseado no input, como por exemplo : "EAEAEAEAA";
        private static bool Orientaton_Moviment(string _mov, Robos robo, int x, int y)
        {
            //Verificar se todas as letras dadas no INPUT SÃO A, E ou D;
            if (Orientation_Verification(_mov))
            {
                //Como associou-se cada ponto cardial com uma variável inteira, logo ele so pode ter 3 orientações e não pode haver orientação com valor maior que 3;

                for (int i = 0; i < _mov.Length; i++)
                {
                    // Se for encontrato do INPUT a letra 'E' que significa virar 90º graus a esquerda, então:
                    if (_mov[i] == 'E')
                    {

                        //Quando se vira a esquerda ele soma 1 na orientação do robô, pois exemplo:
                        // Norte -> se virar a esquerda -> Oeste;
                        // Sul -> se virar a esqueda -> Leste;
                        // Oeste -> Se virar a esquerda -> Sul;

                        //Como se aumenta o valor da variável de orientação, pode-se aumnetar enquanto a orientação for menor que 3;
                        if (robo._coordination._ori < 3)
                        {
                            robo._coordination._ori += 1;
                        }
                        //Volta pro inicio se a orientação ja for 3;
                        else
                        {
                            robo._coordination._ori = 0;
                        }
                    }

                    // Se for encontrato do INPUT a letra 'D' que significa virar 90º graus a direita, então:
                    else if (_mov[i] == 'D')
                    {
                        // Quando se vira a direita ele diminui 1 na orientação do robô, pois exemplo:
                        // Norte -> se virar a direita -> Leste;
                        // Sul -> se virar a esqueda -> Oeste;
                        // Oeste -> Se virar a esquerda -> Norte;

                        //Como se diminui o valor da variável de orientação, pode-se diminiuir enquanto a orientação for maior que 0;
                        if (robo._coordination._ori > 0)
                        {
                            robo._coordination._ori -= 1;
                        }
                        //Vai pro final se a orientação ja for 0;
                        else
                        {
                            robo._coordination._ori = 3;
                        }
                    }
                    // Se for encontrato do INPUT a letra 'A' que significa que o robô se deslocará 1 unidade para frente e irá manter a orientação atual, então:
                    else if (_mov[i] == 'A')
                    {
                        Robot_Movimentation(ref robo, x, y);
                    }
                }
            }
            else
            {
                return false;
            }

                return true;
        }

        //Função que Movimenta o Robô;
        private static void Robot_Movimentation(ref Robos r, int x, int y)
        {
            int _orientation = r._coordination._ori;

            //Verifica se o robô se move dentro do platô; Para isso compara-se as coordenadas do robô com as do platô dadas;
            if (r._coordination.X <= x && r._coordination.Y <= y)
            {
                //Como as coordenadas do canto inferior esquerdo do platô são 0,0 e as coordenadas do canto superior direito são dadas, logo:

                // Se o robô estiver apontando para o norte, e for se deslocar a coordenda Y aumenta;
                if (_orientation == 0)
                {
                    r._coordination.Y += 1;
                }
                // Se o robô estiver apontando para o oste, e for se deslocar a coordenda X diminiu;
                else if (_orientation == 1)
                {
                    r._coordination.X -= 1;
                }
                // Se o robô estiver apontando para o sul, e for se deslocar a coordenda Y diminiu;
                else if (_orientation == 2)
                {
                    r._coordination.Y -= 1;
                }
                // Se o robô estiver apontando para o leste, e for se deslocar a coordenda X aumenta;
                else if (_orientation == 3)
                {
                    r._coordination.X += 1;
                }
            }
        }

        //Verifica as coordenadas tanto do platô, quanto do robo;
        private static bool Coordinates_Verification(string[] line)
        {
            //O limte do for é 2 , porque tanto os respectivos valores das coordenadas estão sempre nas 2 primeiras posições, evotando assim
            //problemas caso o usuário sem querer aperte uma letra a mais, ou um espaço;
            for(int i =0;i< 2; i++)
            {
                if(int.Parse(line[i]) < 0)
                {
                    Console.WriteLine("As COORDENADAS PRECISAM SEM VALORES POSITIVOS.");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }


        //Verifica se a movimentação dada foi correta, ou seja, se o usuário não digitou alguma letra diferente de A,E e D;
        private static bool Orientation_Verification(string line)
        { 
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != 'A' && line[i] != 'E' && line[i] != 'D')
                {
                    Console.WriteLine("AS ORIENTAÇÕS DE MOVIMENTAÇÃO SÃO FEITAS USANDO AS LETRAS A, E e D");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }

        //Verifica se as orientações cardiais dadas foram corretas, ou seja, se o usuário não digitou alguma letra diferente de N,O,S e L;
        private static bool Orientation_Cardial_Verification(char line)
        {
            if (line != 'N' && line != 'S' && line != 'L' && line != 'O')
            {
                Console.WriteLine("AS ORIENTAÇÕS SÃO FEITAS USANDO AS LETRAS N, O, S e L");
                return false;
            }

            return true;
        }


        //Função que mostra as coordenadas e orientações finais dos robôs;
        private static void Show_Robots_Coordinates(List<Robos> robos)
        {
            Console.WriteLine("\nCOORDENADAS E ORIENTAÇÕES FINAIS DOS ROBÔS");
            foreach (Robos r in robos)
            {
                Console.WriteLine(" " + r._coordination.X.ToString() + "  " + r._coordination.Y.ToString() + "  " + r._coordination.SetOrientationName());
            }
        }

        static void Main(string[] args)
        {
            //Lista que conterá todos os robôs que estão no platô;
            List<Robos> _robots = new List<Robos>();
            // Variável que armazenará as informações do robô;
            Robos r;
            // Variáveis que guardam as coordenadas (x,y) do canto superior direito do platô;
            int x_plato, y_plato;
            char choice;
            bool results;

            //Input das coordenadas (X,Y) do do canto superior direito do platô;

            do
            {
                Console.Clear();
                Console.Write("Coordenadas (X,Y) do platô: ");
                string[] _cordplato = Console.ReadLine().Split(' ');

                x_plato = int.Parse(_cordplato[0]);
                y_plato = int.Parse(_cordplato[1]);

                results = Coordinates_Verification(_cordplato);

            } while (!results);

                do
                    {
                do
                {
                    Console.Write("Coordenadas (X,Y) e a Orientação (N, O , S , L) do Robô: ");

                    //Variável que guarda o Input das coordenada (X,Y) e localização do robô;
                    // Separa o Input pelos espaços dados. Cada parte separada é salva em uma posição do vetor _corrobo;
                    string[] _coordrobot = Console.ReadLine().Split(' ');

                    // Guarda as informações do robô na lista;
                    //Passa a informação da orientação cardial para letra maiúscula para evitar erros caso
                    // algum usuário digitasse por engano a letra minúscula;
                    r = new Robos(int.Parse(_coordrobot[0]), int.Parse(_coordrobot[1]), char.Parse(_coordrobot[2].ToUpper()));

                    results = Orientation_Cardial_Verification(char.Parse(_coordrobot[2].ToUpper()));

                } while (!results);

                do
                {
                    Console.Write("Movimentação do Robô: ");
                    //Pega o INPUT relacionado a movimentação do Robô e passa tudo para letra maiúscula para evitar erros caso
                    // algum usuário digitasse por engano as letras minúsculas;
                    string _moviment = Console.ReadLine().ToUpper();

                    //Realiza a movimentação do robô no platô baseado no Input dado;
                    results = Orientaton_Moviment(_moviment, r, x_plato, y_plato);

                } while (!results);

                _robots.Add(r);

                do
                  {
                    //Verifica se o usuário quer continuar movimentando mais algum robô;
                     Console.Write("Deseja Movimentar mais Robôs? (S/N) -> ");
                     choice = char.Parse(Console.ReadLine());
                 } while (choice == 'S' && choice == 's' && choice == 'N' && choice == 'n');

            } while (choice == 'S' || choice == 's');

                    //Mostra as coordenadas e localização finais dos robôs;
                    Show_Robots_Coordinates(_robots);

                    Console.ReadKey();

          }
       
    }
}
