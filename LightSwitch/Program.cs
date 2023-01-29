using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace LightSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyName = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";
            int currentValue = 0;
            int newValue;

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            //Debug.Indent();


            Debug.WriteLine("Debug: getting AppsUseLightTheme value");
            currentValue = (int) Registry.GetValue(keyName, "AppsUseLightTheme", currentValue);
            Debug.WriteLine($"Debug: {currentValue}");

            if(currentValue == 0 )
            {
                newValue = 1;
                Debug.WriteLine("Debug: changing value to 1");
            }
            else
            {
                newValue = 0;
                Debug.WriteLine("Debug: changing value to 0");
            }

            Debug.WriteLine($"Debug: changing AppsUseLightTheme to {newValue}");

            Registry.SetValue(keyName, "AppsUseLightTheme", newValue);

            return;
        }
    }
}
