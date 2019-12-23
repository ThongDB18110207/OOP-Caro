using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro_OOP_TuongThong
{
    public class ChessBoardManager
    {
        private Panel chessBoard; // Ctrl + R + E Tạo hàm thuộc tính
        private List<Player> players;
        private int currentPlayer;
        private TextBox playerName;
        private PictureBox playerMark;
        private List<List<Button>> matrix;
        private Stack<PlayInfo> playTimeLine;
        private int cheDoChoi;
        
        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            this.Players = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\Co_X.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\Co_O.png"))
            };
            
        }
        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        internal List<Player> Players { get => players; set => players = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Stack<PlayInfo> PlayTimeLine { get => playTimeLine; set => playTimeLine = value; }
        public int CheDoChoi { get => cheDoChoi; set => cheDoChoi = value; }

        private event EventHandler<ButtonClickEvent> playerMarked;

        public event EventHandler<ButtonClickEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;

        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        #endregion

        #region Methods 
        public void DrawChessBoard()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();

            PlayTimeLine = new Stack<PlayInfo>();

            CurrentPlayer = 0; //Mặt định người chơi trước là 0
            ChangePlayer();

            //List lòng trong list như mảng 2 chiều
            Matrix = new List<List<Button>>();

            Button oldButton = new Button
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0)
            };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j <= Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    btn.Click += Btn_Click;

                    ChessBoard.Controls.Add(btn);

                    Matrix[i].Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
        

        private void Btn_Click(object sender, EventArgs e)
        {
            //sender là cái hiện tại đang thực thi chúng ta có thể ép kiểu nó về được
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            Mark(btn);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            //CurrentPlayer có bằng 1 hay không, nếu bằng 1 chuyển thành 0, nếu 0 thành 1
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));

            if (isEndGame(btn))
            {
                EndGame();
            }
            else if (CheDoChoi > 1)
                ComPlay(CheDoChoi);
        }

        public void OtherPlayerMark(Point point)
        {
            Button btn = Matrix[point.Y][point.X];

            if (btn.BackgroundImage != null)
                return;

            Mark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }

        //Xử lý khi kết thúc game
        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }

        public bool Undo()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            PlayInfo oldPoint = PlayTimeLine.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];

            btn.BackgroundImage = null;            

            if(PlayTimeLine.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldPoint = PlayTimeLine.Peek();
                CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;
            }
            ChangePlayer();
            return true;
        }

        //Lấy tọa độ
        private Point GetChessPoint(Button btn)
        {
            //Nằm trên hàng thứ tag
            int vertical = Convert.ToInt32(btn.Tag);

            //Lấy vị trí của btn nằm trên cột thứ mấy
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);
            return point;
        }

        //Kiểm tra hàng ngang
        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
             
            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }

            return countLeft + countRight == 5;
        }
        //Kiểm tra hàng dọc
        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }

        //Kiểm tra chéo chính
        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break; //Lố mảng

                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDTH || point.Y + i >= Cons.CHESS_BOARD_HEIGHT)
                    break;

                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }
        //Kiểm tra chéo phụ
        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.Y; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break; //Lố mảng

                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= Cons.CHESS_BOARD_HEIGHT)
                    break;

                //Ma trận có chiều hướng xuống là Y, ngang là X
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Players[currentPlayer].Mark;
        }
        public void ChangePlayer()
        {
            PlayerName.Text = Players[currentPlayer].Name;
            PlayerMark.Image = Players[currentPlayer].Mark;
        }


        public void ComPlay(int level)
        {
            CheDoChoi = level;

            Point mayDanh = new Point(0, 0);
            if (PlayTimeLine.Count == 0)
            {
                Players[0].Name = "Computer";
                mayDanh = new Point(Cons.CHESS_BOARD_WIDTH / 2, Cons.CHESS_BOARD_HEIGHT / 2);
            }
            else
            {
                switch (level)
                {
                    case (int)PlayMode.PLAYER_COM_0:
                        mayDanh = MayDanh_0(Matrix);
                        break;
                    case (int)PlayMode.PLAYER_COM_1:
                        mayDanh = MayDanh_1(Matrix);
                        break;
                    case (int)PlayMode.PLAYER_COM_2:
                        mayDanh = MayDanh_2(Matrix);
                        break;
                    case (int)PlayMode.PLAYER_COM_3:
                        mayDanh = MayDanh_3(Matrix);
                        break;
                    case (int)PlayMode.PLAYER_COM_4:
                        mayDanh = MayDanh_4(Matrix);
                        break;
                    default:
                        break;
                }
            }

            Button btn =  Matrix[mayDanh.Y][mayDanh.X];

            Mark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));


            if (isEndGame(btn))
            {
                EndGame();
            }

        }
        #endregion

        #region AI
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

        private long[] DiemAttack = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private long[] DiemDefend = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        public Point MayDanh_1(List<List<Button>> Matrix)
        {
            int dong = 0;
            int cot = 0;
            long DiemMax = -Cons.VC;

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        long DiemTanCong = 0;

                        DiemTanCong = TanCong_Cot(i, j) + TanCong_Hang(i, j) + TanCong_CheoChinh(i, j) + TanCong_CheoPhu(i, j);
                        

                        if (DiemTanCong > DiemMax)
                        {
                            DiemMax = DiemTanCong;
                            dong = i;
                            cot = j;
                        }
                    }

                }
            }

            Point point = new Point(cot, dong);
            return point;
        }
        public Point MayDanh_2(List<List<Button>> Matrix)
        {
            int dong = 0;
            int cot = 0;
            long DiemMax = 0;

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        long DiemPhongNgu = 0;

                        DiemPhongNgu = PhongNgu_Cot(i, j) + PhongNgu_Hang(i, j) + PhongNgu_CheoChinh(i, j) + PhongNgu_CheoPhu(i, j);

                        if (DiemPhongNgu > DiemMax)
                        {
                            DiemMax = DiemPhongNgu;
                            dong = i;
                            cot = j;
                        }
                    }

                }
            }

            Point point = new Point(cot, dong);
            return point;
        }
        public Point MayDanh_3(List<List<Button>> Matrix)
        {
            int dong = 0;
            int cot = 0;
            long DiemMax = -Cons.VC;

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        long DiemTanCong = 0;
                        long DiemPhongNgu = 0;

                        DiemTanCong = TanCong_Cot(i, j) + TanCong_Hang(i, j) + TanCong_CheoChinh(i, j) + TanCong_CheoPhu(i, j);
                        DiemPhongNgu = PhongNgu_Cot(i, j) + PhongNgu_Hang(i, j) + PhongNgu_CheoChinh(i, j) + PhongNgu_CheoPhu(i, j);


                        long temp = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if (temp > DiemMax)
                        {
                            DiemMax = temp;
                            dong = i;
                            cot = j;
                        }
                    }

                }
            }

            Point point = new Point(cot, dong);
            return point;
        }

        public Point MayDanh_4(List<List<Button>> Matrix)
        {
            int dong = 0;
            int cot = 0;
            long DiemMax = -Cons.VC;

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        long DiemTanCong = 0;
                        long DiemPhongNgu = 0;

                        DiemTanCong = TanCong_Cot(i, j) + TanCong_Hang(i, j) + TanCong_CheoChinh(i, j) + TanCong_CheoPhu(i, j);
                        DiemTanCong *= 2;
                        DiemPhongNgu = PhongNgu_Cot(i, j) + PhongNgu_Hang(i, j) + PhongNgu_CheoChinh(i, j) + PhongNgu_CheoPhu(i, j);


                        long temp = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if (temp > DiemMax)
                        {
                            DiemMax = temp;
                            dong = i;
                            cot = j;
                        }
                    }
                }
            }

            Point point = new Point(cot, dong);
            return point;
        }

        // Tấn công
        private long TanCong_Cot(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (Dem + curDong >= Cons.CHESS_BOARD_HEIGHT)
                    break;
                if (Matrix[curDong + Dem][curCot].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong + Dem][curCot].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++; break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0)
                    break;
                if (Matrix[curDong - Dem][curCot].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong - Dem][curCot].BackgroundImage == Players[1].Mark) 
                {
                    SoQuanDich++; 
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTong = DiemTong - DiemAttack[SoQuanDich + 1]  + DiemAttack[SoquanTa];
            return DiemTong;
        }

        private long TanCong_Hang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (Dem + curCot >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong][curCot + Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++; break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curCot - Dem < 0)
                    break;

                if (Matrix[curDong][curCot - Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTong = DiemTong - DiemAttack[SoQuanDich + 1] + DiemAttack[SoquanTa];
            return DiemTong;
        }

        private long TanCong_CheoChinh(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0 || curCot - Dem < 0)
                    break;

                if (Matrix[curDong - Dem][curCot - Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong - Dem][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++; break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong + Dem >= Cons.CHESS_BOARD_HEIGHT || curCot + Dem >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong + Dem][curCot + Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong + Dem][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTong = DiemTong - DiemAttack[SoQuanDich + 1] + DiemAttack[SoquanTa];
            return DiemTong;
        }

        private long TanCong_CheoPhu(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0 || curCot + Dem >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong - Dem][curCot + Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong - Dem][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++; break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong + Dem >= Cons.CHESS_BOARD_HEIGHT || curCot - Dem < 0)
                    break;

                if (Matrix[curDong + Dem][curCot - Dem].BackgroundImage == Players[0].Mark)
                    SoquanTa++;
                else if (Matrix[curDong + Dem][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTong = DiemTong - DiemAttack[SoQuanDich + 1] + DiemAttack[SoquanTa];
            return DiemTong;
        }


        // Phòng ngự

        private long PhongNgu_Cot(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (Dem + curDong >= Cons.CHESS_BOARD_HEIGHT)
                    break;
                if (Matrix[curDong + Dem][curCot].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong + Dem][curCot].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0)
                    break;
                if (Matrix[curDong - Dem][curCot].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong - Dem][curCot].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoquanTa == 2) return 0;
            DiemTong += DiemDefend[SoQuanDich];
            return DiemTong;
        }

        private long PhongNgu_Hang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (Dem + curCot >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong][curCot + Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }

                else if (Matrix[curDong][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curCot - Dem < 0)
                    break;

                if (Matrix[curDong][curCot - Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoquanTa == 2) return 0;
            DiemTong += DiemDefend[SoQuanDich];
            return DiemTong;
        }

        private long PhongNgu_CheoChinh(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0 || curCot - Dem < 0)
                    break;
                if (Matrix[curDong - Dem][curCot - Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong - Dem][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong + Dem >= Cons.CHESS_BOARD_HEIGHT || curCot + Dem >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong + Dem][curCot + Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong + Dem][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoquanTa == 2) return 0;
            DiemTong += DiemDefend[SoQuanDich];
            return DiemTong;
        }

        private long PhongNgu_CheoPhu(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoquanTa = 0;
            int SoQuanDich = 0;


            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong - Dem < 0 || curCot + Dem >= Cons.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[curDong - Dem][curCot + Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong - Dem][curCot + Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6; Dem++)
            {
                if (curDong + Dem >= Cons.CHESS_BOARD_HEIGHT || curCot - Dem < 0)
                    break;

                if (Matrix[curDong + Dem][curCot - Dem].BackgroundImage == Players[0].Mark)
                {
                    SoquanTa++;
                    break;
                }
                else if (Matrix[curDong + Dem][curCot - Dem].BackgroundImage == Players[1].Mark)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoquanTa == 2) return 0;
            DiemTong += DiemDefend[SoQuanDich];
            return DiemTong;
        }
        #endregion
    }
    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}
