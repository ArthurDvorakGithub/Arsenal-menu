using System;

class MainClass
{
    static void Main(string[] args)
    {
        int position = 0;
        string typeNew = "0";
        string damageNew = "0";
        string speedNew = "0";
        string[,] guns = {
            { " Модель ", " Урон", " Скорость "},
            { " пистолет", " урон - 5"," скорость - 5 "},
            { " винтовка", " урон - 6"," скорость - 3 " },
            { " пулемет", " урон - 7"," скорость - 12 " },
            { " автомат" , " урон - 8 "," скорость - 10 ",}};

        string userInput = "null";
        string[] handGun = new string[3];
        handGun[0] = "ничего нет";


        while (userInput != "2")
        {
            Console.Clear();
            Console.WriteLine("Doom arsenal");
            Console.WriteLine("Экипировано: " + handGun[0]);
            Console.WriteLine("У вас на складе:");

            for (int i = 1; i < guns.GetLength(0); i++)
            {
                Console.WriteLine(guns[i, 0]);
            }

            Console.WriteLine("Меню");
            Console.WriteLine("1.Войти в кабинет игрока");
            Console.WriteLine("2.Выйти из программы");

            Console.WriteLine("Выберите номер команды:");

            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Кабинет игрока:");
                    Console.WriteLine("Введите номер команды:");
                    Console.WriteLine("1 - Экипировать новое оружие");
                    Console.WriteLine("2 - Добавить новое оружие на склад");
                    Console.WriteLine("3 - Удалить оружие");
                    Console.WriteLine("4 - Выйти");

                    userInput = Console.ReadLine();
                    do
                    {
                        if (userInput == "1")
                        {
                            epuipElement(position, guns, handGun);
                        }

                        if (userInput == "2")
                        {
                            Addlement(guns, typeNew, damageNew, speedNew);
                        }

                        else if (userInput == "3")
                        {
                            DeleteElement(position, guns, handGun);
                        }

                        else if (userInput == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("Нажмите любую клавишу что бы вернуться в меню");
                            Console.ReadKey();
                        }

                    } while (userInput == "4");

                } while (userInput == "4");
            }
            else if (userInput == "2")
            {

                Console.WriteLine("Нажмите любую клавишу что бы выйти из программы");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неправильную команду, попробуйте еще раз");
                Console.ReadKey();
            }
        }
    }
    static void epuipElement(int position, string[,] guns, string[] handGun)
    {
        Console.WriteLine("Выберите номер оружия из списка:");

        for (int i = 1; i < guns.GetLength(0); i++)
        {
            Console.WriteLine(i + "-" + guns[i, 0]);
        }

        position = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < guns.GetLength(1); i++)
        {
            handGun[i] = guns[position, i];
        }

    }
    static void Addlement(string[,] guns, string typeNew, string damageNew, string speedNew)
    {
        string[,] tempGuns = new string[guns.GetLength(0) + 1, guns.GetLength(1)];
        for (int i = 0; i < tempGuns.Length; i++)
        {
            for (int j = 0; j < tempGuns.Length; j++)
            {
                tempGuns[i, j] = guns[i, j];
            }
        }
        Console.WriteLine("Введите модель оружия");
        typeNew = Console.ReadLine();

        Console.WriteLine("Введите урон оружия");
        damageNew = Console.ReadLine();

        Console.WriteLine("Введите скорость оружия");
        speedNew = Console.ReadLine();

        tempGuns[tempGuns.GetLength(0) - 1, 0] = typeNew;
        tempGuns[tempGuns.GetLength(0) - 1, 1] = damageNew;
        tempGuns[tempGuns.GetLength(0) - 1, 2] = speedNew;

        guns = tempGuns;

    }
    static void DeleteElement(int position, string[,] guns, string[] handGun)
    {
        {

            Console.Clear();
            Console.WriteLine("Выберите оружие из списка:");

            for (int i = 1; i < guns.GetLength(0); i++)
            {
                Console.WriteLine(i + "-" + guns[i, 0]);
            }

            position = Convert.ToInt32(Console.ReadLine());

            if (handGun[0] == guns[position, 0])
            {
                handGun[0] = "удален";
                handGun[1] = "удален";
                handGun[2] = "удален";
            }

            string[,] deleteGuns = new string[guns.GetLength(0) - 1, guns.GetLength(1)];

            for (int i = 0; i < position; i++)
            {
                for (int j = 0; j < guns.GetLength(1); j++)
                {
                    deleteGuns[i, j] = guns[i, j];
                }
            }
            for (int i = position + 1; i < guns.GetLength(0); i++)
            {
                for (int j = 0; j < guns.GetLength(1); j++)
                {
                    deleteGuns[i - 1, j] = guns[i, j];
                }
            }
            guns = deleteGuns;
        }
    }

}