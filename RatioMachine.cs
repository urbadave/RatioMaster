using System;
using System.Collections.Generic;

namespace RatioMaster
{
    public class RatioMachine
    {
        public int Big { get; set; }
        public int Small { get; set; }
        public List<RatioItem> Candidates { get; set; }
        public RatioItem BestRatio { get; set; }
        public int MaxSmallNumber { get; set; }

        public RatioMachine()
        {
            Candidates = new List<RatioItem>();
        }

        public RatioMachine(int big, int small) : this()
        {
            if (big < -small)
                throw new ArgumentException($"{big} is not lager than {small}");
            Big = big;
            Small = small;
            MaxSmallNumber = 3;
        }

        public RatioItem FindBestRatio()
        {
            var retVal = new RatioItem();

            GetNearestTwo(1);
            GetNearestTwo(2);
            GetNearestTwo(3);

            Candidates.Sort();

            retVal = Candidates[0];

            return retVal;
        }

        public void GetNearestTwo(int smallNum)
        {
            var calc1 = (Big * smallNum) / Small;
            if (!IsLegal(calc1, smallNum)) calc1++;

            var compare1 = (calc1 * Small)/smallNum;
            var diff1 = Math.Abs(Big - compare1);

            int calc2;
            if(compare1 < Big)
            {
                calc2 = calc1+1;
                if (!IsLegal(calc2, smallNum)) calc2++;
            }
            else
            {
                calc2 = calc1-1;
                if (!IsLegal(calc2, smallNum)) calc2--;
            }

            var compare2 = (calc2 * Small) / smallNum;
            var diff2 = Math.Abs(Big - compare2);

            Candidates.Add(new RatioItem(calc1, smallNum, diff1));
            Candidates.Add(new RatioItem(calc2, smallNum, diff2));
        }

        public bool IsLegal(int test, int smallNum)
        {
            if (smallNum == 1) return true;
            if (test % smallNum != 0) return true;
            return false;
        }
    }
}
