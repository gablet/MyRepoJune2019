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
            Volume = volume;
            CurrentVolume = 0;
        }


        public bool IsFull()
        {
            if (CurrentVolume == Volume)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsEmpty()
        {
            if (CurrentVolume == 0)
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