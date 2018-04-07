using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GreyhoundGame
{
    public class Guy
    {
        public string Name { get; set; }
        public Bet MyBet { get; set; }
        public int Cash { get; set; }
        public RadioButton MyRadioButton { get; set; }
        public Label MyLabel { get; set; }

        public void UpdateLabels()
        {
            this.MyRadioButton.Text = this.Name + " 는(은) " + this.Cash.ToString() + " 원 보유";
            this.MyLabel.Text = this.MyBet.GetDescription();
        }

        public void ClearBet()
        {
            this.MyBet.Amount = 0;
            this.MyRadioButton.Text = this.Name + " 는(은) " + this.Cash.ToString() + " 원 보유";
            this.MyLabel.Text = this.Name + " 는(은)어느 개에도 배팅 없음";
        }

        public bool PlaceBet(int amount, int dogNumber)
        {
            if (amount < this.Cash)
            {
                this.MyBet = new Bet() { Amount = amount, Dog = dogNumber, Better = this };
                UpdateLabels();

                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            if (this.Cash > 0)
            {
                this.Cash += this.MyBet.PayOut(Winner);
            }
        }
    }
}
