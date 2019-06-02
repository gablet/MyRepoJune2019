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
            int oneLiter = 1;
            int fourliters = 4;

            WaterMeasuringService measuringService = new WaterMeasuringService();
            int measuringOneLiterResult = measuringService.LeastAmountOfStepsToMeasureWater(bottle1, bottle2, oneLiter);
            int measuringFourLitersResult = measuringService.LeastAmountOfStepsToMeasureWater(bottle1, bottle2, fourliters);

            Console.WriteLine("The minimum amount of steps required to measure " + oneLiter + " liter are "+ measuringOneLiterResult);
            Console.WriteLine("The minimum amount of steps srequired to measure " + fourliters + " liters are "+ measuringFourLitersResult);
        }
    }
}
