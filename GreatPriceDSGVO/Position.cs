using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatPriceDSGVO
{
    class Position
    {
        private readonly int colPos;
        private readonly int rowPos;

        /// <summary>
        /// Constructor for the Position Class
        /// contains information for the column and the row, the object is in
        /// </summary>
        /// <param name="colPos">index of the column</param>
        /// <param name="rowPos">index of the row</param>
        public Position(int colPos, int rowPos)
        {
            this.colPos = colPos;
            this.rowPos = rowPos;
        }

        public String Output()
        {
            return (colPos + " " + rowPos);
        }

        public int GetCol()
        {
            return colPos;
        }

        public int GetRow()
        {
            return rowPos;
        }
    }
}
