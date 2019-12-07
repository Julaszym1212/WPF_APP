﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kod
{
    public partial class Szyfrowanie : Page
    {
        public Szyfrowanie(string text)
        {
            // To bytes
            text1 = text;
            InitializeComponent();
            MessageBox.Show(text1, "Podany tekst to: ");
            char sign;
            int i = 0;
            bool[] charByte;
            List<bool> BytesText = new List<bool>();
            while (i < text1.Length)
            {
                sign = text1[i];
                charByte = CharsToBytes(sign);
                for (int k = 0; k < 8; k++)
                {
                    BytesText.Add(charByte[k]);
                }
                i++;
            }
            string help = "";
            for (int u = 0; u < text1.Length*8; u++)
            {
                help += Convert.ToString(Convert.ToInt32(BytesText[u]));
                if ((u + 1) % 8 == 0) help += "        ";
            }
            MessageBox.Show(help);
            // Generate key
            List<bool> keyBytes = new List<bool>();
            MyType a = new MyType(1);
            MyType b = new MyType(2);
            a = b;
            


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(text1);
        }


        public int j = 7;


        public bool[] CharsToBytes(char chars)
        {
            bool[] bytes = new bool[8];
            j = 7;
            do
            {
                bytes[j] = Convert.ToBoolean((int)chars % 2);
                chars = (char)((int)chars / 2);
                j--;
            } while (j >= 0);
            return bytes;
        }


        public char BytesToChars(bool[] bytes)
        {
            char chars = (char)0;
            int ch = 0;
            for (j = 7; j >= 0; j--)
            {
                ch += Convert.ToInt32(Convert.ToInt64(bytes[j]) * (int)(Math.Pow(2, 7 - j)));
            }
            chars = (char)ch;
            return chars;
        }
        private string text1;

        
    }
}
