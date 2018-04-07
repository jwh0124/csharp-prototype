using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GreyhoundGame
{
    public partial class frmGreyhound : Form
    {
        private Guy[] _listOfGuys = null;
        private Greyhound[] _listOfDogs = null;
        private int _flag = 0;
        private bool _enableRaceBtn = false;

        public frmGreyhound()
        {
            InitializeComponent();          
            
        }

        private void frmGreyhound_Load(object sender, EventArgs e)
        {
            try
            {
                if (numBucks.Value == 5000)
                    lbl베팅정보.Text = "최소배팅 금액 : 5000 원";

                FillArrays();

                if (!this._enableRaceBtn)
                    btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void FillArrays()
        {
            Random myRandom = new Random();

            _listOfGuys = new Guy[3]
            {
                new Guy() 
                { 
                    Name = "Joe", 
                    Cash = 100000,  
                    MyBet = new Bet(), 
                    MyLabel = lblJoe, 
                    MyRadioButton = rdbJoe
                },

                new Guy()
                { 
                    Name = "Bob", 
                    Cash = 100000,  
                    MyBet = new Bet(),  
                    MyLabel = lblBob, 
                    MyRadioButton = rdbBob
                },

                new Guy() 
                { 
                    Name = "Al", 
                    Cash = 100000,  
                    MyBet = new Bet(), 
                    MyLabel = lblAl, 
                    MyRadioButton = rdbAl
                }
            };

            _listOfDogs = new Greyhound[4]
            {
                new Greyhound() 
                { 
                    RacetrackLength = pBoxRaceTrack.Width - 70, 
                    StartingPosition = pBoxRaceTrack.Location.X, 
                    Randomizer = myRandom, 
                    MyPictureBox = pBoxDog1
                },

                new Greyhound()
                { 
                    RacetrackLength = pBoxRaceTrack.Width - 70, 
                    StartingPosition = pBoxRaceTrack.Location.X, 
                    Randomizer = myRandom, 
                    MyPictureBox = pBoxDog2
                },

                new Greyhound() 
                { 
                    RacetrackLength = pBoxRaceTrack.Width - 70, 
                    StartingPosition = pBoxRaceTrack.Location.X, 
                    Randomizer = myRandom, 
                    MyPictureBox = pBoxDog3
                },

                new Greyhound() 
                { 
                    RacetrackLength = pBoxRaceTrack.Width - 70, 
                    StartingPosition = pBoxRaceTrack.Location.X, 
                    Randomizer = myRandom, 
                    MyPictureBox = pBoxDog4
                }
            };

            for (int i = 0; i < _listOfGuys.Length; i++)
            {
                _listOfGuys[i].MyBet.Better = _listOfGuys[i];
                _listOfGuys[i].UpdateLabels();
            }

            PlaceDogPicturesAtStart();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                RaceButtonWorking();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbJoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbJoe.Checked)
            {
                this._flag = 1;
                lblGuyName.Text = this._listOfGuys[0].Name;
            }
        }

        private void rdbBob_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBob.Checked)
            {
                this._flag = 2;
                lblGuyName.Text = this._listOfGuys[1].Name;
            }
        }

        private void rdbAl_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAl.Checked)
            {
                this._flag = 3;
                lblGuyName.Text = this._listOfGuys[2].Name;
            }
        }

        public void BetsButtonWorking()
        {
            int bucksNumber = 0;
            int dogNumber = 0;

            if (!rdbJoe.Checked && !rdbBob.Checked && !rdbAl.Checked)
            {
                MessageBox.Show("반드시 한사람은 선택해야 합니다.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bucksNumber = Convert.ToInt32(numBucks.Value);
            dogNumber = Convert.ToInt32(numDogNo.Value);

            if (IsExceedBetLimit(bucksNumber))
            {
                MessageBox.Show("최대 한마리에 15000원.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _enableRaceBtn = true; // if at least one bet is placed enable race button then

            if (this._flag == 1)
            {
                this._listOfGuys[0].PlaceBet(bucksNumber, dogNumber);
            }
            else if (this._flag == 2)
            {
                this._listOfGuys[1].PlaceBet(bucksNumber, dogNumber);
            }
            else if (this._flag == 3)
            {
                this._listOfGuys[2].PlaceBet(bucksNumber, dogNumber);
            }
        }

        public bool IsExceedBetLimit(int amount)
        {
            if (amount > 15000 && amount > 5000)
                return true;

            return false;
        }

        private void btnBets_Click(object sender, EventArgs e)
        {
            try
            {
                BetsButtonWorking();

                if (this._enableRaceBtn)
                    btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RaceButtonWorking()
        {
            btnBets.Enabled = false;
            btnStart.Enabled = false;

            bool winnerDogFlag = false;
            int winningDogNo = 0;

            while (!winnerDogFlag)
            {
                for (int i = 0; i < _listOfDogs.Length; i++)
                {
                    if (this._listOfDogs[i].Run())
                    {
                        winnerDogFlag = true;
                        winningDogNo = i;
                    }

                    pBoxRaceTrack.Refresh();
                }
            }

            MessageBox.Show("승리 경주견은  # " + (winningDogNo + 1) + "!", "경기 끝");

            for (int j = 0; j < _listOfGuys.Length; j++)
            {
                this._listOfGuys[j].Collect(winningDogNo + 1);
                this._listOfGuys[j].ClearBet(); // clearing all bets
            }

            PlaceDogPicturesAtStart();

            btnBets.Enabled = true;
        }

        public void PlaceDogPicturesAtStart()
        {
            for (int k = 0; k < _listOfDogs.Length; k++)
                _listOfDogs[k].TakeStartingPosition();
        }     
        
    }
}
