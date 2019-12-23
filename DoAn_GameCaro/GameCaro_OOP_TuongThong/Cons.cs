using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro_OOP_TuongThong
{
    class Cons
    {
        public static int CHESS_WIDTH = 35;
        public static int CHESS_HEIGHT = 35;

        public static int CHESS_BOARD_WIDTH = 20;
        public static int CHESS_BOARD_HEIGHT = 20;

        //Set bước nhảy cho 1 lần tăng progressbar là 100 mili giây (0.1 giây)
        public static int COOL_DOWN_STEP = 100;

        //Thời gian của progressbar  
        public static int COOL_DOWN_TIME = 20000;

        //Interval của progressbar sau bao lâu tăng 1 lần
        public static int COOl_DOWN_INTERVAL = 100;

        public static long VC = long.MaxValue;
    }
}