using CodeTest.Application;
using Xunit;

namespace CodeTest.Test.Unit
{
    public class WaterMeasuringServiceUnitTest
    {
        [Fact]
        public void ValidateThatMeasuringTestResturnCorrectResult()
        {
        //-------SETUP------
        Bottle bottle1 = new Bottle(5);
        Bottle bottle2 = new Bottle(3);
        int amoutToMeasure = 4;
        WaterMeasuringService measuringServce = new WaterMeasuringService();
        
        // ---- EXECUTE -----
        var result = measuringServce.MeasureVolumeTest(bottle1, bottle2, amoutToMeasure);
        
        //-----VALIDATE-------
        Assert.Equal(6, result);
        }
    }
}