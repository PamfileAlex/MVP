using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int correct;
        public int Size { get { return size; } }
        public List<IndexPair> IndexList { get; }
        public int Index { get; set; }
        public ObservableCollection<String> ResultsList { get; }

        public Game(List<Category> dictionary)
        {
            this.dictionary = dictionary;
            this.IndexList = new List<IndexPair>();
            this.Index = 0;
            this.ResultsList = new ObservableCollection<string>();
        }

        public void Reset(int size = 0)
        {
            this.size = size;
            this.correct = 0;
            this.IndexList.Clear();
            this.Index = 0;
            this.ResultsList.Clear();
            if (this.size != 0)
            {
                SelectWords();
            }
        }

        public void SetWord(TextBlock DescriptionTextBlock, Image WordImage)
        {
            if (dictionary == null || IndexList.Count == 0) { return; }
            Random rand = new Random();
            if (rand.Next(2) == 0)
            {
                WordImage.Source = Utils.GetWordPhoto(dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].WordText);
                if (WordImage.Source != null) { return; }
            }
            DescriptionTextBlock.Text = dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].Description;
        }

        public void AddToResultsList(TextBox WordTextBox)
        {
            if (WordTextBox.Text.Equals(dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].WordText))
            {
                ResultsList.Add("Correct");
                ++correct;
            }
            else
            {
                ResultsList.Add("Raspunsul correct: " + dictionary[IndexList[Index].CategoryIndex].Words[IndexList[Index].WordIndex].WordText);
            }
        }

        public string GetOutOf()
        {
            return correct.ToString() + "/" + size.ToString();
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
                } while (dictionary[randomCategoryIndex].Words.Count <= 0);
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
