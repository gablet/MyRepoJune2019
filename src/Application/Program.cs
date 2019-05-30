using System;
using CodeTest.Application;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Bottle bottle1 = new Bottle(3);
            Bottle bottle2 = new Bottle(5);
            int oneLiterToMeasure = 1;
            int fourlitersToMeasure = 4;
            WaterMeasuringService measuringService = new WaterMeasuringService();

            var measuringOneLiterResult = measuringService.MeasureVolumeTest(bottle1, bottle2, oneLiterToMeasure);
            var measuringFourLitersResult = measuringService.MeasureVolumeTest(bottle1, bottle2, fourlitersToMeasure);

            Console.WriteLine("The minimum amount of steps required to measure " + oneLiterToMeasure + " liter are "+ measuringOneLiterResult);
            Console.WriteLine("The minimum amount of steps required to measure " + fourlitersToMeasure + " liters are "+ measuringFourLitersResult);
        }
    }
}
