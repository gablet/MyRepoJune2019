using CodeTest.Application;
using System;

namespace CodeTest.Application
{
    public class WaterMeasuringService
    {
        public int MeasureVolumeTest(Bottle firstBottle, Bottle secondBottle, int litersToMeasure)
        {
            var firstMeasureResult = MeasureWater(firstBottle, secondBottle, litersToMeasure);
            var secondMeasureResult = MeasureWater(secondBottle, firstBottle, litersToMeasure);

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
            while (firstBottle.CurrentVolume != litersToMeasure && secondBottle.CurrentVolume != litersToMeasure)
            {

                if (IsEmpty(firstBottle))
                {
                    FillBottle(firstBottle);
                    steps ++;
                }

                if (IsFull(secondBottle))
                {
                    EmptyBottle(secondBottle);
                    steps ++;
                }

                TransferWater(firstBottle, secondBottle, firstBottle.CurrentVolume);
                steps ++;
            }
            EmptyBottle(firstBottle);
            EmptyBottle(secondBottle);
            return steps;
        }


        private void TransferWater(Bottle sourceBottle, Bottle targetBottle, int litersToTransfer)
        {

            for (int i = 0; i < litersToTransfer; i++)
            {
                while (!IsFull(targetBottle) && !IsEmpty(sourceBottle))
                {
                    targetBottle.CurrentVolume ++;
                    sourceBottle.CurrentVolume --;
                }
            }
        }


        private int AmoutOfVolumeLeft(Bottle bottle)
        {
            return bottle.Volume - bottle.CurrentVolume;
        }


        private bool IsEmpty(Bottle bottle)
        {
            if (bottle.CurrentVolume == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void EmptyBottle(Bottle bottle)
        {
            bottle.CurrentVolume = 0;
        }


        private bool IsFull(Bottle bottle)
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


        public void FillBottle(Bottle bottle)
        {
            bottle.CurrentVolume = bottle.Volume;
        }
    }
}