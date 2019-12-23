using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro_OOP_TuongThong
{
    public partial class Form1 : Form
    {
        ChessBoardManager chessBoard;
        SocketManager socket;
        bool PlayInLan;
        public ChessBoardManager ChessBoard { get => chessBoard; set => chessBoard = value; }

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new ChessBoardManager(pnl_BanCo, tbx_TenNguoiChoi, pctb_QuanKeTiep);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;

            //Bao lâu nhảy 1 lần
            tm_CoolDown.Interval = Cons.COOl_DOWN_INTERVAL;

            socket = new SocketManager();

            NewGame();
        }
        void EndGame()
        {
            tm_CoolDown.Stop();
            pnl_BanCo.Enabled = false;
            undoToolStripMenuItem.Enabled = false;

            ChessBoard.CurrentPlayer = ChessBoard.CurrentPlayer == 1 ? 0 : 1;
            ChessBoard.ChangePlayer();

            MessageBox.Show(tbx_TenNguoiChoi.Text + " thắng", "Thông báo!");
        }

        void NewGame()
        {
            prcbCoolDown.Value = 0;
            tm_CoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
        }

        void Quit()
        {
                Application.Exit();
        }

        void Undo()
        {
            prcbCoolDown.Value = 0;
            ChessBoard.Undo();
            if (ChessBoard.CheDoChoi != (int)PlayMode.PLAYER_PLAYER)
                ChessBoard.Undo();
        }

        private void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            tm_CoolDown.Start();
            prcbCoolDown.Value = 0;


            //--------------------------------LAN---------------------//
            if(PlayInLan)
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));

                    pnl_BanCo.Enabled = false;

                    undoToolStripMenuItem.Enabled = false;

                    Listen();
                }
                catch
                {
                    pnl_BanCo.Enabled = true;
                }
            }
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tm_CoolDown_Tick(object sender, EventArgs e)
        {
            //Cho progressbar chạy
            prcbCoolDown.PerformStep();
            if(prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                EndGame();  
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else 
            {
                if (PlayInLan)
                {
                    try
                    {
                        socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                    }
                    catch { }
                }
            }
        }

        private void mP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer mp3 = new MediaPlayer();
            mp3.Show();
        }

        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.CheDoChoi = (int)PlayMode.PLAYER_PLAYER;
            PlayInLan = false;
            ChessBoard.Players[0].Name = "Player 1";
            NewGame();
        }

        private void level0ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewGame();
            PlayInLan = false;
            ChessBoard.ComPlay((int)PlayMode.PLAYER_COM_0);
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            PlayInLan = false;
            ChessBoard.ComPlay((int)PlayMode.PLAYER_COM_1);
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            PlayInLan = false;
            ChessBoard.ComPlay((int)PlayMode.PLAYER_COM_2);
        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            PlayInLan = false;
            ChessBoard.ComPlay((int)PlayMode.PLAYER_COM_3);
        }
        private void level4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            PlayInLan = false;
            ChessBoard.ComPlay((int)PlayMode.PLAYER_COM_4);
        }

        private void lANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.ComPlay((int)PlayMode.LAN);
            ChessBoard.Players[0].Name = "Player 1";
            PlayInLan = true;
            NewGame();
            try
            {
                socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            }
            catch { }
            pnl_BanCo.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch
                {

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnl_BanCo.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prcbCoolDown.Value = 0;
                        pnl_BanCo.Enabled = true;
                        tm_CoolDown.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Undo();
                        Undo();
                        prcbCoolDown.Value = 0;
                    }));
                    break;
                case (int)SocketCommand.END_GAME:
                    break;
                case (int)SocketCommand.QUIT:
                    tm_CoolDown.Stop();
                    MessageBox.Show("Người chơi đã thoát!");
                    break;
                default:
                    break;
            }
            Listen();
        }

        private void bt_LAN_Click(object sender, EventArgs e)
        {
            if (PlayInLan)
            {
                return;
            }
            else
            {
                socket.IP = tbx_IP.Text;

                if (!socket.ConnectServer())
                {
                    socket.isServer = true;
                    pnl_BanCo.Enabled = true;
                    socket.CreateServer();
                }
                else
                {
                    socket.isServer = false;
                    pnl_BanCo.Enabled = false;
                    Listen();
                }
                PlayInLan = true;
                
                //-----------------------------Thêm-------------------------------------//
                //lANToolStripMenuItem_Click(sender, e);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbx_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(tbx_IP.Text))
            {
                tbx_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
    }
}
