using CreditSuisse.App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.App.Utils
{
    public class Utils
    {
        public static void ChangeConsoleColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        public static TradeModel ValidateTrade(string trade)
        {
            try
            {
                var tradeInfo = new TradeModel();
                var trd = trade.Split(' ');
                if (trd.Count() < 3)
                {
                    return null;
                }
                else
                {

                    var valor = double.TryParse(trd[0], out var num);
                    if (!valor)
                        return null;
                    else
                        tradeInfo.Value = num;

                    var dtPay = DateTime.TryParseExact(trd[2], "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out var dtPayment);
                    if (!dtPay)
                        return null;
                    else
                        tradeInfo.NextPaymentDate = dtPayment;

                    tradeInfo.ClientSector = trd[1]?.Trim();

                    return tradeInfo;                    
                }
            }
            catch 
            {
                return null;
            }
        }

        public static bool Again(string answer)
        {
            if (!string.IsNullOrEmpty(answer) && answer.Equals("S"))
                return true;
            else
                return false;
            
        }
    }
}
