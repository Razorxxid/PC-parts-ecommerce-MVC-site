using e_commerce.Models.asbstractClasses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models.implementations
{
    

    public class Processor : AbstractProduct 
    {

      

  
        private double baseClockSpeed;

        private double boostClockSpeed;

        public Processor() 
        {

        }

     
        public double BaseClockSpeed { get => baseClockSpeed; set => baseClockSpeed = value; }
        public double BoostClockSpeed { get => boostClockSpeed; set => boostClockSpeed = value; }


    }
}
