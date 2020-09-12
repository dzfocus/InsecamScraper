using Edokan.KaiZen.Colors;
using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Insecam
{
    class Program
    {
        [Obsolete]
        
        static void Main(string[] args)
        {



            Console.Title = "InsecamScraper";
            string title = @"                                                                                                          
     _________                                        ____
    / / |_   _|                                      / / /
   / / /  | |  _ __  ___  ___  ___ __ _ _ __ ___    / / / 
  / / /   | | | '_ \/ __|/ _ \/ __/ _` | '_ ` _ \  / / /  
 / / /   _| |_| | | \__ |  __| (_| (_| | | | | | |/ / /   
/_/_/   |_____|_| |_|___/\___|\___\__,_|_| |_| |_/_/_/             
                                IP cameras(_  _.__.._  _ ._
                                           _)(_|(_||_)(/_| 
                                                   |By DZFOCUS      
                                                                        
          ";

            Console.WriteLine(title);
            
       
            EscapeSequencer.Install();
            EscapeSequencer.Bold = true; //set default bold to On. Actually this will use bright colors. Easier to read

            var spinner = new ConsoleSpinner();

            spinner.Start();

            Thread.Sleep(1000);

            spinner.Stop();
           
            Console.WriteLine( "Hello".Red() + ", " + "SALAM".Blue() + Environment.NewLine  );
            Console.WriteLine("INFO:".Yellow() + "This project scrapes IP addresses from https://www.insecam.org ".Bold());
        SwitchStatement:
            Console.WriteLine();
            Console.WriteLine("Search by ====>:".Green() + "         " + "[1]".Red() + " Country" + "       " + "[2]".Red() + "Type" + "       " + "[0]".Red() + "Exit");
            
            string search = Console.ReadLine();
            int num;
           
            if (string.IsNullOrEmpty(search))
            {
                Console.WriteLine("[!]".Red() + "Search can't be empty! Input Number once more".Yellow());
                Console.WriteLine();
                goto SwitchStatement;
            }
            else if (!int.TryParse(search, out num))
            {
                Console.WriteLine("[!]".Red() + "This is not a number!".Yellow());
                Console.WriteLine();
                goto SwitchStatement;
            }
            else if (int.Parse(search) > 2)
            {
                Console.WriteLine("[!]".Red() + "Enter a valid number!".Yellow());
                Console.WriteLine();
                goto SwitchStatement;
            }

            if (search == "1")
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("N      |Countries               | N     |Countries               |N     |Countries              |");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  1]".Red(), "United States", "[ 31]".Red(), "Mexico", "[ 61]".Red(), "Moldova"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  2]".Red(), "Japan", "[ 32]".Red(), "Finland", "[ 62]".Red(), "Nicaragua"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  3]".Red(), "Italy ", "[ 33]".Red(), "China", "[ 63]".Red(), "Malta"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  4]".Red(), "Korea ", "[ 34]".Red(), "Chile", "[ 64]".Red(), "Trinidad And Tobago"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  5]".Red(), "France ", "[ 35]".Red(), "South Africa", "[ 65]".Red(), "Soudi Arabia"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  6]".Red(), "Germany ", "[ 36]".Red(), "Slovakia", "[ 66]".Red(), "Croatia"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  7]".Red(), "Taiwan   ", "[ 37]".Red(), "Hungary", "[ 67]".Red(), "Cyprus"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  8]".Red(), "Russian Federation  ", "[ 38]".Red(), "Ireland", "[ 68]".Red(), "Pakistan"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  9]".Red(), "United Kingdom    ", "[ 39]".Red(), "Egypt", "[ 69]".Red(), "United Arab Emirates"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 10]".Red(), "Netherlands     ", "[ 40]".Red(), "Thailand", "[ 70]".Red(), "Kazakhstan"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 11]".Red(), "Czech Republic   ", "[ 41]".Red(), "Ukraine", "[ 71]".Red(), "Kuwait"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 12]".Red(), "Turkey     ", "[ 42]".Red(), "Serbia", "[ 72]".Red(), "Venezuela"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 13]".Red(), "Austria    ", "[ 43]".Red(), "Hong Kong", "[ 73]".Red(), "Georgia"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 14]".Red(), "Switzerland ", "[ 44]".Red(), "Greece", "[ 74]".Red(), "Montenegro"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 15]".Red(), "Spain  ", "[ 45]".Red(), "Portugal", "[ 75]".Red(), "El Salvador"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 16]".Red(), "Canada ", "[ 46]".Red(), "Latvia", "[ 76]".Red(), "Luxembourg"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 17]".Red(), "Sweden ", "[ 47]".Red(), "Singapore", "[ 77]".Red(), "Curacao"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 18]".Red(), "Israel", "[ 48]".Red(), "Iceland", "[ 78]".Red(), "Puerto Rico"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 19]".Red(), "Iran ", "[ 49]".Red(), "Malaysia", "[ 79]".Red(), "Costa Rica"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 20]".Red(), "Poland", "[ 50]".Red(), "Colombia", "[ 80]".Red(), "Belarus"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 21]".Red(), "India ", "[ 51]".Red(), "Tunisia", "[ 81]".Red(), "Albania"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 22]".Red(), "Norway", "[ 52]".Red(), "Estonia", "[ 82]".Red(), "Liechtenstein"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 23]".Red(), "Romania", "[ 53]".Red(), "Dominican Republic", "[ 83]".Red(), "Bosnia And Herzegovia"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 24]".Red(), "Viet Nam", "[ 54]".Red(), "Sloveania", "[ 84]".Red(), "Paraguay"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 25]".Red(), "Belgium", "[ 55]".Red(), "Ecuador", "[ 85]".Red(), "Philippines"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 26]".Red(), "Brazil", "[ 56]".Red(), "Lithuania", "[ 86]".Red(), "Faroe Islands"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 27]".Red(), "Bulgaria", "[ 57]".Red(), "Palestinian", "[ 87]".Red(), "Guatemala"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 28]".Red(), "Indonesia", "[ 58]".Red(), "New Zealand", "[ 88]".Red(), "Nepal"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 29]".Red(), "Denmark", "[ 59]".Red(), "Bangladeh", "[ 89]".Red(), "Peru"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[ 30]".Red(), "Argentina", "[ 60]".Red(), "Panama", "[ 90]".Red(), "Uruguay"));
                Console.WriteLine("-------------------------------------------------------------------------------------------------");


            SwitchStatement2:
                Console.WriteLine("Choose Country:".Green() + "     " + "[0]".Red() + "BACK" + "     " + "[ESC]".Red() + "Abort");


                int num2;
                string country = Console.ReadLine();
                if (string.IsNullOrEmpty(country))
                {
                    Console.WriteLine("[!]".Red()+"Country can't be empty! Input Number once more".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement2;
                }else if (!int.TryParse(country, out num2))
                {
                    Console.WriteLine("[!]".Red() +"This is not a number!".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement2;
                }else if (int.Parse(country) > 90)
                {
                    Console.WriteLine("[!]".Red()+"Enter a valid number!".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement2;
                }

                
                string count = "";

                switch (country)
                {
                    
                    case "0":
                        Console.Clear();
                        goto SwitchStatement;
                    //break;
                    case "1":
                        count = "US";
                        break;
                    case "2":
                        count = "JP";
                        break;
                    case "3":
                        count = "IT";
                        break;
                    case "4":
                        count = "KR";
                        break;
                    case "5":
                        count = "FR";
                        break;
                    case "6":
                        count = "DE";
                        break;
                    case "7":
                        count = "TW";
                        break;
                    case "8":
                        count = "RU";
                        break;
                    case "9":
                        count = "GB";
                        break;
                    case "10":
                        count = "NL";
                        break;
                    case "11":
                        count = "CZ";
                        break;
                    case "12":
                        count = "TR";
                        break;
                    case "13":
                        count = "AU";
                        break;
                    case "14":
                        count = "CH";
                        break;
                    case "15":
                        count = "ES";
                        break;
                    case "16":
                        count = "CA";
                        break;
                    case "17":
                        count = "SE";
                        break;
                    case "18":
                        count = "IL";
                        break;
                    case "19":
                        count = "IR";
                        break;
                    case "20":
                        count = "PL";
                        break;
                    case "21":
                        count = "IN";
                        break;
                    case "22":
                        count = "JP";
                        break;
                    case "23":
                        count = "RO";
                        break;
                    case "24":
                        count = "VN";
                        break;
                    case "25":
                        count = "BE";
                        break;
                    case "26":
                        count = "BR";
                        break;
                    case "27":
                        count = "BG";
                        break;
                    case "28":
                        count = "ID";
                        break;
                    case "29":
                        count = "DK";
                        break;
                    case "30":
                        count = "AR";
                        break;
                    case "31":
                        count = "MX";
                        break;
                    case "32":
                        count = "FI";
                        break;
                    case "33":
                        count = "CN";
                        break;
                    case "34":
                        count = "CL";
                        break;
                    case "35":
                        count = "ZA";
                        break;
                    case "36":
                        count = "SK";
                        break;
                    case "37":
                        count = "HU";
                        break;
                    case "38":
                        count = "IE";
                        break;
                    case "39":
                        count = "EG";
                        break;
                    case "40":
                        count = "TH";
                        break;
                    case "41":
                        count = "UA";
                        break;
                    case "42":
                        count = "RS";
                        break;
                    case "43":
                        count = "HK";
                        break;
                    case "44":
                        count = "GR";
                        break;
                    case "45":
                        count = "PT";
                        break;
                    case "46":
                        count = "LV";
                        break;
                    case "47":
                        count = "SG";
                        break;
                    case "48":
                        count = "IS";
                        break;
                    case "49":
                        count = "MY";
                        break;
                    case "50":
                        count = "CO";
                        break;
                    case "51":
                        count = "TN";
                        break;
                    case "52":
                        count = "EE";
                        break;
                    case "53":
                        count = "DO";
                        break;
                    case "54":
                        count = "SI";
                        break;
                    case "55":
                        count = "EC";
                        break;
                    case "56":
                        count = "LT";
                        break;
                    case "57":
                        count = "PS";
                        break;
                    case "58":
                        count = "NZ";
                        break;
                    case "59":
                        count = "BD";
                        break;
                    case "60":
                        count = "PA";
                        break;
                    case "61":
                        count = "MD";
                        break;
                    case "62":
                        count = "NI";
                        break;
                    case "63":
                        count = "MT";
                        break;
                    case "64":
                        count = "TT";
                        break;
                    case "65":
                        count = "SA";
                        break;
                    case "66":
                        count = "HR";
                        break;
                    case "67":
                        count = "CY";
                        break;
                    case "68":
                        count = "PK";
                        break;
                    case "69":
                        count = "AE";
                        break;
                    case "70":
                        count = "KZ";
                        break;
                    case "71":
                        count = "KW";
                        break;
                    case "72":
                        count = "VE";
                        break;
                    case "73":
                        count = "GE";
                        break;
                    case "74":
                        count = "ME";
                        break;
                    case "75":
                        count = "SV";
                        break;
                    case "76":
                        count = "LU";
                        break;
                    case "77":
                        count = "CW";
                        break;
                    case "78":
                        count = "PR";
                        break;
                    case "79":
                        count = "CR";
                        break;
                    case "80":
                        count = "BY";
                        break;
                    case "81":
                        count = "AL";
                        break;
                    case "82":
                        count = "LI";
                        break;
                    case "83":
                        count = "BA";
                        break;
                    case "84":
                        count = "PY";
                        break;
                    case "85":
                        count = "PH";
                        break;
                    case "86":
                        count = "FO";
                        break;
                    case "87":
                        count = "GT";
                        break;
                    case "88":
                        count = "NP";
                        break;
                    case "89":
                        count = "PE";
                        break;
                    case "90":
                        count = "UY";
                        break;

                }


                Thread t = new Thread(() =>
                {
                    var spinner2 = new ConsoleSpinner();

                    spinner2.Start();

                    Thread.Sleep(1000);

                    //////Get Numbre of page
                    string url = ("https://www.insecam.org/en/bycountry/" + count);
                    string pages = "";
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlWeb web = new HtmlWeb();
                    doc = web.Load(url);

                    HtmlNodeCollection nodes1 = doc.DocumentNode.SelectNodes("//nav[@class='navigation']");
                    if (nodes1 != null)
                    {
                        foreach (var item in nodes1)
                        {
                            pages += item.InnerText.Between("pagenavigator(\"?page=\",", ", 1);").Replace(" ", "") + System.Environment.NewLine;

                        }
                    }

                    string Npages = (pages).Split('\n')[0];
                    int count2 = Int32.Parse(Npages)*6;
                    
                    Console.WriteLine("Country:".Green() + " " + count.Yellow() + "   " + "Devices:".Green() + " " + count2.ToString().Yellow());
                   
                    spinner2.Stop();

                    ////scraping page Get ip:port
                    for (int i = 0; i < Int32.Parse(Npages); i++)
                    {
                        string url1 = ("https://www.insecam.org/en/bycountry/" + count + "/?page=" + i);

                        HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
                        HtmlWeb web1 = new HtmlWeb();
                        doc = web.Load(url1);

                        string result1 = "";
                        
                        HtmlNodeCollection nodes2 = doc.DocumentNode.SelectNodes("//img[@class='thumbnail-item__img img-responsive']");
                        if (nodes2 != null)
                        {
                            foreach (var item in nodes2)
                            {
                               
                                result1 = item.GetAttributeValue("src", null) + System.Environment.NewLine; ;

                                string ip = (result1.Between("http://", ":"));
                               
                                Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                                     RegexOptions.None, TimeSpan.FromMilliseconds(150));
                                Match m = r.Match(result1);
                                if (m.Success)
                                  
                                Console.WriteLine("http://" + ip + (m.Result("${port}")));
                              
                            }

                            
                        }
                       

                    }

                    Console.WriteLine();
                    Console.WriteLine("Search Completed:".Green()+" Press Enter to Continue......".Yellow());


                });
                t.Start();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    t.Suspend();
                    goto SwitchStatement;

                }

                   goto SwitchStatement;

            }

            else if (search == "2")
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("N      |Manufacturers           | N     |Manufacturers           |N     |Manufacturers          |");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  1]".Red(), "Android-Ipwebcam", "[ 10]".Red(), "Dlink-Dcs-932", "[ 19]".Red(), "Streamer"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  2]".Red(), "Axis", "[ 11]".Red(), "Foscam", "[ 20]".Red(), "Toshiba"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  3]".Red(), "Axis2 ", "[ 12]".Red(), "Hi3516", "[ 21]".Red(), "Tplink"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  4]".Red(), "Blueiris ", "[ 13]".Red(), "Linksys", "[ 22]".Red(), "Vivotek"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  5]".Red(), "Bosch ", "[ 14]".Red(), "Megapixel", "[ 23]".Red(), "Webcamxp"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  6]".Red(), "Canon ", "[ 12]".Red(), "Mobotix", "[ 24]".Red(), "Wificam"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  7]".Red(), "Channelvision   ", "[ 16]".Red(), "Panasonic", "[ 25]".Red(), "Wym"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  8]".Red(), "Defeway ", "[ 17]".Red(), "Panasonichd", "[ 26]".Red(), "Yawcam"));
                Console.WriteLine(String.Format("{0,-2}  | {1,-22} | {2,-3} | {3,-22} | {4,-6}| {5,-22}|", "[  9]".Red(), "Dlink ", "[ 18]".Red(), "Sony", "[ 27]".Red(), "Sony-Cs3"));
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                SwitchStatement3:
                Console.WriteLine("Choose Manufacturers: ".Green() + "     " + "[0]".Red() + "BACK" + "     " + "[ESC]".Red() + "Abort");

                string Type = Console.ReadLine();
                int num3;
                if (string.IsNullOrEmpty(Type))
                {
                    Console.WriteLine("[!]".Red() + "Type can't be empty! Input Number once more".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement3;
                }
                else if (!int.TryParse(Type, out num3))
                {
                    Console.WriteLine("[!]".Red() + "This is not a number!".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement3;
                }
                else if (int.Parse(Type) > 90)
                {
                    Console.WriteLine("[!]".Red() + "Enter a valid number!".Yellow());
                    Console.WriteLine();
                    goto SwitchStatement3;
                }



                string count = "";

                switch (Type)
                {
                    case "0":
                        Console.Clear();
                        goto SwitchStatement;
                    //break;
                    case "1":
                        count = "Android-Ipwebcam";
                        break;
                    case "2":
                        count = "Axis";
                        break;
                    case "3":
                        count = "Axis2";
                        break;
                    case "4":
                        count = "Blueiris";
                        break;
                    case "5":
                        count = "Bosch";
                        break;
                    case "6":
                        count = "Canon";
                        break;
                    case "7":
                        count = "Channelvision";
                        break;
                    case "8":
                        count = "Defeway";
                        break;
                    case "9":
                        count = "Dlink";
                        break;
                    case "10":
                        count = "Dlink-Dcs-932";
                        break;
                    case "11":
                        count = "Foscam";
                        break;
                    case "12":
                        count = "Hi3516";
                        break;
                    case "13":
                        count = "Linksys";
                        break;
                    case "14":
                        count = "Megapixel";
                        break;
                    case "15":
                        count = "Mobotix";
                        break;
                    case "16":
                        count = "Panasonic";
                        break;
                    case "17":
                        count = "Panasonichd";
                        break;
                    case "18":
                        count = "Sony";
                        break;
                    case "19":
                        count = "Streamer";
                        break;
                    case "20":
                        count = "Toshiba";
                        break;
                    case "21":
                        count = "Tplink";
                        break;
                    case "22":
                        count = "Vivotek";
                        break;
                    case "23":
                        count = "Webcamxp";
                        break;
                    case "24":
                        count = "Wificam";
                        break;
                    case "25":
                        count = "Wym";
                        break;
                    case "26":
                        count = "Yawcam";
                        break;
                    case "27":
                        count = "Sony-Cs3";
                        break;
                   
                }


                Thread t = new Thread(() =>
                {
                    var spinner2 = new ConsoleSpinner();

                    spinner2.Start();

                    Thread.Sleep(1000);

                    //////Get Numbre of page
                    string url = ("https://www.insecam.org/en/bytype/" + count);
                    string pages = "";
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlWeb web = new HtmlWeb();
                    doc = web.Load(url);

                    HtmlNodeCollection nodes1 = doc.DocumentNode.SelectNodes("//nav[@class='navigation']");
                    if (nodes1 != null)
                    {
                        foreach (var item in nodes1)
                        {
                            pages += item.InnerText.Between("pagenavigator(\"?page=\",", ", 1);").Replace(" ", "") + System.Environment.NewLine;

                        }
                    }
                    


                    string Npages = (pages).Split('\n')[0];
                    int count2 = Int32.Parse(Npages) * 6;

                    Console.WriteLine("Country:".Green() + " " + count.Yellow() + "   " + "Devices:".Green() + " " + count2.ToString().Yellow());

                    spinner2.Stop();

                    ////scraping page Get ip:port
                    for (int i = 0; i < Int32.Parse(Npages); i++)
                    {
                        string url1 = ("https://www.insecam.org/en/bytype/" + count + "/?page=" + i);

                        HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
                        HtmlWeb web1 = new HtmlWeb();
                        doc = web.Load(url1);

                        string result1 = "";

                        HtmlNodeCollection nodes2 = doc.DocumentNode.SelectNodes("//img[@class='thumbnail-item__img img-responsive']");
                        if (nodes2 != null)
                        {
                            foreach (var item in nodes2)
                            {

                                result1 = item.GetAttributeValue("src", null) + System.Environment.NewLine; ;

                                string ip = (result1.Between("http://", ":"));

                                Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                                     RegexOptions.None, TimeSpan.FromMilliseconds(150));
                                Match m = r.Match(result1);
                                if (m.Success)

                                    Console.WriteLine("http://" + ip + (m.Result("${port}")));

                            }


                        }


                    }

                    Console.WriteLine();
                    Console.WriteLine("Search Completed:".Green()+" Press Enter to Continue".Yellow());


                });
                t.Start();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    t.Suspend();
                    goto SwitchStatement;

                }

                goto SwitchStatement;
            }

            else if (search == "0")
            {

                Environment.Exit(0);

            }

           




            Console.ReadKey();




        }
       
    }
}
