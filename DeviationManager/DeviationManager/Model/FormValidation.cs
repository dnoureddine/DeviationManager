using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DeviationManager.Model
{
    class FormValidation
    {
        /******* validate the deviation form '=> true-->input valid ## flase--->input not valid */
        public bool isTextBoxNotNull(TextBox textBox, ErrorProvider errorProvider)
        {
            if (textBox.Text == "")
            {
                errorProvider.SetError(textBox, "Text must not be null..!");
                return false;
            }
            else
            {
                return true;
            }
        }

        /******* validate the deviation form '=> true-->Combobox Item selected ## flase--->input not valid */
        public bool isItemFromComoBoxSelected(ComboBox comboBox, ErrorProvider errorProvider)
        {
            if (comboBox.SelectedItem == null)
            {
                errorProvider.SetError(comboBox, "Item must be selected..!");
                return false;
            }
            else
            {
                return true;
            }
        }

        /*** allow input only in letters, this method interact directry with the deviation form *****/
        public bool isOnlyCharecters(TextBox textBox, ErrorProvider errorProvider)
        {
            Regex r = new Regex(@"^[a-zA-Z\s,]*$");
            if (!r.IsMatch(textBox.Text))
            {
                errorProvider.SetError(textBox, "Text must not have Meta charecter..!");
                return false;
            }
            else
            {
                return true;
            }


        }

    }
}
