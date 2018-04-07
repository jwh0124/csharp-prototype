using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreyhoundGame
{
    public class Bet
    {
        public int Amount { get; set;}
        public int Dog { get; set;}
        public Guy Better {get; set;}

        public string GetDescription()
        {
            if (this.Amount == 0)
            {
                return this.Better.Name + " 는(은) 어느 개에도 배팅 없음";
            }
            else
            {
                return this.Better.Name + " 는(은) " + this.Better.MyBet.Dog.ToString() + " 개에 " + this.Better.MyBet.Amount.ToString() + " 원 배팅";
            }
        }

        public int PayOut(int Winner)
        {
            if (this.Better.MyBet.Dog == Winner)
            {
                return this.Amount;
            }
            else
            {
                return -this.Amount;
            }
        }
    }
}
