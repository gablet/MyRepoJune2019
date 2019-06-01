using System;
using Xunit;
using CodeTest.Application;

namespace CodeTest.Test.Unit
{
    public class BottleUnitTest
    {
        [Fact]
        public void ValidateThatABottleCanBeCreated()
        {
            //-------SETUP------
            int volume1 = 2;
            int volume2 = 13;

            // ---- EXECUTE -----
            Bottle bottle1 = new Bottle(volume1);
            Bottle bottle2 = new Bottle(volume2);


            // ---- EXECUTE -----
            Assert.Equal(volume1, bottle1.Volume);
            Assert.Equal(volume2, bottle2.Volume);
        }


        [Fact]
        public void ValidateThatAnExceptionIsThrownByNegativeVolume()
        {
            //-------SETUP------
            int volume = -1;

            // ---- EXECUTE -----
            Exception exception = Record.Exception(() => new Bottle(volume));


            //-----VALIDATE-------
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void ValidateThatBottleIsEmptyWhenCorrentVolumeIsZero()
        {
            //-------SETUP------
            Bottle bottle = new Bottle(3);

            // ---- EXECUTE -----
            bottle.CurrentVolume = 0;
            bool resultTrue = bottle.IsEmpty();

             bottle.CurrentVolume = 3;
            bool resultFalse = bottle.IsEmpty();


            //-----VALIDATE-------
            Assert.Equal(true, resultTrue);
            Assert.Equal(true, resultFalse);
        }

        
        [Fact]
        public void ValidateThatBottleIsFullWhenCorrentVolumeEqualsVolume()
        {
            //-------SETUP------
            Bottle bottle = new Bottle(5);

            // ---- EXECUTE -----
            bottle.CurrentVolume = 5;
            bool resultTrue = bottle.IsFull();

            bottle.CurrentVolume = 3;
            bool resultFalse = bottle.IsFull();


            //-----VALIDATE-------
            Assert.Equal(true, resultTrue);
            Assert.Equal(false, resultFalse);
        }
    }
}
