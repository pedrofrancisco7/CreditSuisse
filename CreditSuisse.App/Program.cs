using CreditSuisse.App.Categories;
using CreditSuisse.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.App
{
    public class Program
    {
        private static OperationModel _operationModel;
        private static TradeModel _tradeModel;
        static void Main(string[] args)
        {
            _operationModel = new OperationModel();
            StartProgram(_operationModel).Wait();
            Console.ReadKey();
            //RunAsync().Wait();
        }

        static async Task StartProgram(OperationModel operationModel)
        {
            try
            {
                Console.WriteLine("What do you want today?");
                Console.WriteLine("Choose a number:");
                Console.WriteLine("1 - Classify trades");
                Console.WriteLine("2 - Include new Category");

                var pick = Console.ReadLine();

                var num = int.TryParse(pick, out var value);

                switch (value)
                {
                    case 1:
                        await GetTradeInfo(operationModel);
                        break;
                    case 2:
                        Console.WriteLine("To be created!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choose only 1 or 2");
                        await StartProgram(operationModel);
                        break;
                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Choose only numbers");
                await StartProgram(operationModel);
            }
        }        

        static async Task InputCategory(CategoryModel category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44307/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("api/Operations/InsertCategory", content);

                var resultContent = await result.Content.ReadAsStringAsync();

            }
        }

        static async Task<List<string>> GetTradesFromApi(OperationModel operationModel)
        {            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                
                var content = new StringContent(JsonConvert.SerializeObject(operationModel), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("api/Operations/GetTradeInfo", content);

                var resultContent = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<string>>(resultContent);
            }
        }

        #region Private Methods
        private static async Task<OperationModel> GetTradeInfo(OperationModel operationModel)
        {
            try
            {
                ConsoleHeaders("Trade");

                #region Reference Date                

                Utils.Utils.ChangeConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine("Input Reference Date: (Format: MM/dd/yyyy)");
                Utils.Utils.ChangeConsoleColor(ConsoleColor.White);

                if (operationModel.ReferenceDate == DateTime.MinValue)
                {
                    var refDate = DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out var referenceDate);
                    //var refDate = DateTime.TryParse(Console.ReadLine(), out var referenceDate);
                    if (!refDate)
                    {
                        Console.WriteLine("Choose a valid Date!");
                        Console.ReadKey();
                        await GetTradeInfo(operationModel);
                    }
                    else
                    {                        
                        _operationModel.ReferenceDate = referenceDate;
                    }

                }
                else
                {
                    Console.WriteLine(_operationModel.ReferenceDate.ToShortDateString());
                }

                #endregion

                #region Numbers of Trades                
                Utils.Utils.ChangeConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine("Input the numbers of trades:");
                Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
                int num;
                if (_operationModel.NumOfTrades == 0)
                {
                    var tradesNum = int.TryParse(Console.ReadLine(), out num);
                    if (!tradesNum)
                    {
                        await GetTradeInfo(operationModel);
                    }
                    else
                    {
                        _operationModel.NumOfTrades = num;
                    }
                }
                else
                {
                    Console.WriteLine(_operationModel.NumOfTrades);
                }
                #endregion

                #region Trades
                await Trades(operationModel);
                #endregion

                #region Send to API
                await GetCategory(operationModel);
                //await TradesFromApi(operationModel);
                #endregion


            }
            catch (Exception)
            {

                throw;
            }

            return operationModel;
        }

        private static void ConsoleHeaders(string header)
        {
            switch (header)
            {
                case "Trade":
                    Console.Clear();
                    Utils.Utils.ChangeConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("####### Classify Trades #######");
                    Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
                    break;
                default:
                    break;
            }
        }

        private async static Task Trades(OperationModel operation)
        {
            Utils.Utils.ChangeConsoleColor(ConsoleColor.Yellow);
            Console.WriteLine($"Input the trades : (Value Sector NextPaymentDate (MM/dd/yyyy))");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);

            for (int i = 0; i < _operationModel.NumOfTrades; i++)
            {
                var trade = Utils.Utils.ValidateTrade(Console.ReadLine());
                if (trade == null)
                {
                    _operationModel.Trades.Clear();
                    Utils.Utils.ChangeConsoleColor(ConsoleColor.Red);
                    Console.WriteLine($"Input a Valid Trade: (Value Sector NextPaymentDate) press a key to continue...");
                    Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
                    Console.ReadKey();

                    await GetTradeInfo(operation);
                }
                else
                {
                    trade.ReferenceDate = _operationModel.ReferenceDate;
                    _operationModel.Trades.Add(trade);
                }
            }

            Utils.Utils.ChangeConsoleColor(ConsoleColor.Blue);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Waiting... Searching for results");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);

        }

        private async static Task TradesFromApi(OperationModel operation)
        {
            var retorno = await GetTradesFromApi(_operationModel);
            Utils.Utils.ChangeConsoleColor(ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"See the results below!");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);

            foreach (var item in retorno)
            {
                Console.WriteLine(item);
            }

            Utils.Utils.ChangeConsoleColor(ConsoleColor.Magenta);
            Console.WriteLine();
            Console.WriteLine($"Do you want restart? (S/N)");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
            var again = Console.ReadLine();

            if (Utils.Utils.Again(again))
            {
                _operationModel = new OperationModel();
                Console.Clear();
                await StartProgram(_operationModel);

            }
            else
            {
                Utils.Utils.ChangeConsoleColor(ConsoleColor.DarkRed);
                Console.WriteLine();
                Console.WriteLine($"The program has been exited! Press any key to close...");
                Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
                Environment.Exit(0);
            }



        }

        private async static Task GetCategory(OperationModel operation)
        {
            var retorno = new Trades(new Category());
            retorno.GetCategory(operation);            
            Utils.Utils.ChangeConsoleColor(ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"See the results below!");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);

            foreach (var item in retorno._categories)
            {
                Console.WriteLine(item);
            }

            Utils.Utils.ChangeConsoleColor(ConsoleColor.Magenta);
            Console.WriteLine();
            Console.WriteLine($"Do you want restart? (S/N)");
            Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
            var again = Console.ReadLine();

            if (Utils.Utils.Again(again))
            {
                _operationModel = new OperationModel();
                Console.Clear();
                await StartProgram(_operationModel);

            }
            else
            {
                Utils.Utils.ChangeConsoleColor(ConsoleColor.DarkRed);
                Console.WriteLine();
                Console.WriteLine($"The program has been exited! Press any key to close...");
                Utils.Utils.ChangeConsoleColor(ConsoleColor.White);
                Environment.Exit(0);
            }


            

        }
        

        #endregion
    }
}
