using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GreyhoundGame
{
    public class Greyhound
    {
        public int StartingPosition { get; set; }
        public int RacetrackLength { get; set; }
        public PictureBox MyPictureBox {get; set; }
        public int Location { get; set; }
        public Random Randomizer { get; set;}

        public bool Run()
        {
            int randomDistance = this.Randomizer.Next(1, 4); //최소값 및 최대값
            this.Location += randomDistance;

            Point p = this.MyPictureBox.Location;
            if (p.X > this.RacetrackLength)
            {
                return true;
            }
            else
            {
                p.X += randomDistance;
                this.MyPictureBox.Location = p;

                return false;
            }           
        }

        public void TakeStartingPosition()
        {
            this.Location = this.StartingPosition;

            Point p = this.MyPictureBox.Location;
            p.X = Location;
            this.MyPictureBox.Location = p;
        }
    }
}
