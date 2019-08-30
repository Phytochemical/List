using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ShoppingItem
    {

        private string description;
        private double amount;
        private UnitTypes unit;

        public ShoppingItem(string name, double amount, UnitTypes unit)
        {
            this.description = name;
            this.amount = amount;
            this.unit = unit;
        }

        public ShoppingItem() : this("Unknown", 1.0, UnitTypes.slice)
        {

        }

        public ShoppingItem(string description) : this(description, 1.0, UnitTypes.slice)
        {

        }

        public ShoppingItem (ShoppingItem newItem)
        {
            description = newItem.description;
            amount = newItem.amount;
            unit = newItem.unit;
        }

        public string Description
        {
            get { return description; }
            set
            {
                if ( !string.IsNullOrEmpty(value) )
                {
                    description = value;
                }
            }
        }

        public UnitTypes Unit
        {
            get { return unit; }
            set
            {
                if (Enum.IsDefined(typeof (UnitTypes), value) )

                {
                    unit = value;
                }
            }
        }

        public double Amount
        {
            get { return amount; }
            set
            {
                if (value >=0 )
                {
                    amount = value;
                }
            }
        }

        public override string ToString()
        {
            string textOut = string.Empty;

            textOut = $"{description, -45} {amount, 6:f2} {unit, -6}";

            return textOut;
        }
    }
}
