using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xadrez
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public int BotaoPressionado { get; private set; } = 0;

        private void CClick(object sender, EventArgs e)
        {
            PictureBox botao = null;
            foreach(PictureBox v in this.Controls)
            {
                if(v == sender)
                {
                    botao = v;
                }
            }

            if(botao.Name == "Rainha")
            {
                BotaoPressionado = 1;
                this.Close();
            }
            else if(botao.Name == "Cavalo")
            {
                BotaoPressionado = 2;
                this.Close();
            }
            else if(botao.Name == "Bispo")
            {
                BotaoPressionado = 3;
                this.Close();
            }
            else
            {
                BotaoPressionado = 4;
                this.Close();
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(BotaoPressionado != 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
