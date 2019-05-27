using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace GetRates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void RatesLoad()  // вариант с десериализацией
        {
    
            List<Item> ratesList = new List<Item>();

            Rates info = new Rates();
            info.Generator = "Genetator_1";
            info.Title = "Title_1";
            info.Date = "Date_1";
            info.Items = new List<Item>();
            info.Items.Add(new Item()
            {
                Fullname = "fullname_111",
                Title = "title_111",
                Change = "change_111"
            });
            info.Items.Add(new Item()
            {
                Fullname = "fullname_222",
                Title = "title_222",
                Change = "change_222"
            });
            info.Items.Add(new Item()
            {
                Fullname = "fullname_331",
                Title = "title_332",
                Change = "change_333"
            });

            // см. http://qaru.site/questions/44548/user-xmlns-was-not-expected-deserializing-twitter-xml
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "rates";
            // xRoot.Namespace = "http://www.cpandl.com";
            xRoot.IsNullable = false;
            XmlSerializer formatter = new XmlSerializer(typeof(Rates), xRoot);

            // пробная сериализация в файл для проверки формируемой структуры XML
            using (FileStream fs = new FileStream("info.xml", FileMode.Create))
            {
                formatter.Serialize(fs, info);
            }

            WebRequest req = WebRequest.Create(@"https://nationalbank.kz/rss/get_rates.cfm?fdate=" + DateTime.Now.ToString("d") + "&switch=russian");

            WebResponse response = req.GetResponse();
            using (Stream s = response.GetResponseStream())  // пишем в поток.
            {
                using (StreamReader r = new StreamReader(s))  // читаем из потока.
                {
                    Rates ratesR = (Rates)formatter.Deserialize(r);
                    ratesList = ratesR.Items;
                }
            }

            response.Close(); // закрываем поток

            ratesDataGrid.ItemsSource = ratesList;

        }

        public void RatesLoad2()  // вариант без десериализации
        {

            string title;
            string description;
            string quant;

            List<Item> ratesList = new List<Item>();

            WebClient webClient = new WebClient();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(webClient.DownloadString("https://nationalbank.kz/rss/get_rates.cfm?fdate=" + DateTime.Now.ToString("d") + "&switch=russian"));
            XmlElement xRoot = xmlDocument.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Name == "item")
                {
                    // обходим все дочерние узлы элемента user
                    title = "";
                    description = "";
                    quant = "";

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "title")
                        {
                            title = childnode.InnerText;
                        }
                        else if (childnode.Name == "description")
                        {
                            description = childnode.InnerText;
                        }
                        else if (childnode.Name == "quant")
                        {
                            quant = childnode.InnerText;
                        }
                    }
                    ratesList.Add(new Item
                    {
                        Quant = quant,
                        Title = title,
                        Description = description,
                    });

                }
            }
            ratesDataGrid.ItemsSource = ratesList;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RatesLoad();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RatesLoad();
        }

    }
}
