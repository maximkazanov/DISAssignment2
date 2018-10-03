using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

// Matthew Matos Self-Reflection

//Looking back at the week of trials and tribulations that went into this assignment, I believe that 
//a better foundational knowledge of C# and LINQ functions would serve me a lot better in the future. 
//The primary problem that I faced while working on this assignment was having a below-rudimentary 
//understanding of just exactly how information was being called by all of the scripts. Even now, I 
//still don’t have a complete understanding of how exactly StockNode functions in the capacity that it does. 
//Additionally, while we did have the basics of classes and LINQ functions explained to us in class, applying 
//that across multiple scripts produces a new problem entirely.

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
            //Three preliminary variables are introduced. “resultList” is a new 
            //StockList which will hold what will be the final merged list of stocks. 
            //StockNode “current1” initializes the list of nodes to be cycled through, and 
            //StockNode “current2” initializes the beginning of 2nd list of nodes. The end 
            //result will produce a merged list of these two lists of nodes.


            StockList resultList = new StockList();
            StockNode current1 = this.head;
            StockNode current2 = listToMerge.head;

            //An “if- else if - else if - else” statement is introduced which cycles 
            //through depending on if “current1” and “current2” hold null values or 
            //not.The presence of a null value for either will return a new updated
            //value for resultList based on either list.Within the else statement is a 
            //while loop for both StockNodes, which cycles through the nodes and adds 
            //them to the resultList using the AddStock() function found in StockList_Students_1.

            if (current1 == null && current2 == null)
            {
                return resultList;
            }
            else if (current1 == null)
            {
                resultList = listToMerge;
                return resultList;
            }
            else if (current2 == null)
            {
                resultList = this;
                return resultList;
            }
            else
            {
                while (current1 != null)
                {
                    resultList.AddStock(current1.StockHolding);
                    current1 = current1.Next;
                }
                resultList.SortByName();
                while (current2 != null)
                {
                    resultList.AddStock(current2.StockHolding);
                    current2 = current2.Next;
                }
                resultList.SortByName();

                //Finally, the SortByName() function, also referenced from StockList_Students_1, 
                //is used to sort all of the stocks into appropriate alphabetical order, once they 
                //are present within the final resultList.

                return resultList;
            }
    }

    //param        : NA
    //summary      : finds the stock with most number of holdings
    //return       : stock with most shares
    //return type  : Stock
    public Stock MostShares()
        {

            //This function introduces a new Stock labelled “result”,
            //along with introducing the StockNode “current”, initiating
            //the start of the chain. 

            Stock result = new Stock();
            StockNode current = this.head;

            //An if-else loop is then introduced. This establishes the conditions
            //for cycling through each of the stocks in order.Until the loop produces 
            //a null value, the loop will cycle through each stock holding replacing the
            //currently held max stock with a new stock if it satisfies the conditions of the loop.

            if (current == null)
            {
                return result;
            }
            else if (current.Next == null)
            {
                result = current.StockHolding;
                return result;
            }
            else
            {
                List<StockNode> maxList = new List<StockNode>();
                maxList.Add(current);

                //The conditions of the loop are explained within the while loop, which is 
                //used to set up a loop with LINQ, ordering the list of stocks in descending
                //order using the number of holdings as its criteria for the ordering, and 
                //returning the appropriate maximum stock.

                while (current.Next != null)
                {
                    maxList.Add(current.Next);
                    current = current.Next;
                }
                result = maxList.OrderByDescending(x => x.StockHolding.Holdings).ToList().First().StockHolding;
                return result;
            }
        }

        //param        : NA
        //summary      : finds the number of nodes present in the list
        //return       : length of list
        //return type  : int
        public int Length()
        {
            //The integer Length is initially introduced as an integer with a 
            //value of 0.Additionally, the “current” StockNode is introduced to 
            //start the chain.

            int length = 0;

            StockNode current = this.head;

            //“current” is then run through an if-else loop.While there are still 
            //nodes to be referenced in “current”, it will cycle through each node and 
            //made a revision to the value of Length.This will continue until the sequence 
            //breaks when current returns a null.The resulting length integer will be the 
            //number of stocks the portfolio contains.

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