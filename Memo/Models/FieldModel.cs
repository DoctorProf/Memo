using Memo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Models
{
    internal class FieldModel : ViewModel
    {
        #region I
        private int i;
        public int I { get => i; set => Set(ref i, value); }
        #endregion

        #region J
        private int j;
        public int J { get => j; set => Set(ref j, value); }
        #endregion
    }
}
