using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Blocs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creation de l'environnement
            Environnement env = new Environnement(); 

            //Creation des blocs
            Block ba = new Block("A", env);  
            Block bb = new Block("B", env);  
            Block bc = new Block("C", env);  
            Block bd = new Block("D", env);
            List<Block> blockList = new List<Block>() { ba, bb, bc, bd };

            //Initialisation des bloc de dessous souhaités de chaque bloc (Agencement souhaité)
            ba.goalBlockName = "B";  
            bb.goalBlockName = "C";  
            bc.goalBlockName = "D";  
            bd.goalBlockName = "";  

            //Creation et remplissage de la pile initiale
            env.matrix = new Stack<Block>();
            env.matrix.Push(bd);
            env.matrix.Push(ba);
            env.matrix.Push(bb);
            env.matrix.Push(bc);


            //Tant que le but n'est pas atteint (la satisfaction de tous les blocs) les agents executent leurs Perception-Action
            while (!env.GoalAchieved(blockList))
            {
                env.PrintState();
                foreach (Block block in blockList)
                {
                    block.GetPerception(env);
                    block.TakeAction(env);
                }
            }
              
             Console.ReadLine();

        }

        
    }
}
