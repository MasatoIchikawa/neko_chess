using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neko_chess.Forms.Message
{
    public static class MessageShow
    {
        public static void Check()
        {
            var f = new MessageForm(MessageEnum.Check);
            f.BringToFront();
            f.ShowDialog();
            f.Dispose();
        }

        public static void Win(MessageEnum messageEnum)
        {
            var f = new MessageForm(messageEnum);
            f.BringToFront();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
