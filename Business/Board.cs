using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Board
    {
        static bool closeClicked = false;

        public void BtnCloseClicked()
        {
            closeClicked = true;
        }
        public void BtnCreateClicked()
        {
            closeClicked = false;
        }
        public bool Closed()
        {
            return closeClicked;
        }
    }
}
