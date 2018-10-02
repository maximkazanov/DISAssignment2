using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
  public partial class StockList
  {
    //param        : NA
    //summary      : Calculate the value of each node by multiplying holdings with price, and returns the total value
    //return       : total value
    //return type  : decimal
    public decimal Value()
    {
            decimal value = 0.0m;
            Stock toPrint = new Stock();
            StockNode current = this.head;

            if (current == null)
            {
                return value;
            }
            else
            {
                while (current != null)
                {
                    value = value + current.StockHolding.CurrentPrice*current.StockHolding.Holdings;
                    current = current.Next;
                }
                return value;
            }
    }

    //param  (StockList) listToCompare     : StockList which has to comared for similarity index
    //summary      : finds the similar number of nodes between two lists
    //return       : similarty index
    //return type  : int
    public int Similarity(StockList listToCompare)
    {
      int similarityIndex = 0;

      // write your implementation here

      return similarityIndex;
    }

    //param        : NA
    //summary      : Print all the nodes present in the list
    //return       : NA
    //return type  : NA
    public void Print()
    {
            Stock toPrint = new Stock();
            StockNode current = this.head;

            if (current == null)
            {
                Console.WriteLine(toPrint);
            }
            else
            {
                while (current != null)
                {
                    toPrint = current.StockHolding;
                    Console.WriteLine(toPrint);
                    current = current.Next;
                }
            }

        }
    }
}