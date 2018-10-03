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

            //The initial decimal variable “value” is introduced with a value of 0.0m, 
            //the m present to signify the use of abbreviations for larger numbers, m 
            //standing for million.Additionally, Stock “toPrint” and the StockNode “current” 
            //are introduced, “toPrint” serving as a placeholder, and “current” initializing 
            //the start of the list of stocks.

            decimal value = 0.0m;
            Stock toPrint = new Stock();
            StockNode current = this.head;

            //An if-else statement is introduced to ensure the function doesn’t cause a program 
            //error from the list reaching null, allowing the nodes to cycle through to completion. 
            //Within the else statement is a while loop, which sums the current value listed outside 
            //of the loop with the product of the holdings and price of the current node This then 
            //produces a value for each node, and thus each Stock in the portfolio.

            if (current == null)
            {
                return value;
            }
            else
            {
                while (current != null)
                {
                    value = value + current.StockHolding.CurrentPrice * current.StockHolding.Holdings;
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
        // Introduces intial int for similarity index as 0. This is 
        // currently a placeholder and will be modified accordingly.

        int similarityIndex = 0;

        // An "if - else" statement is introduced. The if section returns
        // the default value if the lists used for comparison are empty.

        if (this.IsEmpty() || listToCompare.IsEmpty())
        {
            return similarityIndex;
        }

        // The else statement introduces StockNodes "current1" and "current2".
        // These represent the initial list and the list for comparison to the
        // initial list.

        else
        {
            StockNode current1 = this.head;
            StockNode current2 = listToCompare.head;

            // The While loop works while both lists are not null. While this loop
            // is running, it uses the CompareTo() function to check each currently
            // active node from each list to see if they match or not. The index score
            // then increases if that is the case. It then cycles the two StockNodes
            // to the next node in the list, until no nodes remain.

            while (current1 != null)
            {
                while (current2 != null)
                {
                    if (current1.StockHolding.Name.CompareTo(current2.StockHolding.Name) == 0)
                    {
                        similarityIndex++;
                    }
                    current2 = current2.Next;
                }
                current2 = listToCompare.head;
                current1 = current1.Next;
            }

            // Finally, the loop then produces the final similarityIndex. The higher the value
            // in the index, the more similar the two lists are.

            return similarityIndex;
        }
        }

    //param        : NA
    //summary      : Print all the nodes present in the list
    //return       : NA
    //return type  : NA
    public void Print()
        {

            //A placeholder Stock “toPrint” and the StockNode 
            //“current” to initialize the nodes are introduced.

            this.SortByName();
            Stock toPrint = new Stock();
            StockNode current = this.head;

            //An if-else statement is introduced which cycles through each node 
            //and prints it to the console while the “current” does not signify 
            //as null.Once it does signify as null, the loop will close by printing the
            //final node listed. The result is each node is printed out based on their 
            //respective frame of reference in the program.

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