using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.LogicClasses
{
    public class TracksSearch
    {
        #region members
        private WebClient _wc = new WebClient();
        public delegate void PageSourceArrived(string content);
        public event PageSourceArrived PageSourceArrivedEvent;
        #endregion

        #region ctor
        public TracksSearch()
        {

        }
        #endregion

        #region methods
        public async void GetWebPageSourceAsync()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            string content = await client.GetStringAsync("https://itunes.apple.com/search?term=omer+adam&limit=25");
            if (PageSourceArrivedEvent!=null)
            {
                PageSourceArrivedEvent(content);
            }
        }
        #endregion
    }
}
