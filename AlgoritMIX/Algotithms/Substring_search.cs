using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritMIX.Algotithms
{
    class Substring_search
    {
        //Алгоритм прямого поиска
        public int Direct_Search(string text, string word, int position = 0)
        {
            int l_text = text.Length;
            int l_word = word.Length;
            int j = 0;
            int new_position = position;
            if (position != 0)
                position++;

            for (int i = position; i < l_text; i++)
            {
                j = 0;


                while (text[i] == word[j] && i < l_text)
                {
                    if (l_word == 1)
                        return i;
                    i++; j++;
                    if (j == l_word - 1 && text[i] == word[j])
                    {
                        return i - j;
                    }
                }
            }

            return new_position;
        }

        //БМ поиск (если правильно понял с англ источника)
        public int BM_Search(string text, string word, int position = 0)
        {

            int l_text = text.Length - 1;
            int l_word = word.Length - 1;
            int new_position = position;
            if (position != 0) position++;
            int point_w = 0, point_t = position, i = 0;


            while (point_t < l_text - l_word)
            {
                point_w = l_word;
                while (point_w >= 0 && word[point_w] == text[point_t + point_w])
                {
                    point_w--;
                }
                if (point_w < 0)
                {
                    return point_t;
                }
                else
                {
                    point_t += Shift(word, text[point_t + point_w]);
                }
            }


            return new_position;
        }
        private int Shift(string word, char point_text)
        {
            int l_word = word.Length - 1;
            int x = 0;
            while (l_word >= 0 && word[l_word] != point_text)
            {
                x++;
                l_word--;
            }

            return x == 0 ? 1 : x;
        }
    }
}
