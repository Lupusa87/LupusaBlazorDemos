using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLib3
{
    public static class MyFunctions
    {
        public static void Display_Message(string Par_Message, MethodBase Par_Method, bool Par_IsError = true, bool Par_Show_Details = true)
        {
            string tmp_message = string.Empty;

            if (Par_Show_Details)
            {
                tmp_message = Par_Message + "\n\nMethod - " + Par_Method.Name + "\nModule - " + Par_Method.DeclaringType.FullName;
            }
            else
            {
                tmp_message = Par_Message;
            }

            //if (Par_IsError)
            //{
            //    MessageBox.Show(tmp_message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    MessageBox.Show(tmp_message, "Message", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //}


            throw new Exception(tmp_message);
        }
    }
}
