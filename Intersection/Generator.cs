using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Intersection
{
    public class Generator
    {
        public IEnumerable<Element> GetRandomCollection()
        {
            
            List<Element> collection = new List<Element>();
            for (int i = 0; i < 50000; i++)
            {
                collection.Add(new Element(){Amount = RandomInt(5), Name = "fdsfs", Vendor = RandomString(6) });
            }
            return collection;
        }



        private  int RandomInt(int size)
        {
            Random random = new Random(Environment.TickCount);
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                //Генерируем число от 0 до 9, заполняем им разряд.
                result = (int)((result * 10) + (random.NextDouble() * 9));

                //Целое число не может начинаться с 0, если его разрядность больше 1
                if (size > 1 && result == 0)
                    result++;
            }
            return result;
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random(Environment.TickCount);
            char ch;
            for (int i = 0; i < size; i++)
            {
                //Генерируем число являющееся латинским символом в юникоде
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                //Конструируем строку со случайно сгенерированными символами
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }

    
}
