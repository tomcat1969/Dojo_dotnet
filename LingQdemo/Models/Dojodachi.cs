using System;

namespace LingQdemo.Models
{
    public class Dojodachi
    {
        public int  Happiness { get; set; }
        public int  Fullness { get; set; }
        public int  Energy { get; set; }

        public int Meals {get;set;}

        public Dojodachi()
        {
            this.Happiness = 20;
            this.Fullness = 20;
            this.Energy = 50;
            this.Meals = 3;
        }

        public string display()
        {
            return $"Fullness : {this.Fullness}     Happiness : {this.Happiness}       Meals : {this.Meals}      Energy : {this.Energy}";
        }

        public string Feeding()
        {
            if(this.Meals <= 0) 
            {
                return "you have no meals,so can not feed you Dojodochi";
            }

            if(isLikeIt()) 
            {
                Random random = new Random();
                int amount = random.Next(6,11);
                this.Meals -= 1;
                this.Fullness += amount;
                return $"You feed you Dojodochi ! Fullness + {amount} , Meals - 1";
            }else{
                this.Meals -= 1;
                return $"You feed you Dojodochi ! Fullness + 0 , Meals - 1";
            }
            

        }

        public string playing()
        {
             if(isLikeIt()) 
             {
                 Random random = new Random();
                 int amount = random.Next(6,11);
                 this.Energy -= 5;
                 this.Happiness += amount;
                 return $"You played with your Dojodochi ! Happiness + {amount} , Energy - 5 !";   
             }else{
                 this.Energy -= 5;
                 return $"You played with your Dojodochi ! Happiness + 0 , Energy - 5 !";
             }
           
        }

        public string working()
        {
            Random random = new Random();
            int amount = random.Next(1,4);
            this.Meals += amount;
            this.Energy -= 5;
            return $" your Dojodochi work ! Meals + {amount} , Energy - 5 !";
        }

        public string sleeping()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            return $" your Dojodochi slept! Fullness - 5 , Happiness - 5 , Energy + 15 !";
        }

        public bool IsWin()
        {
            if(this.Energy >= 100 && this.Happiness >= 100 && this.Fullness >= 100)
            {
                return true;
            }
            return false;
        }

        public bool IsLose()
        {
            if(this.Fullness <= 0 || this.Happiness <= 0 )
            {
                return true;
            }
            return false;
        }












        private bool isLikeIt()
        {
            Random random = new Random();
            if (random.Next(0,4)== 1) 
            {
                return true;
            }
            return false;
        }

    }
}