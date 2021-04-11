using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema1_WPF
{
    public class IndexPair
    {
        public int CategoryIndex { get; set; }
        public int WordIndex { get; set; }
        public bool Active { get; set; }

        public IndexPair() { }

        public IndexPair(int categoryIndex, int wordIndex)
        {
            set(categoryIndex, wordIndex, true);
        }

        public void set(int categoryIndex, int wordIndex, bool active = true)
        {
            CategoryIndex = categoryIndex;
            WordIndex = wordIndex;
            Active = active;
        }
    }
}
