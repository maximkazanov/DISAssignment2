using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Assignment_2
{
  public partial class StockList
  {
    //param   (StockList)listToMerge : second list to be merged 
    //summary      : merge two different list into a single result list
    //return       : merged list
    //return type  : StockList
    public StockList MergeList(StockList listToMerge)
    {
      StockList resultList = new StockList();

            StockNode current = this.head;

            List<StockNode> unsortedList = new List<StockNode>();
            unsortedList.Add(current);
            while (current.Next != null)
            {
                unsortedList.Add(current.Next);
                current = current.Next;
            }

            List<StockNode> mergedList = unsortedList.OrderBy(z => z.StockHolding.Name).ToList();

            return resultList;
    }

    //param        : NA
    //summary      : finds the stock with most number of holdings
    //return       : stock with most shares
    //return type  : Stock
    public Stock MostShares()
    {
      Stock mostShareStock = null;

            StockNode current = this.head;
            StockNode initialMax = this.head;

            while (current != null)
            {
                
            }



            //StockNode current = this.head;

            //List<StockNode> unsortedList = new List<StockNode>();
            //unsortedList.Add(current);
            //while (current.Next != null)
            //{
            //    unsortedList.Add(current.Next);
            //    current = current.Next;
            //}
            //List<StockNode> sortedList = unsortedList.OrderByDescending(x => x.StockHolding.Holdings).ToList();



            //write your implementation here

            return mostShareStock;
        }

        //param        : NA
        //summary      : finds the number of nodes present in the list
        //return       : length of list
        //return type  : int
        public int Length()
        {
            int length = 0;

            StockNode current = this.head;
            StockNode current2 = this.head;

            if (current == null)
                return 0;
            else if (current.Next == null)
                return 1;
            else
            {
                while (current != null)
                {
                    current = current.Next;
                    length++;
                }
                return length;
            }
        }
    }
}