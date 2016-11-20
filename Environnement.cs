using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Blocs
{
    class Environnement
    {
        
        public Stack<Block> matrix;  // La pile des blocs originale
        public Stack<Block> place1;  // La place 1
        public Stack<Block> place2;  // La place 2
        
        //Environnement initialization
        public Environnement()
        {
            matrix = new Stack<Block>();
            place1 = new Stack<Block>();
            place2 = new Stack<Block>();

        }

        //Verifie si tous les blocs sont satisfaits
        public bool GoalAchieved(List<Block> blockList)
        {
            bool result = true;
            foreach (Block blc in blockList)
            {
                if (!blc.satisfied)
                    result = false;
            }
            return result;
        }

        //retourne le bloc en dessous 
        public string GetBlockBelow(Block bloc)
        {
            string result = "";

            for (int i = 0; i < matrix.Count; i++)
            {
                if (String.Equals(matrix.ElementAt(i).name, bloc.name))
                {
                    try
                    {
                        result = matrix.ElementAt(i + 1).name;
                    }
                    catch (Exception) { }
                }
            }

            for (int i = 0; i < place1.Count; i++)
            {
                if (String.Equals(place1.ElementAt(i).name, bloc.name))
                {
                    try
                    {
                        result = place1.ElementAt(i + 1).name;
                    }
                    catch (Exception) { }
                }
            }

            for (int i = 0; i < place2.Count; i++)
            {
                if (String.Equals(place2.ElementAt(i).name, bloc.name))
                {
                    try
                    {
                        result = place2.ElementAt(i + 1).name;
                    }
                    catch (Exception) { }
                }
            }


            return result;
        }

        //retourne l'etat de la place1
        public int GetPlace1State()
        {
            return place1.Count;
        }

        //retourne l'etat de la place 2
        public int GetPlace2State()
        {
            return place2.Count;
        }

        //verifie si le bloc est libre (pas de bloc en dessus)
        public bool CheckFree(Block block)
        {
            bool result = false;

            if(matrix.Count>0)
            {
                if (String.Equals(block.name, matrix.ElementAt(0).name))
                    result=true;
            }
            if (place1.Count > 0)
            {
                if (String.Equals(block.name, place1.ElementAt(0).name))
                    result = true;
            }
            if (place2.Count > 0)
            {
                if (String.Equals(block.name, place2.ElementAt(0).name))
                    result = true;
            }
            return result;

        }

        //retourne le bloc en dessus
        Block GetUpperBlock(Block block)
        {
            Block result = null; ;

            for (int i = 0; i < matrix.Count; i++ )
            {
                if (String.Equals(matrix.ElementAt(i).name, block.name))
                {
                    try
                    {
                        result = matrix.ElementAt(i - 1);
                    }
                    catch (Exception) { }
                }
            }

            for (int i = 0; i < place1.Count; i++)
            {
                if (String.Equals(place1.ElementAt(i).name, block.name))
                {
                    try
                    {
                        result = place1.ElementAt(i - 1);
                    }
                    catch (Exception) { }
                }
            }

            for (int i = 0; i < place2.Count; i++)
            {
                if (String.Equals(place2.ElementAt(i).name, block.name))
                {
                    try
                    {
                        result = place2.ElementAt(i - 1);
                    }
                    catch (Exception) { }
                }
            }

                return result;
        }

        //pousse le bloc en dessus
        public void Push(Block block)
        {
            GetUpperBlock(block).pushed = true;
        }

        //deplacer le bloc vers la place souhaitée
        public void Move(Block block, int place)
        {
            matrix.Pop();
            if (place == 1)
                place1.Push(block);
            else
                place2.Push(block);
        }
        
        //deplacer le bloc vers la pile initial 
        public void MoveBack(Block bloc, int previousPlace)
        {
            if (previousPlace == 1)
                place1.Pop();
            else
                place2.Pop();
           
            matrix.Push(bloc);
        }

        //Affichage de l'atat des piles (pile initiale, place1 et place 2)
        public void PrintState()
        {
            Console.WriteLine("_____________________");
            Console.WriteLine("===Pile Principale===");
            
            foreach (Block blc in matrix)
            {
                Console.WriteLine(blc.name);
            }
            
            Console.WriteLine("===Place 1===");

            foreach (Block blc in place1)
            {
                Console.WriteLine(blc.name);
            }

            Console.WriteLine("===Place 2===");

            foreach (Block blc in place2)
            {
                Console.WriteLine(blc.name);
            }

            Console.WriteLine("_____________________");

        }
        
    }
}
