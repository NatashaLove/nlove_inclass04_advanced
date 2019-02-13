using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trial
{
    class Thing
    {
        private int _number;
        //getter&setter - value takes value of the number from the constructor below
            public int Number { get { return _number; } set { _number = value; } }
        //constructor makes the "value" take the value of number
        public Thing(int number) { Number = number; }

    }
}
