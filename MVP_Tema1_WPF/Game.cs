using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVP_Tema1_WPF
{
    class Game
    {
        private List<Category> dictionary;
        private int size;
        public int Size { get { return size; } }
        public List<IndexPair> IndexList { get; }
        public int Index { get; set; }

        public Game(List<Category> dictionary, int size)
        {
            this.dictionary = dictionary;
            this.size = size;
            this.IndexList = new List<IndexPair>();
            this.Index = 0;
        }

        public void Reset(int size = 0)
        {
            this.size = size;
            this.IndexList.Clear();
            this.Index = 0;
            if (this.size != 0)
            {
                SelectWords();
            }
        }

        public string GetWordText()
        {
            if (dictionary == null || IndexList.Count == 0)
            {
                return null;
            }
            return dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].WordText;
        }

        public void NextWord(TextBlock DescriptionTextBlock, Image WordImage)
        {
            if (dictionary == null || IndexList.Count == 0)
            {
                return;
            }
            Random rand = new Random();
            if (rand.Next(2) == 0)
            {
                WordImage.Source = Utils.GetWordPhoto(dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].WordText);
                if (WordImage.Source != null)
                {
                    return;
                }
            }
            DescriptionTextBlock.Text = dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].Description;
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
