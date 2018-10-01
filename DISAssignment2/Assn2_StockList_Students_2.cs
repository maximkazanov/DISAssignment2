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

            //StockNode current = this.head;

            //List<StockNode> mergingList = new List<StockNode>();
            //mergingList.Add(current);
            //while (current.Next != null)
            //{
            //    mergingList.Add(current.Next);
            //    current = current.Next;
            //    for ()
            //    {

            //    }


            //}
            

            


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
            //StockNode initialMax = this.head;

            //while (current != null)
            //{
                
            //}

            List<StockNode> maxList = new List<StockNode>();
            maxList.Add(current);
            while (current.Next != null)
            {
                maxList.Add(current.Next);
                current = current.Next;
            }
            List<StockNode> sortedlist = maxList.OrderByDescending(x => x.StockHolding.Holdings).ToList();
            StockNode mostStock = sortedlist.First();



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