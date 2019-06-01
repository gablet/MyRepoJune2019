using CodeTest.Application;
using System;

namespace CodeTest.Application
{
    public class WaterMeasuringService
    {
        public int MeasureVolumeTest(Bottle bottle1, Bottle bottle2, int litersToMeasure)
        {
            var firstMeasureResult = MeasureWater(bottle1, bottle2, litersToMeasure);
            var secondMeasureResult = MeasureWater(bottle2, bottle1, litersToMeasure);

            if (firstMeasureResult < secondMeasureResult)
            {
                return firstMeasureResult;
            }
            else
            {
                return secondMeasureResult;
            }
        }


        private int MeasureWater(Bottle firstBottle, Bottle secondBottle, int litersToMeasure)
        {
            int steps = 0;
            if (!firstBottle.IsEmpty()) EmptyBottle(firstBottle);
            if (!secondBottle.IsEmpty()) EmptyBottle(secondBottle);
            
            while (firstBottle.CurrentVolume != litersToMeasure && secondBottle.CurrentVolume != litersToMeasure)
            {

                if (firstBottle.IsEmpty())
                {
                    FillBottle(firstBottle);
                    steps++;
                }

                if (secondBottle.IsFull())
                {
                    EmptyBottle(secondBottle);
                    steps++;
                }

                TransferWater(firstBottle, secondBottle);
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