using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema1_WPF
{
    public class Word
    {
        public string WordText { get; set; }
        public string Description { get; set; }

        public Word()
        {
            this.WordText = String.Empty;
            this.Description = String.Empty;
        }

        public Word(string wordText, string description)
        {
            this.WordText = wordText;
            this.Description = description;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Word objAsWord = obj as Word;
            if (objAsWord == null) return false;
            else return Equals(objAsWord);
        }

        public bool Equals(Word other)
        {
            if (other == null) return false;
            return (this.WordText.Equals(other.WordText));
        }

        public bool Equals(string other)
        {
            if (other == null) return false;
            return (this.WordText.Equals(other));
        }
    }
}
