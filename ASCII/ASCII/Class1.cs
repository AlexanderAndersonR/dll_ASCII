using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public class ASCII
    {
        public static string ASCII_in_6bit_char(string coded_number)
        {
            ///<summary>
            ///входное значение string coded_number, выходное значение decoding_number
            ///</summary>
            string decoding_number = "";
            byte[] ASCIIBytes = Encoding.ASCII.GetBytes(coded_number);
            foreach (var item in ASCIIBytes)
            {
                if (item <= 87 && item >= 48)
                {
                    decoding_number = String.Format("{0:d6}", Convert.ToInt32(Convert.ToString((item - 48), 2)));
                }
                else if (item <= 119 && item >= 96)
                {
                    decoding_number = String.Format("{0:d6}", Convert.ToInt32(Convert.ToString((item - 56), 2)));
                }
            }
            return decoding_number;
        }
        public static string _6bit_in_ASCII_char(string coded_number)
        {
            ///<summary>
            ///входное значение string coded_number, выходное значение decoding_number
            ///</summary>
            string decoding_number = "";
            int counter = 0;
            var result = 0u;
            for (var i = coded_number.Length - 1; i >= 0; i--)
            {
                if (coded_number[i] == '1')
                {
                    result += Convert.ToUInt32(Math.Pow(2, counter));
                }
                counter++;
            }
            if (result <= 39 && result >= 0)
            {
                result += 48;
            }
            else if (result <= 63 && result >= 40)
            {
                result += 56;
            }
            byte[] ASCIIBytes = new byte[] { Convert.ToByte(result) };
            decoding_number = Encoding.ASCII.GetString(ASCIIBytes);
            return decoding_number;
        }
        public static string _6bit_in_ASCII_string(string coded_number)
        {
            ///<summary>
            ///входное значение string coded_number, выходное значение decoding_number
            ///</summary>
            string decoding_number = "";
            double num = 0.0;
            string symbol_6 = coded_number;
            if (double.TryParse(coded_number, out num))
            {
                if (coded_number.Length % 6 == 0)
                {
                    string a = coded_number;
                    for (int i = 0; i < coded_number.Length; i += 6)
                    {
                        try
                        {
                            int cointer = (((a.Length / 6) - 1) * 6) > 0 ? (((a.Length / 6) - 1) * 6) : 6;
                            decoding_number += _6bit_in_ASCII_char(a.Substring(0, cointer));
                            a = a.Remove(0, cointer);
                        }
                        catch (Exception)
                        {
                            decoding_number = "ERROR";
                        }
                    }
                }
                else
                {
                    while (symbol_6.Length % 6 != 0)
                    {
                        symbol_6 += "0";
                    }
                    string a = symbol_6;
                    for (int i = 0; i < symbol_6.Length; i += 6)
                    {
                        try
                        {
                            int cointer = (((a.Length / 6) - 1) * 6) > 0 ? (((a.Length / 6) - 1) * 6) : 6;
                            decoding_number += _6bit_in_ASCII_char(a.Substring(0, cointer));
                            a = a.Remove(0, cointer);
                        }
                        catch (Exception)
                        {
                            decoding_number = "ERROR";
                        }
                    }
                }

            }
            else
            {
                decoding_number = "Only numbers, please!";
            }
            return decoding_number;
        }
        public static string ASCII_in_6bit_string(string coded_number)
        {
            ///<summary>
            ///входное значение string coded_number, выходное значение decoding_number
            ///</summary>
            string decoding_number = "";
            char[] charArray = coded_number.ToCharArray();
                foreach (var item in charArray)
                {
                decoding_number += ASCII_in_6bit_char(Convert.ToString(item));
                }
            return decoding_number;
        }
    }
}
