using System.Diagnostics;

namespace Project_Anglia.Data
{
    [DebuggerDisplay("{Name} : {Age}")]
    class Girl : Living
    {
        public bool WantToMarry()
        {
            if (Naimisissä || Age < 13)
                return false;
            else
                return random.NextDouble() < 0.05F;
        }
    }
}
