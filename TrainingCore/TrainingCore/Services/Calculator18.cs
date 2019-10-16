using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingCore.Services
{
    public class Calculator18 : ICalculator
    {
        public double Calculate(double amount)
        {
            return (amount * (0.18));
        }
    }
}
