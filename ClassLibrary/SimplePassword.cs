using System;
namespace ClassLibrary
{
    public class SimplePassword
    {
        public SimplePassword(string password)
        {
            bool success = true;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^.{8,30}$");
            if (!regex.IsMatch(password))
            {
                success = false;
            }

            regex = new System.Text.RegularExpressions.Regex("^(?=.*\\d).*$");
            if (!regex.IsMatch(password))
            {
                success = false;
            }

            regex = new System.Text.RegularExpressions.Regex("^(?=.*[A-Z]).*$");
            if (!regex.IsMatch(password))
            {
                success = false;
            }

            regex = new System.Text.RegularExpressions.Regex("^(?i)((?!password).)*$");
            if (!regex.IsMatch(password))
            {
                success = false;
            }

            regex = new System.Text.RegularExpressions.Regex("^(?=.*[.,\\/#!$%\\^&\\*;:{}=\\-_`~()”“\"…]).*$");
            if (!regex.IsMatch(password))
            {
                success = false;
            }

            Console.WriteLine(success+"\n");
        }
    }
}