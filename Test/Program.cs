using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskExample;

namespace Test
{
    internal class Program
    {
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            var sum = new Calcular();
            var task = new Task(() =>
            {
                Console.WriteLine("Comenzamos a realizar la tarea interna del task");
                //Comenzamos a sumar los primeros 100 numeros con un intervalo de espera de medio segundo
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    sum.AddNum(i);
                }
                Console.WriteLine("Termino la tarea 1");
                Console.WriteLine($"La suma final es {sum.Add}");
        });

            var task2 = new Task(() =>
            {
                Console.WriteLine("Comenzamos a realizar la tarea interna del task2");
                //Comenzamos a sumar los primeros 100 numeros con un intervalo de espera de medio segundo
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    sum.AddNum(i);
                }
                Console.WriteLine("Termino la tarea 2");
                Console.WriteLine($"La suma final es {sum.Add}");
            });
            ////////////////////////////////////////////////////////
            List<Task> tasksL = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasksL.Add(Task.Factory.StartNew(() =>
                { 
                    for (int j = 0; j < 1000; j++)
                    {
                        sum.Deposit(100);
                    }
                }));

                tasksL.Add(Task.Factory.StartNew(() =>
                {
                    for (int k = 0; k < 1000; k++)
                    {
                        sum.Draw(100);
                    }
                }));
            }
        
            task.Start();
            task2.Start();
            await task;
            await task2;

            Task.WaitAll(tasksL.ToArray());

            Console.WriteLine($"Task count {tasksL.Count}");

            Console.WriteLine($"Final balance is {sum.Balance}");
            Console.WriteLine("Termine");

            Console.ReadLine();
        }
    }
}
