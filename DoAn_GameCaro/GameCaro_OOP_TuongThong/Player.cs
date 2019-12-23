using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro_OOP_TuongThong
{
    class Player
    {
        private string name; // Ctrl + R + E
        private Image mark;

        public Player(string name, Image mark)
        {
            this.Name = name;   // this bieu thi cho class hien tai
            this.Mark = mark;
        }
        public string Name { get => name; set => name = value; }
        public Image Mark { get => mark; set => mark = value; }
    }
}
