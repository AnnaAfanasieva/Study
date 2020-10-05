using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace ConsoleApp1
{
    public class Data
    {
        public int coffee = 32, milk = 300, water = 2000, sugar = 100;
        //действительное наполнение машины
        public int maxcoffee = 100, maxmilk = 1000, maxwater = 10000, maxsugar = 1000;
        //максимальное значение наполнения
        public int c, m, w, s, C, M, W, S;
        //вывод во время наполнения машины
        public int cp, mp, wp, sp;
        //для процентного вывода наполнения
        public int choice, menu, sum = 50,y,z,P=0;
        public int pprice = 0, x;
        public string name = "Coffee_machine224";

        static void State(Data data) //вывод состояния ингридиентов кофемашины
        {
            data.cp = data.coffee * 100 / data.maxcoffee;
            data.mp = data.milk * 100 / data.maxmilk;
            data.wp = data.water * 100 / data.maxwater;
            data.sp = data.sugar * 100 / data.maxsugar;
            Console.Write("Кофе   (" + data.cp + "%) ");
            for(int i=0; i<data.cp; i=i+2) {
                Console.Write("_");
            }
            Console.WriteLine("");

            Console.Write("Молоко (" + data.mp + "%) ");
            for (int i = 0; i < data.mp; i=i+2)
            {
                Console.Write("_");
            }
            Console.WriteLine("");

            Console.Write("Вода   (" + data.wp + "%) ");
            for (int i = 0; i < data.wp; i = i + 2)
            {
                Console.Write("_");
            }
            Console.WriteLine("");

            Console.Write("Сахар  (" + data.sp + "%) ");
            for (int i = 0; i < data.sp; i = i + 2)
            {
                Console.Write("_");
            }
            Console.WriteLine("");

        }

        static void Menu(Data data)  { 
            Console.WriteLine("1 - Эспрессо   13грн");
            Console.WriteLine("2 - Латте      35грн");
            Console.WriteLine("3 - Капучино   29грн");
            Console.WriteLine("4 - Американо  28грн");
            Console.WriteLine("5 - Flat White 27грн");
            Console.WriteLine("6 - Расчитаться"); 
            Choice(data);
            
        }

        // Проверка количества ингридиентов
        static void Validation(Data data)
        {
            if (data.coffee < 16) {
                
                addC(data);
 
            }
            if (data.milk < 150) {
                
                addM(data);

            }
            if (data.water < 150) {
                
                addW(data);
    

            }
            if (data.sugar < 10) {
                
                addS(data);
              
            }
            Console.WriteLine("");

        }
        // Добавление ингридиентов
        static void addC (Data data) {
            Console.WriteLine("Недостаточное количество кофе! Добавьте кофе в аппарат");
            data.c = 16 - data.coffee;
            data.C = data.maxcoffee - data.coffee;
            Console.WriteLine("Добавьте минимум " + data.c + "гр., но не более " + data.C + "гр.");
            data.coffee = data.coffee + Convert.ToInt32(Console.ReadLine());
            if (data.coffee<16) { addC(data); }
            if (data.coffee>data.maxcoffee) {
                Console.WriteLine("Добавлено слишком много. Пополнено до максимального уровня");
                data.coffee = data.maxcoffee;
            }
        }
        static void addM(Data data)
        {
            Console.WriteLine("Недостаточное количество молока! Добавьте молоко в аппарат");
            data.m = 150 - data.milk;
            data.M = data.maxmilk - data.milk;
            Console.WriteLine("Добавьте минимум " + data.m + "мл., но не более " + data.M + "мл.");
            data.milk = data.milk + Convert.ToInt32(Console.ReadLine());
            if (data.milk < 150) { addM(data); }
            if (data.milk > data.maxmilk)
            {
                Console.WriteLine("Добавлено слишком много. Пополнено до максимального уровня");
                data.milk = data.maxmilk;
            }
        }
        static void addW(Data data)
        {
            Console.WriteLine("Недостаточное количество воды! Добавте воду в аппарат");
            data.w = 150 - data.water;
            data.W = data.maxwater - data.water;
            Console.WriteLine("Добавьте минимум " + data.w + "мл., но не более " + data.W + "мл.");
            data.water = data.water + Convert.ToInt32(Console.ReadLine());
            if (data.water < 150) { addW(data); }
            if (data.water > data.maxwater)
            {
                Console.WriteLine("Добавлено слишком много. Пополнено до максимального уровня");
                data.water = data.maxwater;
            }
        }
        static void addS(Data data)
        {
            Console.WriteLine("Недостаточное количество сахара! Добавьте сахар в аппарат");
            data.s = 10 - data.sugar;
            data.S = data.maxsugar - data.sugar;
            Console.WriteLine("Добавьте минимум " + data.s + "гр., но не более " + data.S + "гр.");
            data.sugar = data.sugar + Convert.ToInt32(Console.ReadLine());
            if (data.sugar < 10) { addS(data); }
            if (data.sugar > data.maxsugar)
            {
                Console.WriteLine("Добавлено слишком много. Пополнено до максимального уровня");
                data.sugar = data.maxsugar;
            }
        }
        // Все виды кофе 
        enum Coffee //определяем цену кофе
        {
            espresso = 13,
            latte = 35,
            cappuccino = 29,
            americano = 28,
            flatWhite = 27
        }
        static void espresso (Data data) {
            
            data.P = (int)Coffee.espresso + data.P; //чтобы суммировать несколько видов кофе
            data.coffee = data.coffee - 10;
            data.water = data.water - 35;
        }

        static void latte(Data data)
        {
            
            data.P = (int)Coffee.latte + data.P;
            data.coffee = data.coffee - 8;
            data.milk = data.milk - 150;
            data.water = data.water - 30;
            data.sugar = data.sugar - 10;
        }

        static void cappuccino(Data data)
        {
            
            data.P = (int)Coffee.cappuccino + data.P;
            data.coffee = data.coffee - 8;
            data.milk = data.milk - 100;
            data.water = data.water - 30;
            data.sugar = data.sugar - 10;
        }

        static void americano(Data data)
        {
            
            data.P = (int)Coffee.americano + data.P;
            data.coffee = data.coffee - 10;
            data.water = data.water - 150;
            data.sugar = data.sugar - 5;
        }

        static void FlatWhite(Data data)
        {
           
            data.P = (int)Coffee.flatWhite + data.P;
            data.coffee = data.coffee - 16;
            data.milk = data.milk - 120;
            data.water = data.water - 60;
            data.sugar = data.sugar - 10;
        }
        // Оплата 

            static void Summ(Data data) {
            data.x = data.P - data.pprice;
            Console.WriteLine("Введите в аппарат " + data.x + "грн.");
            Console.WriteLine ("Максимальный номинал купюры = 50грн.");
            
            data.x = data.pprice;
            data.pprice = data.pprice+Convert.ToInt32(Console.ReadLine());
            float q = data.pprice - data.x;

            if(data.pprice==data.P && q<=50) {
                data.sum = data.sum + data.pprice;
                Console.WriteLine("Принято");
                Console.WriteLine("");
                Console.WriteLine("Кофе готово!");
                Console.WriteLine("");


            }
            else
            {
                if (data.pprice>data.P && q<=50) { 
                    data.sum = data.sum + data.P;
                    data.pprice = data.pprice - data.P;
                    Console.WriteLine("Принято. Сдача " + data.pprice + "грн.");
                    Console.WriteLine("");
                    Console.WriteLine("Кофе готово!");
                    Console.WriteLine("");

                }
                else {
                    if (q>50) { Console.WriteLine("Слишком большой номинал купюры"); data.pprice = data.x; }               
                    Summ(data);
                }
            }
            data.pprice = 0;
            data.P = 0;
            data.x = 0;
            
        }

        static void Choice(Data data)
        {
            Console.WriteLine("Выберите напиток: ");
            data.choice = Convert.ToInt32(Console.ReadLine());
            
            switch (data.choice) {
                case 1: Validation(data); espresso(data); Menu(data); break;
                case 2: Validation(data); latte(data); Menu(data); break;
                case 3: Validation(data); cappuccino(data); Menu(data); break;
                case 4: Validation(data); americano(data); Menu(data); break;
                case 5: Validation(data); FlatWhite(data); Menu(data); break;
                case 6: Summ(data); break;
                default: Console.WriteLine("Значение введено неправильно"); break;

            }

        }

        static void Main(string[] args)
        {
            Data data = new Data();
            //string name = "Coffee_machine224";
            Console.WriteLine("Кофемашина " + data.name);
            Console.WriteLine("");
            while (true) {
                Console.WriteLine("Меню");
                Console.WriteLine("1 - Посмотреть ассортимент");
                Console.WriteLine("2 - Проверка количества ингридиентов");
                Console.WriteLine("3 - Изъятие кассы");
                Console.WriteLine("4 - Выход");

                Console.Write("Выберите действие: ");
                data.menu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (data.menu) {
                    case 1:  Menu(data); break;
                    case 2: State(data); break;
                    case 3: Console.WriteLine("На данный момент в кассе " + data.sum + "грн.");
                        Console.WriteLine("");

                        if (data.sum<=50) { break; }
                        else {
                            Console.WriteLine("Хотите изъять кассу?");
                            Console.WriteLine("1 - Да");
                            Console.WriteLine("2 - Нет");
                            data.x = Convert.ToInt32(Console.ReadLine());
                            switch (data.x) {
                                case 1:
                                    data.y = data.sum - 50;
                                    Console.WriteLine("Можно снять " + data.y + "грн. Сколько вы хотите снять?");
                                    data.z = Convert.ToInt32(Console.ReadLine());
                                    if (data.z<=data.y) {
                                        data.sum = data.sum - data.z;
                                        Console.WriteLine("Опереция выполнена успешно. На счету " + data.sum + "грн.");
                                        Console.WriteLine("");
                                    }
                                    else { Console.WriteLine("К сожалению, операцию выполнить неудалось. На данный момент в кассе " + data.sum + "грн."); }
                                    break;
                                case 2: break;
                                default: Console.WriteLine("Значение введено неправильно"); break;
                            }
                        }
                        
                        break;
                    case 4: Console.WriteLine("Хорошего дня!"); return; 
                    default: Console.WriteLine("Значение введено неправильно"); break;
                }

            }
        }
    }
}
