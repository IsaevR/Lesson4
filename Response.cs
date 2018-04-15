using System;
using System.Threading;

namespace Response
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // константы 
            const float best = 250.0F;  // лучшее время реакции 
            const float good = 500.0F;   // хорошее время реакции 
            const float easy = 850.0F;   // нормальное время реакции
            float result;
            char kay, kay2, q;
            int n;
            
            Console.WriteLine("\n\n\t\t СКОРОСТЬ РЕАКЦИИ ИЛИ БИОЛОГИЧЕСКИЙ ПИНГ");
            Console.WriteLine("\n\n У разных людей время реакции может быть от 0,11 до 0,3 секунды и больше. ");
            Console.WriteLine("Для того что бы измерить время вашей реакции, программа втечении 5-ти секунд\n"+
                "выведет на экран случайный символ. Вам следует как можно скорее нажать\n"+
                "на соответствующую клавишу.");

            Console.Write("\n\n\t\t\t Вы готовы ?(y/n)_\b");
            q = char.Parse(Console.ReadLine());    
            
            while (q == 'y')
            {
                Random ran = new Random();
                Console.Write("\n\nНажмите на указанную клавишу по сигналу ");
                Console.Write("\n\n\n\t\t\t\t_\b");
                kay = (char)ran.Next(97, 122);     //привидение к типу char рандомного значения
                                                   // от 97 до 122 (коды символов ASCII)
                                                   // для вывода случайного  символа в заданом диапазоне
                n = ran.Next(1000, 6000);          // получение случайного значения в заданом диапазоне
                Thread.Sleep(n);                   // остановка программы на заданый прериод времени переменной n
                Console.Write("{0}",kay);          // выводим наш рандомный символ
                Console.Beep();                    // воспроизведение сигнала 
                var start = DateTime.Now;          // сохраняем текущее время в переменной 
                kay2 = (char)(Console.ReadKey().KeyChar); // ввод символа с клавиатуры одним нажатием 
                                                          // на соответствующюю  клавишу(без нажатия на ENTER)
                if (kay == kay2)                          // сравниваем символы введенный пользователем и
                {                                         // генерированный компьютером
                    
                    TimeSpan time = DateTime.Now - start; // вычитаем текущее время от времени начала отчета
                                                          // TimeSpan преобразует значение текущего
                                                          // объекта TimeSpan в эквивалентное ему
                                                          // строковое представление.
                                                          // представленного текущей структурой TimeSpan
                    result = (float)time.TotalMilliseconds; // Возвращает компонент миллисекунд периода времени
                                                            // представленного текущей структурой TimeSpan
                    Console.WriteLine("\n\nВремя вашей реакции : {0:F1}", result);
                    
                    if (result <= best)
                        Console.WriteLine("\nПоздравляю!/n У Вас супер-быстрая реакция!");
                    else if (result <= good)
                        Console.WriteLine("\nУ Вас хорошая реакция!");
                    else if (result <= easy)
                        Console.WriteLine("\nУ Вас не плохая реакция.");
                    else
                        Console.WriteLine("\nВам следует немного потренироваться.");
                }
                else
                {
                    Console.WriteLine("\nВы нажали не верный символ.");
                    continue;
                }

                Console.Write("\n\n\t\t\t Повторить снова ? y/n:");
                q = char.Parse(Console.ReadLine());
            }
            
        }
    }
}
