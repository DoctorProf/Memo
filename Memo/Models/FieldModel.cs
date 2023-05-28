using Memo.Constants;
using Memo.ViewModels.Base;

namespace Memo.Models
{
    internal class FieldModel : ViewModel
    {

        public string texture = TexturesPaths.Empty;

        #region TexturePath
        private string texturePath = TexturesPaths.Empty;
        public string TexturePath { get => texturePath; set => Set(ref texturePath, value); }
        #endregion

        #region Enable
        private bool enable = true;
        public bool Enable { get => enable; set => Set(ref enable, value); }
        #endregion

        #region Selected
        private bool selected = false;
        public bool Selected { get => selected; set => Set(ref selected, value); }
        #endregion

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
