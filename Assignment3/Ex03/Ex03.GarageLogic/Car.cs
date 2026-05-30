using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_color;
        protected int m_numberOfDoors;

        public Car(string i_Licence, string i_ModelName) :
            base(i_Licence, i_ModelName)
        { 
        }

        public eCarColor Color
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int numberOfDoors
        {
            get { return m_numberOfDoors; }
            set { m_numberOfDoors = value; }
        }
       





    }

}
