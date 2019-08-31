using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    // uses ItemManager and ShoppingItem object
    public partial class MainForm : Form
    {
        ItemManager itemManager = new ItemManager();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            comboBox.Items.AddRange( Enum.GetNames (typeof(UnitTypes) ) );
            comboBox.SelectedIndex = (int)UnitTypes.slice;
        }

        private void UpdateGUI()
        {
            listItems.Items.Clear();

            string[] itemString = itemManager.GetItemInfoStrings();

            if (itemString != null)
            {
                listItems.Items.AddRange(itemString);
            }
        }

        private ShoppingItem ReadInput(out bool isInputValid)
        {
            isInputValid = false;

            ShoppingItem item = new ShoppingItem();

            item.Description = ReadDescription(out isInputValid);

            if (!isInputValid)
            {
                return null;
            }
            item.Amount = ReadAmount(out isInputValid);
            if (!isInputValid)
            {
                return null;
            }

            item.Unit = ReadUnit(out isInputValid);

            return item;
        }

        private double ReadAmount(out bool isAmountValid)
        {
            double amount = 0.0;
            isAmountValid = false;

            if ( !double.TryParse(textAmount.Text, out amount) )
            {
                GiveMessage("Wrong amount!");

                textAmount.Focus();
                textAmount.SelectionStart = 0;
                textAmount.SelectionLength = textAmount.TextLength;
            }
            else
            {
                isAmountValid = true;
            }

            return amount;
        }

        private UnitTypes ReadUnit(out bool isUnitValid)
        {
            isUnitValid = false;
            UnitTypes unit = UnitTypes.lb;

            if (comboBox.SelectedIndex >= 0)
            {
                isUnitValid = true;
                unit = (UnitTypes)comboBox.SelectedIndex;
            }
            else
            {
                GiveMessage("Wrong unit!");
            }
            return unit;
        }

        private void GiveMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string ReadDescription(out bool isDescriptionValid)
        {
            isDescriptionValid = false;

            string text = textName.Text.Trim();

            if (!string.IsNullOrEmpty (text) )
            {
                isDescriptionValid = true;
            }
            else
            {
                GiveMessage("Provide a description");
            }
            return text;
        }

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listItems.SelectedIndex < 0)
            {
                
            }
            ShoppingItem item = itemManager.GetItem(listItems.SelectedIndex);
            textAmount.Text = item.Amount.ToString();
            textName.Text = item.Description;
            comboBox.SelectedIndex = (int)item.Unit;
        }

        /// <summary>
        /// read user user input and prints it on an empty list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool isInputValid = false;

            ShoppingItem item = ReadInput(out isInputValid);

            if (isInputValid)
            {
                itemManager.AddItem(item);
                UpdateGUI();
            }
        }

        /// <summary>
        /// read user input and replaces the old data with the new input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChange_Click(object sender, EventArgs e)
        {
            bool isInputValid = false;

            ShoppingItem myShoppingitem = ReadInput(out isInputValid);

            if (isInputValid)
            {
                itemManager.ChangeItem(myShoppingitem, listItems.SelectedIndex);
                UpdateGUI();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bool isInputValid = false;

            ShoppingItem myShoppingItem = ReadInput(out isInputValid);

            if (isInputValid)
            {
                itemManager.DeleteItem(listItems.SelectedIndex);
                UpdateGUI();
            }
        }

        private void Shopping_List_Load(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

    }
}