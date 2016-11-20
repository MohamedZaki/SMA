using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Blocs
{
    class Block
    {
        public Environnement env; // L'environnement 
        public string name; // le nom du bloc
        public bool satisfied; // True si le bloc est satisfait
        public bool free; // True si le bloc est libre (pas de bloc en dessus)
        public bool pushed; // True si le bloc est poussé
        public string blockBelowName; // le nom du bloc en dessous actuel
        public string goalBlockName; //le bloc en dessous souhaité
        public int place1Weight; //l'etat de la place1 (le nombre de blocs qui occupe la place)
        public int place2Weight; //l'etat de la place 2 (le nombre de blocs qui occupe la palce)
        public int choosenPlace; //La place choisie pour se deplacer
        public bool onTable=false; // True si le block est sur la table (place1 ou place2) et non sur la pile principale


        //Le constructeur
        public Block(string name, Environnement env)
        {
            this.name = name;
            this.env = env;
        }

        //La perception de l'etat actuel du bloc
        public void GetPerception(Environnement env)
        {
            this.satisfied = CheckSatisfaction();
            this.free = env.CheckFree(this); 
            this.place1Weight = env.GetPlace1State();
            this.place2Weight = env.GetPlace2State();
        }

        //Verification de l'etat de satisfaction du bloc
        bool CheckSatisfaction()
        {
            bool result = false;
            blockBelowName = env.GetBlockBelow(this);

            try
            {   //si le bloc est non poussé et le bloc en dessous est le bloc souhaité et le bloc est sur la pile initiale
                if ((String.Equals(blockBelowName, goalBlockName)) && (!pushed) && (!onTable))
                    result = true;
            }
            catch (Exception) { }

            return result;
        }

        //Choisir l'action a faire selon son etat actuel percu
        public void TakeAction(Environnement env)
        {
            
            if (!satisfied)
            {
                if (free) //si le bloc est non satisfait et libre on se deplace
                {
                    Move();
                    pushed = false;
                }

                else //si le bloc est non satisfait et non libre on pousse
                    Push();
            }
        }

        //se deplacer
        void Move()
        {
            if (onTable) //si le bloc n'est pas sur la pile initiale on se deplace vers celle ci 
            {
                env.MoveBack(this, choosenPlace);
                onTable = false;
            }
            else
            {
                env.Move(this, GetNextPlace()); // sinon, le bloc se deplace vers la place la moins encombrée
                onTable = true;
            }

        }

        //Pousser
        void Push()
        {
            env.Push(this);
        }

        //Decider la prochaine place la moins occupée pour se deplacer
        int GetNextPlace()
        {
            if (place1Weight <= place2Weight)
            {
                choosenPlace = 1;
                return 1; 
            }
            else
            {
                choosenPlace = 2;
                return 2;
            }
                
        }

    }
}
