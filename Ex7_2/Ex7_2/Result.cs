// ***********************************************************************
// Assembly         : ex7_2
// Author           : Daniel Beckerich
// Created          : 12-5-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 12-5-2018
// ***********************************************************************
// Description: simple data container.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7_2
{
    class Result
    {
        private int min;
        private int max;

        public int Max { get => max; set => max = value; }
        public int Min { get => min; set => min = value; }

        public Result(int newMin, int newMax)
        {
            min = newMin;
            max = newMax;
        }

        public Result()
        {
            min = 0;
            max = 0;
        }
    }
}
