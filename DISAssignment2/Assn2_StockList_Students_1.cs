﻿//Maxim Kazanov: I enjoyed completing this assignment because 1) it was about building end-to-end solution and 
//2) it was a comprehensive, integrated test of key aspects of software development: objects manipulation, 
//querying and working with data in object-oriented environment, debugging, collaboration. For example, 
//working with Git, understanding how to override or not to override other people’s code, “undoing” changes 
//was a by-product of completing bigger assignment. It’s like learning a foreign language to understand 
//books, movies or speech compared to just memorizing foreign words for its own sake. The assignment had 
//a good amount of repetition which resulted in “muscle memory” on top surprisingly steep learning curve 
//so that when assignment was completed my own legacy code of first methods seemed clumsy and unprofessional.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment_2
{
    public partial class StockList
    {
        private StockNode head;

        //Constructor for initialization
        public StockList()
        {
            this.head = null;
        }

        //param        : NA
        //summary      : checks if the list is empty
        //return       : true if list is empty, false otherwise
        //return type  : bool
        public bool IsEmpty()
        {
            if (this.head == null)
            {
                return true;
            }
            return false;
        }

        //param (Stock)stock : stock that is to be added
        //summary      : Add node at first position in list
        //                This is done by creating a new node 
        //                  and pointing it to the current list 
        //return       : NA
        //return type  : NA
        public void AddFirst(Stock stock)
        {
            StockNode nodeToAdd = new StockNode(stock);
            nodeToAdd.Next = head;
            head = nodeToAdd;
        }

        //param (Stock)stock : stock that is to be added
        //summary      : Add mode at last position of list
        //  This is done by traversing the list till we reach the end
        // and pointing the last node to the new node
        // return       :
        // return type  :
        public void AddLast(Stock stock)
        {
            // for an empty list, we add the node at the top of the list
            if (this.IsEmpty())
                AddFirst(stock);
            else
            {
                // traverse the list till the end
                StockNode current = this.head;
                while (current.Next != null)
                    current = current.Next;

                // point the last node to the new node
                StockNode nodeToAdd = new StockNode(stock);
                current.Next = nodeToAdd;
            }
        }

        /// <summary>
        /// Add node in an alphabetically sorted manner, if stock is already present then set holdings to sum of existing and new stock
        ///   We assume that the list is always sorted in alphabetical order
        ///   The stock may be added either at:
        ///     the top of the list (if alphabetically lower than all nodes)
        ///   , middle of the list, in which case, we can either
        ///     Add to existing holdings (if the stock already exists in the list), or
        ///     Insert it at the right location in alphatecial order (if it does not already exist)
        ///   , or end of the list (if alphabetically greater than all existing nodes)
        /// </summary>
        /// <param name="stock">stock that is to be added</param>
        public void AddStock(Stock stock)
        {
            // for an empty list, we add the node at the top of the list
            if (this.IsEmpty())
                AddFirst(stock);
            else
            {
                // if the new node is alphabetically the first, again, we add it at the top of the list
                string nameOfStockToAdd = stock.Name;
                string headNodeData = (this.head.StockHolding).Name;
                if (headNodeData.CompareTo(nameOfStockToAdd) > 0)
                    AddFirst(stock);
                else
                {
                    // traverse the list to locate the stock
                    StockNode current = this.head;
                    StockNode previous = null;
                    string currentStockName = (current.StockHolding).Name;

                    while (current.Next != null && currentStockName.CompareTo(nameOfStockToAdd) < 0)
                    {
                        previous = current;
                        current = current.Next;
                        currentStockName = (current.StockHolding).Name;
                    }

                    // we have now traversed all stocks that are alphabetically less than the stock to be added
                    if (current.Next != null)
                    {
                        // if the stock already exists, add to holdings
                        if (currentStockName.CompareTo(nameOfStockToAdd) == 0)
                        {
                            decimal holdings = (current.StockHolding).Holdings + stock.Holdings;
                            current.StockHolding.Holdings = holdings;
                        }
                        else if (currentStockName.CompareTo(nameOfStockToAdd) > 0)
                        {
                            // insert the stock in the current position. This requires creating a new node,
                            //  pointing the new node to the next node
                            //    and pointing the previous node to the current node
                            //  QUESTION: what would happen if we flipped the sequence of assignments below?
                            StockNode newNode = new StockNode(stock);
                            newNode.Next = current;
                            previous.Next = newNode;
                        }
                    }
                    else
                    {
                        // we are at the end of the list, add the stock at the end
                        //  This is probably not the most efficient way to do it,
                        //  since AddLast traverses the list all over again
                        AddLast(stock);
                    }
                }
            }
        }

        //param  (Stock)stock : stock that is to be checked 
        //summary      : checks if list contains stock passed as parameter
        //                  This involves traversing the list until we find the stock
        //                    return null if we don't
        //return       : Reference of node with matching stock
        //return type  : StockNode if exists, null if not
        public StockNode Contains(Stock stock)
        {
            StockNode nodeReference = null;

            // if the list is empty, return null
            if (this.IsEmpty())
                return nodeReference;
            else
            {
                // traverse the list until we locate the stock,
                //  or, reach the end of the list
                StockNode current = this.head;
                StockNode previous = this.head;
                while (current.Next != null)
                {
                    Stock currentStock = current.StockHolding;

                    // found it! Return the node
                    if (currentStock.Equals(stock))
                    {
                        nodeReference = previous;
                        break;
                    }

                    // else, continue traversing
                    previous = current;
                    current = current.Next;
                }
            }

            return nodeReference;
        }

        /// <summary>
        /// swaps the node passed as argument with next node in list
        /// Sorting the list using the simple bubble sort algorithm requires repeatdely traversing
        ///   the list and pushing a node down the list until it falls in place
        ///     Pushing the node is essentially a swap operation, where we take the next node
        ///       and put it in the current position and move the current node to the next position on the list
        /// </summary>
        /// <param name="nodeOne">first node to be swapped</param>
        /// <returns>Reference to current node</returns>
        public StockNode Swap(Stock nodeOne)
        {
            StockNode prevNodeOne = null;
            StockNode currNodeOne = this.head;

            // traverse the list until we reach the node to swap
            while (currNodeOne != null && currNodeOne.StockHolding != nodeOne)
            {
                prevNodeOne = currNodeOne;
                currNodeOne = currNodeOne.Next;
            }

            // maintain references to the nodes to be swapped
            StockNode prevNodeTwo = currNodeOne;
            StockNode currNodeTwo = currNodeOne.Next;

            // handle corner cases, maybe we have reached the end of the list
            if (currNodeOne == null || currNodeTwo == null)
                return null;

            // perhaps the insertion is at the top of the list
            if (prevNodeOne != null)
                prevNodeOne.Next = currNodeTwo;
            else
                this.head = currNodeTwo;

            if (prevNodeTwo != null)
                prevNodeTwo.Next = currNodeOne;
            else
                this.head = currNodeOne;

            // normal case, swap nodes
            StockNode temp = currNodeOne.Next;
            currNodeOne.Next = currNodeTwo.Next;
            currNodeTwo.Next = temp;

            return currNodeTwo;
        }


        // FOR STUDENTS

        //param        : NA
        //summary      : Sort the list by descending number of holdings
        //return       : NA
        //return type  : NA
        public void SortByValue()
        {
            //Initial StockNode “current” was introduced, signifying the beginning 
            //of the Nodes and thus information to be pulled.
            StockNode current = this.head;

            //An if loop was introduced to serve as a break once the list of 
            //referenced stocks run out, to avoid inducing a null error.
            if (current != null && current.Next != null)
            {

                //Within the if loop is the introduction of the StockNode list 
                //labelled “unsortedList”, which will compile all related stocks 
                //the function is called for into a usable list for what the 
                //function requires.With this introduction includes a while 
                //loop to cycle through subsequent Nodes while the StockNode 
                //does not read null.
               List <StockNode> unsortedList = new List<StockNode>();
                while (current != null)
                {
                    unsortedList.Add(current);
                    current = current.Next;
                }

                //Using LINQ, a new list is formed that sorts the previously 
                //produced list under the criteria of Order By Descending
                //(Greatest to Least), using the Holdings value as a reference 
                //for that criteria. The function then compiles it into a new List.

               List<StockNode> sortedList = unsortedList.OrderByDescending(s => s.StockHolding.Holdings).ToList();


                //A new StockNode is introduced, labelled “current2”. This, along with the 
                //subsequent for loop, adds each value from the new sorted list in order, 
                //to be printed in each subsequent line.
                this.head = sortedList[0];
                StockNode current2 = this.head;
                current2.Next = null;

                for (int i = 1; i < sortedList.Count; i++)
                {
                    current2.Next = sortedList[i];
                    current2 = current2.Next;
                    current2.Next = null;
                }
            }
        }

        //param        : NA
        //summary      : Sort the list alphabatically
        //return       : NA
        //return type  : NA
        public void SortByName()
        {

            //This function is handled in a near identical fashion to SortByValue(). The primary 
            //difference between the two is that instead of the sorted list ordering them from greatest                                                                                   
            //to least by the number of holdings, the use of LINQ instead sorts the stocks in descending 
            //order alphabetically.

            StockNode current = this.head;

            if (current != null && current.Next != null)
            {
                List<StockNode> unsortedList = new List<StockNode>();
                while (current != null)
                {
                    unsortedList.Add(current);
                    current = current.Next;
                }
                List<StockNode> sortedList = unsortedList.OrderBy(s => s.StockHolding.Name).ToList();

                this.head = sortedList[0];

                StockNode current2 = this.head;
                current2.Next = null;


                for (int i = 1; i < sortedList.Count; i++)
                {
                    current2.Next = sortedList[i];
                    current2 = current2.Next;
                    current2.Next = null;
                }
            }
        }
    }
}

