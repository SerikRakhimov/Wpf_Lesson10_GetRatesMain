using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GetRates
{
    [Serializable]
    public class Rates
    {
        [XmlElement("generator")]
        public string Generator { set; get; }
        [XmlElement("title")]
        public string Title { set; get; }
        [XmlElement("link")]
        public string Link { set; get; }
        [XmlElement("description")]
        public string Description { set; get; }
        [XmlElement("copyright")]
        public string Copyright { set; get; }
        [XmlElement("date")]
        public string Date { set; get; }
        [XmlElement("item")]  // для правильного считывания списка item нужно именно так указать;
                              // см. https://stackoverrun.com/ru/q/741667 
                              ///// <remarks/> 
                              //[XmlElement("credentials")]
                              //public List<CredentialsSection> credentials { get; set; };
        public List<Item> Items { set; get; }
    }

    [Serializable]
    public class Item
    {
        [XmlElement("fullname")]
        public string Fullname { set; get; }
        [XmlElement("title")]
        public string Title { set; get; }
        [XmlElement("description")]
        public string Description { set; get; }
        [XmlElement("quant")]
        public string Quant { set; get; }
        [XmlElement("index")]
        public string Index { set; get; }
        [XmlElement("change")]
        public string Change { set; get; }

    }
}
