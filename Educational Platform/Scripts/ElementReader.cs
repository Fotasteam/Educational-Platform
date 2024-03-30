using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Educational_Platform.Scripts
{
    public class NavViewItem
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }
        public bool isIconFontType { get; set; }
    }

    public class NavViewItemsReader
    {
        HttpClient client = new HttpClient();

        public List<NavViewItem> downloadedItems()
        {
            Task<string> downloadList = client.GetStringAsync("");
            string result = downloadList.Result;

            List<NavViewItem> items = new List<NavViewItem>();

            var sr = new StringReader(result);
            string line = null;
            while (true)
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    var item = new NavViewItem();
                    string currentElements = "";
                    int currentPhase = 0;
                    foreach (char character in line)
                        if (character == '|')
                        {
                            switch (currentPhase)
                            {
                                case 0:
                                    item.Name = currentElements;
                                    currentPhase = 1;
                                    break;
                                case 1:
                                    item.Tag = currentElements;
                                    currentPhase = 2;
                                    break;
                                case 2:
                                    item.Icon = currentElements;
                                    currentPhase = 3;
                                    break;
                                case 3:
                                    item.isIconFontType = currentPhase == 1 ? true : false;
                                    break;                                    
                            }
                        }
                        else currentElements += character; 

                    items.Add(item);
                }
                else break;
            }

            return items;
        }
    }
}
