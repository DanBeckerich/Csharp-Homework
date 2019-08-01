// ***********************************************************************
// Assembly         : Project4
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11/18/2018
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>Exception class that is used to tell the programmer when there is a collision</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project4
{
    //implementation for the CollisionException
    class CollisionException : Exception
    {
        public CollisionException()
        {
            //empty constructor
        }
        public CollisionException(string message) : base(message)
        {
            //constructor with a message
        }


    }
}
