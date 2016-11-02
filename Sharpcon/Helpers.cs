using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpcon
{
    class Helpers
    {
        public static bool Empty(string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}
