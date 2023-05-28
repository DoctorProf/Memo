
using Memo.Commands.Base;
using Memo.Models;
using Memo.ViewModels;

namespace Memo.Commands
{
    public class FieldClickCommand : Command
    {
        public override void Execute(object parameters)
        {
            object[] param = parameters as object[];
            FieldModel field = param[0] as FieldModel;
            GameViewModel fvm = param[1] as GameViewModel;
            fvm.ClickField(field);

        }
    }
}
