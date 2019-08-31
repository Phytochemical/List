using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    // container class that manages a list of ShoppingItem type objet
    // adds new item
    // replaces item with new item
    class ItemManager
    {
        private List<ShoppingItem> itemList;

        public ItemManager()
        {
            itemList = new List<ShoppingItem>();
        }

        /// <summary>
        /// checks if the return value is valid
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ShoppingItem GetItem(int index)
        {
            if (!CheckIndex(index))
            {
                return null;
            }
            return itemList[index];
        }

        public int Count
        {
            get { return itemList.Count; }
        }

        public bool AddItem(ShoppingItem itemIn)
        {
            bool isIteamValid = false;

            if (itemIn != null)
            {
                itemList.Add(itemIn);
                isIteamValid = true;
            }
            return isIteamValid;
        }

        /// <summary>
        /// replace existing object with a new object
        /// </summary>
        /// <param name="itemIn"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeItem(ShoppingItem itemIn, int index)
        {
            bool isItemValid = false;

            if (CheckIndex(index))
            {
                isItemValid = true;
                itemList[index] = itemIn;
            }
            return isItemValid;
        }

        public bool DeleteItem(int index)
        {
            bool isItemValid = false;

            if (CheckIndex(index) )
            {
                itemList.RemoveAt(index);
                Console.Out.WriteLine(index);
                isItemValid = true;
            }
            return isItemValid;
        }

        /// <summary>
        /// 
        /// calls each item ToString();
        /// </summary>
        /// <returns></returns>
        public string[] GetItemInfoStrings()
        {
            string[] stringInfoStrings = new string[itemList.Count];

            int index = 0;
            foreach (ShoppingItem Item in itemList)
            {
                stringInfoStrings[index] = Item.ToString();
                index++;
            }
            return stringInfoStrings;
        }

        /// <summary>
        /// checks index out of range
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < itemList.Count);
        }

    }
}
