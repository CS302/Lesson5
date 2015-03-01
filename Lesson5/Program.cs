using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ненужный код
            string text1 = "простой текст";
            string text22 = text1;
            /*
             * при этом изменится только одна из двух строк.
             * поведение, присущее типу значений
             */
            text1 = "123";
            Console.WriteLine(text1);
            Console.WriteLine(text22);


            //звуковой сигнал
            string text = "\a";

            //перенос строки
            Console.Write("строка\n");
            text = "первая\nвторая";
            
            //возврат каретки
            text = "первая\r";
            Console.Write(text);

            //простая анимация, которая реализуется с помощью возврата каретки
            string[] symbols = new string[] { "\\", "|", "/", "-" };
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(symbols[i%4] + "\r");
                Thread.Sleep(200);
            }

            //одиночные слэши надо экранировать
            string path = "C:\\Lesson6\\1.txt";
            string path1 = Console.ReadLine();

            //в таком варианте одинарные кавычки можно писать прямо так
            string text111 = "наши занятия 'легкие'";
            Console.WriteLine(text111);

            //а в таком их необходимо экранировать
            char symbol = '\'';
            Console.WriteLine(symbol);

            //одиночные слэши можно экранировать с помощью собачки
            string path2 = @"C:\Users\Alex\Documents\GitHub\Lesson3\SQUARE.txt";

            //наряду, собачка заставляет учитывать перносы строки и табуляии
            string text11 = @"Первая строка
вторая строка
                примечание";
            Console.WriteLine(text11); //выведется ровно так, как оно записано в коде

            /*
             * есть свойство, которое отвечает за длину строки,
             * а к элементам строки можно обращаться по индексу.
             * индексация - с нуля
             */
            string text2 = "простая строка";
            Console.WriteLine(text2.Length);
            Console.WriteLine(text2[text2.Length-1]);

            //метод сравнения строк
            Console.WriteLine(text2.CompareTo("аростая строка"));

            Console.WriteLine();
            //проверка вхождения символа в строке
            Console.WriteLine(text2.Contains('п'));

            //вставка строки на нулевое место исходной
            Console.WriteLine(text2.Insert(0,"Это "));

            //удаление трех символов в строке начиная с 7ого
            Console.WriteLine(text2.Remove(7,3));

            /*
             * с помощью такой операции можно изменять содержимое исходной строки.
             * методы же работали только с копиями строк.
             */
            text2 = text2.Insert(8, "!!! ");
            Console.WriteLine(text2);

            Console.WriteLine(text2.Replace('о','a'));
            Console.WriteLine();
            Console.WriteLine(text2.Replace("простая","сложная"));

            string data = "61;616;6484;646853;6456"; //csv

            //с помощью этого метода можно разбить строку на
            //массив строк по разделителю в виде точки с запятой
            string[] items = data.Split(';');

            int sum = 0;
            for (int i = 0; i < items.GetLength(0); i++)
            {
                sum += int.Parse(items[i]);
            }
            Console.WriteLine(sum);

            //с помощью этого метода можно удалять символы в начале и в конце строки
            string username = " vasya ";
            username = username.TrimStart(' ');
            Console.WriteLine("|"+username+"|");

            //переводит все буквы строки в верхний регистр
            Console.WriteLine(text.ToUpper());

            //класс стрингбилдер работает быстрее
            StringBuilder data1 = new StringBuilder();

            int n = 1000000;
            Console.WriteLine(data1.Length); //его текущий размер
            Console.WriteLine(data1.Capacity); //его текущая вместимость 
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                data1.Append(i);
            }

            Console.WriteLine(data1.Length);
            Console.WriteLine(data1.Capacity);
            Console.WriteLine(data1.MaxCapacity); //его максимальная вместимость 


            /*
             * здесь мы поработали с шаблонами вывода для типа дабл
             */
            double price = 99.99866163111684;
            Console.WriteLine("Цена = {0}", price); //вместо нуля подставится наше число из переменной price

            Console.WriteLine("Цена = {0:e}", price); //science

            Console.WriteLine();
            Console.WriteLine("Цена = {0:c}", price); //commercial

            Console.WriteLine();
            Console.WriteLine("Цена = {0:.0000}", price); //кол-во знаков после ,

            Console.WriteLine();
            Console.WriteLine("Цена = {0:.####}", price);
            /*
            *  12.46 {0:.####} -> 12.46
            *  14.46 {0:.0000} -> 12.4600
            * 
            * 
            */

            #endregion
            /*
             * тут мы релизовывали шаблоны вывода для собственного класса.
             * реализацию смотреть в теле класса Point
             */
            Point p1 = new Point(416.45255, 646.843455);
            Console.WriteLine("{0:e}", p1);
            //[4.1645255+e002 ; 6.46843455+e002] ожидание
            Console.WriteLine();
            Console.WriteLine("{0:ij}", p1);
            //(416.45i , 646.84j) ожидание
            Console.WriteLine();
            Console.WriteLine("{0:csv}", p1);
            //416.45255;646.843455 ожидание

            DateTime date = DateTime.Now;
            Console.WriteLine(date);
            /*
             * встроенные форматы вывода даты
             */
            Console.WriteLine();
            Console.WriteLine("{0:hh:mm}", date);
            Console.WriteLine("{0:yy.MM.dd hh.mm}", date);
            Console.WriteLine("{0:yyyy MMMMMMMM dd hh:mm:ss}", date);
           
            string name = "василий";
            Console.WriteLine(name[0]);

            Console.ReadLine();
        }
    }
    /*
     * указываем, что класс реализует интерфейс "Я форматируемый"
     */
    class Point : IFormattable
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            /*Console.WriteLine("Координата Х = "+x);
            Console.WriteLine("Координата У = "+y);
            Console.WriteLine();
             аналогично следующему:
             */

            Console.WriteLine("Координата Х = {0}\nКоордината У = {1}\n", x,y);

            string message = String.Format("Координата Х = {0}\nКоордината У = {1}\n", x, y);
            Console.WriteLine(message);
        }

        //таким образом мы определяли собственный формат вывода
        //переопределив метод ToString();
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "e":
                    //[4.1645255+e002 ; 6.46843455+e002]
                    return String.Format("[{0:e} ; {1:e}]", x, y);
                case "ij":
                    //(416.45i , 646.84j)
                    return String.Format("({0:.##}i , {1:.##}j)", x,y);
                case "csv":
                    //416.45255;646.843455
                    return String.Format("{0};{1}", x,y);
                default:
                    return ToString();
            }
        }
    }
    
}
