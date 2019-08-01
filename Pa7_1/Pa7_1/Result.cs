// ***********************************************************************
// Assembly         : Pa7_1
// Author           : Daniel Beckerich
// Created          : 12-8-2018
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 12-8-2018
// ***********************************************************************
// Description: simple data container.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa7_1
{
    class Result
    {
        private int num;
        private int divisors;

        public int Num { get => num; set => num = value; }
        public int Divisors { get => divisors; set => divisors = value; }

        public Result(int newNum, int newCount)
        {
            Num = newNum;
            Divisors = newCount;
        }

        public Result()
        {
            Num = 0;
            Divisors = 0;
        }
    }
}
