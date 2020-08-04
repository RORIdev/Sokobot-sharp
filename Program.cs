using System;
using System.Threading.Tasks;
using sisbase;
namespace Sokobot_sharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bot = new SisbaseBot();
            bot.RegisterBot(typeof(Program).Assembly);
            await bot.Start();
        }
    }
}
