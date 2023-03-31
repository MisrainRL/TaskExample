using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
    public class Calcular
    {
        public object locked = new object();
        public int Add { get; set; }   
        public int Add2 { get; set; }

        public int Balance { get; set; }

        public void Deposit(int amount)
        {
            lock (locked)
            {
                Balance += amount;
            }
        }

        public void Draw(int amount)
        {
            lock (locked)
            {
                Balance -= amount;
            }
        }
        public void AddNum(int num)
        {
            lock (locked)
            {
                Add += num;
            }
        }

        public void AddNum2(int num)
        {
          
            lock (locked)
            {
                
                Add2 *= num;
            }
        }
    }
}
