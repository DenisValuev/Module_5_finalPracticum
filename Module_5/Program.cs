namespace Module_5
{
    internal class Program
    {
        static (string Name, string LastName, int Age, string[] FavoriteColors, string[] NamePets) EnterUser()
        {
            (string Name, string LastName, int Age, string[] FavoriteColors, string[] NamePets) User;

            //Enter name user
            do
            {
                Console.Write("Введите имя пользователя: ");
                User.Name = Console.ReadLine();
            } while (CheckWord(User.Name));

            //Enter last name user
            do
            {
                Console.Write("Введите фамилию пользователя: ");
                User.LastName = Console.ReadLine();
            } while (CheckWord(User.LastName));

            //Enter age user
            string age;
            int intAge;
            do
            {
                Console.Write("Введите возраст пользователя цифрами: ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intAge));
            User.Age = intAge;

            //Enter count favorite colors and name colors
            string countColors;
            int intCountColors;
            do
            {
                Console.Write("Введите количество любимых цветов цифрами: ");
                countColors = Console.ReadLine();
            } while (CheckNum(countColors, out intCountColors));
            Console.WriteLine("Введите любимый(-е) цвет(-а):");
            User.FavoriteColors = GetArray(intCountColors);

            //Enter have pet, count pet and name pet
            string havePet;
            Console.WriteLine("Есть ли у Вас домашние питомцы? Да или нет?");
            havePet = Console.ReadLine();
            if (havePet == "Да")
            {
                string countPet;
                int intCountPet;
                do
                {
                    Console.Write("Введите количество домашних питомцев цифрами: ");
                    countPet = Console.ReadLine();
                } while (CheckNum(countPet, out intCountPet));
                Console.WriteLine("Введите кличку(-и) домашнего(-их) питомца(-ев):");
                User.NamePets = GetArray(intCountPet);
            }
            else
            {
                User.NamePets = null;
            }
            return User;
        }
        static bool CheckWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("Вы ничего не ввели, попробуйте еще раз");
                return true;
            }
            else
            {
                string number = "0123456789";
                for (int i = 0; i < 10; i++)
                {
                    if (word.Contains(number[i]))
                    {
                        Console.WriteLine("Данный некорректны!");
                        return true;
                    }

                }
            }
            return false;
        }
        static bool CheckNum(string number, out int corrNumber)
        {
            if (int.TryParse(number, out int intNum))
            {
                if (intNum > 0)
                {
                    corrNumber = intNum;
                    return false;
                }
            }
            {
                Console.WriteLine("Данные некорректны!");
                corrNumber = 0;
                return true;
            }
        }
        static string[] GetArray(int count)
        {
            string[] arr = new string[count];
            for (int i = 0; i < count; i++)
            {
                do
                {
                    Console.Write("{0}) ",i + 1);
                    arr[i] = Console.ReadLine();
                } while (CheckWord(arr[i]));
            }
            return arr;
        }
        static void ShowUser((string Name, string LastName, int Age, string[] FavoriteColors, string[] NamePets) User)
        {
            Console.WriteLine($"Имя пользователя: {User.Name}");
            Console.WriteLine($"Фамилия пользователя: {User.LastName}");
            Console.WriteLine($"Возраст пользователя: {User.Age}");
            Console.WriteLine($"Любимые цвета: ");
            foreach (var color in User.FavoriteColors)
            {
                Console.WriteLine(color);
            }
            if (User.NamePets == null)
            {
                Console.WriteLine("Домашних животных нет");
            }
            else
            {
                Console.WriteLine("Клички домашних животных:");
                foreach (var pet in User.NamePets)
                {
                    Console.WriteLine(pet);
                }
            }
        }
        static void Main(string[] args)
        {
            (string Name, string LastName, int Age, string[] FavorieteColors, string[] NamePets) User;
            User = EnterUser();
            ShowUser(User);
        }
    }
}
