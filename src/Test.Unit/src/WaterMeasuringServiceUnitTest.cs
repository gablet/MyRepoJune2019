using System;
using CodeTest.Application;
using Xunit;

namespace CodeTest.Test.Unit
{
    public class WaterMeasuringServiceUnitTest
    {
        [Fact]
        public void ValidateThatMeasuringTestResturnsCorrectResult()
        {
            //-------SETUP------
            Bottle sourceBottle = new Bottle(5);
            Bottle targetBottle = new Bottle(3);
            int amoutToMeasure = 4;
            WaterMeasuringService measuringServce = new WaterMeasuringService();

            // ---- EXECUTE -----
            var result = measuringServce.LeastAmountOfStepsToMeasureWater(sourceBottle, targetBottle, amoutToMeasure);

            //-----VALIDATE-------
            Assert.Equal(6, result);
        }


        [Fact]
        public void ValidateThatAnExceptionIsThrownWhenFillingAFullBottle()
        {
            //-------SETUP------
            Bottle bottle = new Bottle(5);
            bottle.CurrentVolume = 5;
            WaterMeasuringService measuringServce = new WaterMeasuringService();

            // ---- EXECUTE -----
            Exception exception = Record.Exception(() => measuringServce.FillBottle(bottle));

            //-----VALIDATE-------
            Assert.IsType<ArgumentException>(exception);
        }


        [Fact]
        public void ValidateThatAnExceptionIsThrownWhenEmptyingAnEmptyBottle()
        {
            //-------SETUP------
            Bottle bottle = new Bottle(5);
            bottle.CurrentVolume = 0;
            WaterMeasuringService measuringServce = new WaterMeasuringService();

            // ---- EXECUTE -----
            Exception exception = Record.Exception(() => measuringServce.EmptyBottle(bottle));

            //-----VALIDATE-------
            Assert.IsType<ArgumentException>(exception);
        }


        [Fact]
        public void ValidateThatWaterBeingTransferedIsNeverMoreThanTheVolumeOfTheSourceBottle()
        {
            //-------SETUP------
            Bottle sourceBottle = new Bottle(5);
            Bottle targetBottle = new Bottle(6);
            WaterMeasuringService measuringServce = new WaterMeasuringService();

            // ---- EXECUTE -----
            measuringServce.FillBottle(sourceBottle);
            measuringServce.TransferWater(sourceBottle, targetBottle);

            //-----VALIDATE-------
            Assert.Equal(sourceBottle.Volume, targetBottle.CurrentVolume);
        }
    }
}