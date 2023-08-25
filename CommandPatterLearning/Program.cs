using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatterLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Knights knights = new Knights();
            Builders builders = new Builders();

            player.SetCommand(new KnightsOnCommand(knights));
            player.PressButton();
            player.PressUndo();

            Console.WriteLine();

            player.SetCommand(new BuildersOnCommand(builders));
            player.PressButton();
            player.PressUndo();

            Console.Read();
        }
    }
    //command
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver
    class Knights
    {
        public void Attack()
        {
            Console.WriteLine("Knights attacking enemy");
        }

        public void Guard()
        {
            Console.WriteLine("Knights go back to guard");
        }
    }
    class Builders
    {
        public void Build()
        {
            Console.WriteLine("A castle was built");
        }

        public void Destroy()
        {
            Console.WriteLine("A castle was destroyed");
        }
    }


    //concrete command
    class KnightsOnCommand : ICommand
    {
        private Knights _knights;
        public KnightsOnCommand(Knights knights)
        {
            _knights = knights;
        }
        public void Execute()
        {
            _knights.Attack();
        }
        public void Undo()
        {
            _knights.Guard();
        }
    }  
    //concrete command
    class BuildersOnCommand : ICommand
    {
        private Builders _builders;
        public BuildersOnCommand(Builders builders)
        {
            _builders = builders;
        }
        public void Execute()
        {
            _builders.Build();
        }
        public void Undo()
        {
            _builders.Destroy();
        }
    }

    // Invoker 
    class Player
    {
        ICommand command;

        public Player() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}