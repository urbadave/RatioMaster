using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatioMaster
{
    public class RatioItem: IComparable<RatioItem>
    {
        public int Big { get; set; }
        public int Small { get; set; }
        public int Difference { get; set; }

        public RatioItem() { }
        public RatioItem(int big, int small, int difference)
        {
            Big = big;
            Small = small;
            Difference = difference;
        }

        public int CompareTo(RatioItem other)
        {
            if (other == null) return -1;
            if (Difference == other.Difference)
                if (Big == other.Big)
                    return Small.CompareTo(other.Small);
                else
                    return (Big.CompareTo(other.Big));
            else
                return Difference.CompareTo(other.Difference);
        }
    }
}
