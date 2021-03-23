using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema1_WPF
{
    public class Category
    {
        public string Title { get; set; }
        public List<Word> Words { get; set; }

        public Category()
        {
            this.Title = String.Empty;
            this.Words = new List<Word>();
        }

        public Category(string title)
        {
            this.Title = title;
            this.Words = new List<Word>();
        }
    }
}
