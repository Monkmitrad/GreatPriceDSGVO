using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatPriceDSGVO
{
    class Group
    {
        private string groupName;
        private int groupPoints;

        public Group(string groupName)
        {
            this.groupName = groupName;
            this.groupPoints = 0;
        }

        public int GetPoints()
        {
            return groupPoints;
        }

        public void AddPoints(int points)
        {
            this.groupPoints += points;
        }
    }
}
