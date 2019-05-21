using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace prog_lab8_zad1_new
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            
            // задание 1
            Console.WriteLine("Задание 1.");
            string ryadok = File.ReadAllText("1.txt");
            Console.WriteLine(ryadok);
            Console.WriteLine("   " + checkBalanceOfBrackets(ryadok));
            string ryadok6 = File.ReadAllText("6.txt");
            Console.WriteLine(ryadok6);
            Console.WriteLine("   " + checkBalanceOfBrackets(ryadok6));



            // задание 2
            Console.WriteLine("\nЗадание 2.");
            string[] NewFile2 = File.ReadAllLines("2.txt");
            Queue queueOfPeopleUnder40 = new Queue();
            Queue queueOfPeopleAbove40 = new Queue();
            foreach (string str in NewFile2)
            {
                String[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (int.Parse(words[3]) < 40)
                    queueOfPeopleUnder40.Enqueue(words);
                else
                    queueOfPeopleAbove40.Enqueue(words);
            }
            Console.WriteLine("   < 40");
            foreach (string[] str in queueOfPeopleUnder40)
            {
                foreach (string subStr in str)
                    Console.Write(subStr + " ");
                Console.WriteLine();
            }
            Console.WriteLine("   > 40");
            foreach (string[] str in queueOfPeopleAbove40)
            {
                foreach (string subStr in str)
                    Console.Write(subStr + " ");
                Console.WriteLine();
            }



            // задание 3
            Console.WriteLine("\nЗадание 3.");
            string[] NewFile3 = File.ReadAllLines("3.txt");
            List<String[]> listOfArray1 = new List<String[]>();
            foreach (string str in NewFile3)
            {
                String[] words1 = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                listOfArray1.Add(words1);
            }
            listOfArray1.Sort((a1, a2) => a1[3].CompareTo(a2[3]));
            foreach (string[] str in listOfArray1)
            {
                foreach (string subStr in str)
                    Console.Write(subStr + " ");
                Console.WriteLine();
            }



            // задание 4
            Console.WriteLine("\nЗадание 4.");
            string NewFile4 = File.ReadAllText("4.txt");
            Stack stack1 = new Stack();
            String[] words3 = NewFile4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in words3)
            {
                Console.Write(str + " ");
                stack1.Push(str);
            }
            Console.WriteLine();
            while (stack1.Count != 0)
                Console.Write(stack1.Pop() + " ");



            // задание 5
            Console.WriteLine("\n\nЗадание 5.");
            Random rnd = new Random();
            ArrayList listOfNumbers = new ArrayList();
            for (int i = 0; i < 1840; i++)
                listOfNumbers.Add(rnd.Next(400, 700));

            listOfNumbers.Sort();
            foreach (int i in listOfNumbers)
                Console.Write(i + " ");

            listOfNumbers.Insert(7, 8); // 8 вариант
            int someNumb = rnd.Next(500, 1000);
            if (listOfNumbers.Contains(someNumb))
                Console.WriteLine(listOfNumbers.BinarySearch(someNumb));

            int someIndex = rnd.Next(0, 1840);
            listOfNumbers.RemoveAt(someIndex);
            listOfNumbers.Clear();


            //
        }


        // функция, проверяющая баланс скобок в строке
        static bool checkBalanceOfBrackets(string ryadok)
        {
            Queue countingBrackets = new Queue();
            foreach (char a in ryadok)
            {
                if (a == '(')
                    countingBrackets.Enqueue(1);
                if (a == ')')
                    try { countingBrackets.Dequeue(); }
                    catch ( InvalidOperationException ) { return false; }
            }
            return countingBrackets.Count == 0 ? true : false;
        }
    }
}
