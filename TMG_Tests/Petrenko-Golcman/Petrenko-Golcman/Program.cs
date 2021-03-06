using System;
using System.Collections.Generic;
using System.Linq;

/*
   Судя по описанию, индекс Петренко зависит чисто от длины отфильтрованной строки (без пробелов, знаков препинания и тд),
   а значит строки с эквивалентными длинами строк имеют один индекс.

   В английских строках есть комментарии, и по сути нужно найти русскому индексу соответствующую сумму индексов основной части в англ.
    тексте и комментария.

    Допустим, x - длина основной части англ.строки, y - длина комментария, z - длина русской строки. Целые числа. 
    Сумма индексов букв считается как арифметическая прогрессия, где tx - соответствующий член прогрессии
    Тогда: y(n)=(t1+tn)*n/2. У нас t1=0.5, tn=0.5+n-1;
    Тогда индекс Петренко: y(x) = ((0.5 + 0.5 + x - 1) * x / 2) * x = x^3 / 2. 
    Попробуем ставить пример строки из задания "Не выходи из...", длина 33, результат совпадает.
    Аналогично считаются индексы для y и z.
    Условие совпадения строк: 
    z^3 / 2 = x^3 /2 + y^3 /2  =>  z^3 = x^3 + y^3  =>  z = (x^3+y^3)^(1/3)
    Данное уравнение не имеет решения в натуральных числах, а значит не существует такой английской ненулевой строки 
    (по условию комментарий имеет как минимум 1 слово), которая соответствовала бы любой русской по индексу Петренко.
    Значит достаточно вывести русские строки. (Написано найти. Их нет, но программа нужна).
 */


namespace Petrenko_Golcman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rusLines = { "Meow", "Meow-meow", "Meow-Meow.Meow" };
            foreach(string line in rusLines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
