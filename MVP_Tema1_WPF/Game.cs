using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema1_WPF
{
    class Game
    {
        private List<Category> dictionary;
        private int size;
        public int Size { get { return size; } }
        public List<IndexPair> IndexList { get; }

        Game(List<Category> dictionary, int size)
        {
            this.dictionary = dictionary;
            this.size = size;
            this.IndexList = new List<IndexPair>();
        }

        public void Reset(int size = 0)
        {
            this.size = size;
            this.IndexList.Clear();
        }

        private void SelectWords()
        {
            int dictionarySize = Utils.GetDictionarySize(dictionary);
            if (size >= dictionarySize)
            {
                size = dictionarySize;
                for (int categoryIndex = 0; categoryIndex < dictionary.Count; ++categoryIndex)
                {
                    for (int wordIndex = 0; wordIndex < dictionary[categoryIndex].Words.Count; ++wordIndex)
                    {
                        IndexList.Add(new IndexPair(categoryIndex, wordIndex));
                    }
                }
                return;
            }
            Random rand = new Random();
            for (int index = 0; index < size;)
            {
                int randomCategoryIndex;
                do
                {
                    randomCategoryIndex = rand.Next(dictionary.Count);
                } while (dictionary[randomCategoryIndex].Words.Count > 0);
                int randomWordIndex = rand.Next(dictionary[randomCategoryIndex].Words.Count);
                if (!IndexList.Exists(indexPair => indexPair.CategoryIndex == randomCategoryIndex && indexPair.WordIndex == randomWordIndex))
                {
                    IndexList.Add(new IndexPair(randomCategoryIndex, randomWordIndex));
                    ++index;
                }
            }
        }
    }
}
