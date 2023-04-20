using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IState modified = new ModifiedState();
            modified.DoAction(context);

            IState deleted = new DeleteState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState());

            Console.ReadKey();
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }
    }

    class DeleteState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetState(this);
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetState(this);
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }


}
