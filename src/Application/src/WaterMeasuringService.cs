using CodeTest.Application;
using System;

namespace CodeTest.Application
{
    public class WaterMeasuringService
    {
        public int LeastAmountOfStepsToMeasureWater(Bottle bottle1, Bottle bottle2, int volumeToMeasure)
        {
            int firstMeasureResult = MeasureWater(bottle1, bottle2, volumeToMeasure);
            int secondMeasureResult = MeasureWater(bottle2, bottle1, volumeToMeasure);

            return Math.Min(firstMeasureResult, secondMeasureResult);
        }


        private int MeasureWater(Bottle bottle1, Bottle bottle2, int volumeToMeasure)
        {
            int steps = 0;
            if (!bottle1.IsEmpty()) EmptyBottle(bottle1);
            if (!bottle2.IsEmpty()) EmptyBottle(bottle2);
            
            while (bottle1.CurrentVolume != volumeToMeasure && bottle2.CurrentVolume != volumeToMeasure)
            {
                if (bottle1.IsEmpty())
                {
                    FillBottle(bottle1);
                    steps++;
                }

                if (bottle2.IsFull())
                {
                    EmptyBottle(bottle2);
                    steps++;
                }

                TransferWater(bottle1, bottle2);
                steps++;
            }

            return steps;
        }


        public void TransferWater(Bottle sourceBottle, Bottle targetBottle)
        {

            while (!targetBottle.IsFull() && !sourceBottle.IsEmpty())
            {
                targetBottle.CurrentVolume++;
                sourceBottle.CurrentVolume--;
            }
        }


        public void EmptyBottle(Bottle bottle)
        {

            if (bottle.CurrentVolume == 0)
            {
                throw new ArgumentException("Bottle is already empty");
            }
            bottle.CurrentVolume = 0;
        }


        public void FillBottle(Bottle bottle)
        {
            if (bottle.CurrentVolume == bottle.Volume)
            {
                throw new ArgumentException("Bottle is already full");
            }
            bottle.CurrentVolume = bottle.Volume;
        }
    }
}