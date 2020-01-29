using System;

namespace nesting_dolls.Models
{
    class Game
    {
        public Doll CurrentDoll { get; set; }

        public void Setup()
        {
            //Make the Data
            Doll chewbacca = new Doll("Chewbacca");
            Doll han = new Doll("Han Solo");
            Doll obi = new Doll("Obi-Wan");
            Doll luke = new Doll("Luke");
            Doll leia = new Doll("Leia");
            Doll c3p0 = new Doll("C-3P0");
            Doll r2d2 = new Doll("R2-D2");

            //Establish Relationships
            chewbacca.OuterDoll = r2d2;
            chewbacca.InnerDoll = han;
            han.OuterDoll = chewbacca;
            han.InnerDoll = obi;
            obi.OuterDoll = han;
            obi.InnerDoll = luke;
            luke.OuterDoll = obi;
            luke.InnerDoll = leia;
            leia.OuterDoll = luke;
            leia.InnerDoll = c3p0;
            c3p0.OuterDoll = leia;
            c3p0.InnerDoll = r2d2;
            r2d2.OuterDoll = c3p0;
            r2d2.InnerDoll = chewbacca;

            CurrentDoll = chewbacca;
        }

        public void RemoveCurrent()
        {
            CurrentDoll.OuterDoll.InnerDoll = CurrentDoll.InnerDoll;
            CurrentDoll.InnerDoll.OuterDoll = CurrentDoll.OuterDoll;
            CurrentDoll = CurrentDoll.OuterDoll;
        }

        public void Next()
        {
            Console.Clear();
            if (CurrentDoll.InnerDoll != null)
            {
                CurrentDoll = CurrentDoll.InnerDoll;
                System.Console.WriteLine("Current doll is " + CurrentDoll.Name);
                return;
            }
            System.Console.WriteLine("There is no Inner Doll");
        }
        public void Previous()
        {
            Console.Clear();
            if (CurrentDoll.OuterDoll != null)
            {
                CurrentDoll = CurrentDoll.OuterDoll;
                System.Console.WriteLine("Current doll is " + CurrentDoll.Name);
                return;
            }
            System.Console.WriteLine("There is no Outer Doll");
        }
    }
}