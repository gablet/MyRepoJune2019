using System;
namespace CodeTest.Application
{
    public class Bottle
    {
        public readonly int Volume;
        public int CurrentVolume { get; set; }
        private const int MINIMUM_VOLUME = 0;


        public Bottle(int volume)
        {
            if (volume < MINIMUM_VOLUME)
            {
                throw new ArgumentException();
            }
            this.Volume = volume;
            this.CurrentVolume = 0;
        }


        public bool IsFull(Bottle bottle)
        {
            if (bottle.CurrentVolume == bottle.Volume)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}