using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETaxScanner.Misc
{
    public enum FORM_MODE
    {
        READ,
        ADD,
        EDIT
    }

    public static class Helper
    {
        public static void SetControlState(this Component component, FORM_MODE[] form_mode_to_enable, FORM_MODE current_form_mode)
        {
            if(form_mode_to_enable.Where(m => m == current_form_mode).Count() > 0) // Enable component
            {
                if(component is Button)
                {
                    ((Button)component).Enabled = true;
                }
                if(component is TextBox)
                {
                    ((TextBox)component).Enabled = true;
                }
                if(component is DateTimePicker)
                {
                    ((DateTimePicker)component).Enabled = true;
                }
                if(component is NumericUpDown)
                {
                    ((NumericUpDown)component).Enabled = true;
                }
                if(component is CheckBox)
                {
                    ((CheckBox)component).Enabled = true;
                }
            }
            else // Disable component
            {
                if (component is Button)
                {
                    ((Button)component).Enabled = false;
                }
                if (component is TextBox)
                {
                    ((TextBox)component).Enabled = false;
                }
                if (component is DateTimePicker)
                {
                    ((DateTimePicker)component).Enabled = false;
                }
                if (component is NumericUpDown)
                {
                    ((NumericUpDown)component).Enabled = false;
                }
                if (component is CheckBox)
                {
                    ((CheckBox)component).Enabled = false;
                }
            }
        }
    }
}
