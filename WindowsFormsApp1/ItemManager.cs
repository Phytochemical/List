using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ItemManager
    {
        private List<ShoppingItem> itemList;

        public ItemManager()
        {
            itemList = new List<ShoppingItem>();
        }

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

        public bool ChangeItem(ShoppingItem itemIn, int index)
        {
            bool isItemValid = false;

            if (CheckIndex(index))
            {
                isItemValid = true;
                itemList[index] = itemIn;
                itemList.Insert(index, itemIn);
            }
            return isItemValid;
        }

        public bool DeleteItem(int index)
        {
            bool isItemValid = false;

            if (CheckIndex(index))
            {
                itemList.RemoveAt(index);
                isItemValid = true;
            }
            return isItemValid;
        }

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

        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < itemList.Count);
        }

    }
}
