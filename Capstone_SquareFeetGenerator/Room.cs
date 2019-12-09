using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_SquareFeetGenerator
{
   public class Room
    {
        public enum Helper
        {
            area
        }

        private string _name;
        private double _length;
        private double _width;
        private double _area;
        private Helper _helper;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public Helper helper
        {
            get { return _helper; }
            set { _helper = value; }
        }


        public double AreaUser()
        {
            _area = Length * Width;

            return _area;
        }
    }
}
