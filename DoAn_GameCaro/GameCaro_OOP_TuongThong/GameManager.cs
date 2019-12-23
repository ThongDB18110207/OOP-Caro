using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro_OOP_TuongThong
{
    public enum PlayMode
    {
        PLAYER_PLAYER,
        LAN,
        PLAYER_COM_0,
        PLAYER_COM_1,
        PLAYER_COM_2,
        PLAYER_COM_3,
        PLAYER_COM_4,
        PLAYER_COM_5
    }
    class GameManager
    {
        private List<Player> players;
        public GameManager(List<Player> players)
        {
            this.Players = players;
        }
        public Point MayDanh_0(List<List<Button>> Matrix)
        {
            Random RandXY = new Random();
            int RandX = RandXY.Next(0, Cons.CHESS_BOARD_WIDTH - 1);
            int RandY = RandXY.Next(0, Cons.CHESS_BOARD_HEIGHT - 1);
            while (Matrix[RandY][RandX].BackgroundImage != null)
            {
                RandX = RandXY.Next(0, Cons.CHESS_BOARD_WIDTH - 1);
                RandY = RandXY.Next(0, Cons.CHESS_BOARD_HEIGHT - 1);
            }

            Point point = new Point(RandX, RandY);
            return point;
        }

        internal List<Player> Players { get => players; set => players = value; }


        #region AI
        private long[] DiemAttack = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private long[] DiemDefend = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        

        public Point MayDanh_1(List<List<Button>> Matrix)
        {
            Point point = new Point(0, 0);
            return point;
        }


        // Tấn công
        /*private long Attack_Doc(int curDong, int curCot, List<List<Button>> Matrix)
        {
            long DiemTong = 0;
            int SoquanTa = 0; 
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6 && Dem + curDong < _BanCo.SoDong; Dem++)
            {
                if (Matrix[curDong + Dem][curCot].BackgroundImage == 1)
                    SoquanTa++;
                else if (Matrix[curDong + Dem, curCot].Sohuu == 2)
                {
                    SoQuanDich++; break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && curDong - Dem > 0; Dem++)
            {
                if (Matrix[curDong - Dem, curCot].Sohuu == 1)
                    SoquanTa++;
                else if (Matrix[curDong - Dem, curCot].Sohuu == 2)
                {
                    SoQuanDich++; break;
                }
                else break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTong = DiemTong - DiemAttack[SoQuanDich + 1] * 2 + DiemAttack[SoquanTa];
            return DiemTong;
        }*/


        #endregion
    }
}
