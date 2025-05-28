using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xadrez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool selecionoupeca = false, daranpassant = false;
        int vez = 0, rodadaanpassant = 0, xecadoraX = 0, xecadoraY = 0, jogadasbranco = 0, jogadaspreto = 0;
        PictureBox anpassant = null, xecadora = null;
        string direcaoxeque = "";

        private void Tirarcores()
        {
            foreach (PictureBox v in this.Controls)
            {
                if (v.Tag == null)
                {
                    v.Enabled = false;
                }
                if (v.BackColor == Color.Green || v.BackColor == Color.Orange)
                {

                    if (v.Name.Contains("B"))
                    {
                        v.BackColor = Color.FromArgb(255, 206, 143);
                    }
                    else
                    {
                        v.BackColor = Color.FromArgb(51, 34, 27);
                    }
                }
            }

            if(xecadora != null)
            {
                string timedoreidoxeque = "";
                if (xecadora.Tag.ToString().Contains("branco"))
                {
                    timedoreidoxeque = "preto";
                }
                else
                {
                    timedoreidoxeque = "branco";
                }

                foreach(PictureBox v in this.Controls)
                {
                    if(v.Tag != null)
                    {
                        if (v.Tag.ToString().Contains(timedoreidoxeque))
                        {
                            if (v.Tag.ToString().Contains("rei"))
                            {
                                v.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach(PictureBox v in this.Controls)
                {
                    if(v.BackColor == Color.Red)
                    {
                        if (v.Name.Contains("B"))
                        {
                            v.BackColor = Color.FromArgb(255, 206, 143);
                        }
                        else
                        {
                            v.BackColor = Color.FromArgb(51, 34, 27);
                        }
                    }
                }
            }
        }

        private void Limpar()
        {
            foreach (PictureBox v in this.Controls)
            {
                if (v.Name.Contains("QB") || v.Name.Contains("QP"))
                {
                    v.BackgroundImage = null;
                    v.Tag = null;
                    v.Enabled = false;

                    if (v.BackColor == Color.Red || v.BackColor == Color.Green || v.BackColor == Color.Orange)
                    {
                        if (v.Name.Contains("B"))
                        {
                            v.BackColor = Color.FromArgb(255, 206, 143);
                        }
                        else
                        {
                            v.BackColor = Color.FromArgb(51, 34, 27);
                        }
                    }
                }
            }

            selecionoupeca = false;
            daranpassant = false;
            vez = 0;
            rodadaanpassant = 0;
            xecadoraX = 0;
            xecadoraY = 0;
            jogadasbranco = 0;
            jogadaspreto = 0;
            anpassant = null;
            xecadora = null;
            direcaoxeque = "";

            QP11.BackgroundImage = Properties.Resources.torre_branca;
            QP11.Tag = "torre branco 1";

            QB12.BackgroundImage = Properties.Resources.cavalo_branco;
            QB12.Tag = "cavalo branco 1";

            QP13.BackgroundImage = Properties.Resources.bispo_branco;
            QP13.Tag = "bispo branco 1";

            QB14.BackgroundImage = Properties.Resources.rainha_branca;
            QB14.Tag = "rainha branco 1";

            QP15.BackgroundImage = Properties.Resources.rei_branco;
            QP15.Tag = "rei branco";

            QB16.BackgroundImage = Properties.Resources.bispo_branco;
            QB16.Tag = "bispo branco 2";

            QP17.BackgroundImage = Properties.Resources.cavalo_branco;
            QP17.Tag = "cavalo branco 2";

            QB18.BackgroundImage = Properties.Resources.torre_branca;
            QB18.Tag = "torre branco 2";

            QB21.BackgroundImage = Properties.Resources.peao_branco;
            QB21.Tag = "peao branco 1";

            QP22.BackgroundImage = Properties.Resources.peao_branco;
            QP22.Tag = "peao branco 2";

            QB23.BackgroundImage = Properties.Resources.peao_branco;
            QB23.Tag = "peao branco 3";

            QP24.BackgroundImage = Properties.Resources.peao_branco;
            QP24.Tag = "peao branco 4";

            QB25.BackgroundImage = Properties.Resources.peao_branco;
            QB25.Tag = "peao branco 5";

            QP26.BackgroundImage = Properties.Resources.peao_branco;
            QP26.Tag = "peao branco 6";

            QB27.BackgroundImage = Properties.Resources.peao_branco;
            QB27.Tag = "peao branco 7";

            QP28.BackgroundImage = Properties.Resources.peao_branco;
            QP28.Tag = "peao branco 8";



            QB81.BackgroundImage = Properties.Resources.torre_preta;
            QB81.Tag = "torre preto 1";

            QP82.BackgroundImage = Properties.Resources.cavalo_preto;
            QP82.Tag = "cavalo preto 1";

            QB83.BackgroundImage = Properties.Resources.bispo_preto;
            QB83.Tag = "bispo preto 1";

            QP84.BackgroundImage = Properties.Resources.rainha_preta;
            QP84.Tag = "rainha preto 1";

            QB85.BackgroundImage = Properties.Resources.rei_preto;
            QB85.Tag = "rei preto";

            QP86.BackgroundImage = Properties.Resources.bispo_preto;
            QP86.Tag = "bispo preto 2";

            QB87.BackgroundImage = Properties.Resources.cavalo_preto;
            QB87.Tag = "cavalo preto 2";

            QP88.BackgroundImage = Properties.Resources.torre_preta;
            QP88.Tag = "torre preto 2";

            QP71.BackgroundImage = Properties.Resources.peao_preto;
            QP71.Tag = "peao preto 1";

            QB72.BackgroundImage = Properties.Resources.peao_preto;
            QB72.Tag = "peao preto 2";

            QP73.BackgroundImage = Properties.Resources.peao_preto;
            QP73.Tag = "peao preto 3";

            QB74.BackgroundImage = Properties.Resources.peao_preto;
            QB74.Tag = "peao preto 4";

            QP75.BackgroundImage = Properties.Resources.peao_preto;
            QP75.Tag = "peao preto 5";

            QB76.BackgroundImage = Properties.Resources.peao_preto;
            QB76.Tag = "peao preto 6";

            QP77.BackgroundImage = Properties.Resources.peao_preto;
            QP77.Tag = "peao preto 7";

            QB78.BackgroundImage = Properties.Resources.peao_preto;
            QB78.Tag = "peao preto 8";

            foreach(PictureBox v in this.Controls)
            {
                if(v.Tag != null)
                {
                    if (v.Tag.ToString().Contains("branco"))
                    {
                        v.Enabled = true;
                    }
                }
            }
        }

        private void Mexertorre(PictureBox peca, string nome, bool acertaorei, PictureBox pecainimiga)
        {
            int casachecando = peca.Location.Y - 65;
            while (casachecando >= 13)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == peca.Location.X)
                    {
                        if (v.Location.Y == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casachecando -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    casachecando = 0;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.Y + 65;
            while (casachecando <= 468)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == peca.Location.X)
                    {
                        if (v.Location.Y == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casachecando += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    casachecando = 500;
                                }
                                else
                                {
                                    casachecando = 500;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.X - 65;
            while (casachecando >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.Y == peca.Location.Y)
                    {
                        if (v.Location.X == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casachecando -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    casachecando = 0;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.X + 65;
            while (casachecando <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.Y == peca.Location.Y)
                    {
                        if (v.Location.X == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casachecando += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    casachecando = 500;
                                }
                                else
                                {
                                    casachecando = 500;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Mexerbispo(PictureBox peca, string nome, bool acertaorei, PictureBox pecainimiga)
        {
            int casav = peca.Location.Y - 65;
            int casah = peca.Location.X - 65;
            while (casav >= 13 && casah >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casah -= 65;
                                casav -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                                casah = 5;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y + 65;
            casah = peca.Location.X - 65;
            while (casav <= 468 && casah >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casah -= 65;
                                casav += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                                casah = 5;
                                casav = 500;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y - 65;
            casah = peca.Location.X + 65;
            while (casav >= 13 && casah <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casah += 65;
                                casav -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                                casah = 500;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y + 65;
            casah = peca.Location.X + 65;
            while (casav <= 468 && casah <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        v.BackColor = Color.Green;
                                        v.Enabled = true;
                                    }
                                }
                                casah += 65;
                                casav += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                                casah = 500;
                                casav = 500;
                            }
                        }
                    }
                }
            }
        }
        private void Mexerrei(PictureBox peca, string adversario)
        {
            foreach (PictureBox v in this.Controls)
            {
                int X = v.Location.X;
                int Y = v.Location.Y;
                if (X == peca.Location.X || X == peca.Location.X + 65 || X == peca.Location.X - 65)
                {
                    if (Y == peca.Location.Y || Y == peca.Location.Y + 65 || Y == peca.Location.Y - 65)
                    {
                        PictureBox pecainimiga = null;
                        if (v.Tag == null)
                        {
                            Console.WriteLine($"Começando Checagem");
                            bool acerta = false;
                            Checarcasa(X, Y, adversario, ref acerta, peca, ref pecainimiga);

                            if(acerta == false)
                            {
                                v.BackColor = Color.Green;
                                v.Enabled = true;
                            }
                        }
                        else if (v.Tag.ToString().Contains(adversario))
                        {
                            Console.WriteLine($"Começando Checagem");
                            bool acerta = false;
                            Checarcasa(X, Y, adversario, ref acerta, peca, ref pecainimiga);

                            if (acerta == false)
                            {
                                v.BackColor = Color.Green;
                                v.Enabled = true;
                            }
                        }
                    }
                }
            } // Movimentação Padrão

            // Movimentação Roque
            if(!peca.Tag.ToString().Contains("mexeu") && peca.BackColor != Color.Red) // Verifica se a peça já se mexeu
            {
                bool torrelonga = false;
                bool torrecurta = false;
                bool alarainhalimpa = true;
                bool alareilimpa = true;
                foreach (PictureBox v in this.Controls) // Olha cada casa do tabuleiro
                {
                    if (v.Tag != null) // Olha se é uma peça
                    {
                        if (!v.Tag.ToString().Contains(adversario)) // Se é uma peça do seu time
                        {
                            if (v.Tag.ToString().Contains("torre")) // Ve se é uma torre
                            {
                                if (v.Tag.ToString().Contains("1")) // Verifica se é a torre do roque longo
                                {
                                    if (!v.Tag.ToString().Contains("mexeu")) // Olha se a torre do roque longo já se moveu na partida
                                    {
                                        torrelonga = true;
                                    }
                                }
                                else // Se for torre do roque curto
                                {
                                    if (!v.Tag.ToString().Contains("mexeu")) // Verifica se ela já se mexeu na partida
                                    {
                                        torrecurta = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (torrelonga || torrecurta)
                {
                    foreach(PictureBox v in this.Controls)
                    {
                        if(v.Tag != null)
                        {
                            if(v.Location.Y == peca.Location.Y)
                            {
                                if (torrelonga)
                                {
                                    if (v.Location.X < peca.Location.X && v.Location.X > 12)
                                    {
                                        alarainhalimpa = false;
                                    }
                                }
                                if (torrecurta)
                                {
                                    if (v.Location.X > peca.Location.X && v.Location.X < 67)
                                    {
                                        alareilimpa = false;
                                    }
                                }
                            }
                        }
                    }
                }

                if (alarainhalimpa)
                {
                    bool acerta = false;
                    PictureBox pecainimiga = null;
                    Checarcasa(peca.Location.X - 65, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                    if (!acerta)
                    {
                        Checarcasa(peca.Location.X - 130, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                        if (!acerta)
                        {
                            foreach(PictureBox v in this.Controls)
                            {
                                if(v.Tag == null)
                                {
                                    if(v.Location.Y == peca.Location.Y)
                                    {
                                        if(v.Location.X == peca.Location.X - 130)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (alareilimpa)
                {
                    bool acerta = false;
                    PictureBox pecainimiga = null;
                    Checarcasa(peca.Location.X + 65, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                    if (!acerta)
                    {
                        Checarcasa(peca.Location.X + 130, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                        if (!acerta)
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag == null)
                                {
                                    if (v.Location.Y == peca.Location.Y)
                                    {
                                        if (v.Location.X == peca.Location.X + 130)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Verificartorre(PictureBox v, int X, int Y, ref bool acerta, string adversario, PictureBox peca, ref PictureBox pecainimiga)
        {
            int casachecando = v.Location.Y - 65;
            while (casachecando >= 13)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == v.Location.X)
                    {
                        if (v2.Location.Y == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casachecando -= 65;
                            }
                            else
                            {
                                casachecando = 0;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.Y + 65;
            while (casachecando <= 468)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == v.Location.X)
                    {
                        if (v2.Location.Y == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casachecando += 65;
                            }
                            else
                            {
                                casachecando = 500;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.X - 65;
            while (casachecando >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.Y == v.Location.Y)
                    {
                        if (v2.Location.X == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }
                            if (v2.Tag == null || v2 == peca)
                            {
                                casachecando -= 65;
                            }
                            else
                            {
                                casachecando = 0;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.X + 65;
            while (casachecando <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.Y == v.Location.Y)
                    {
                        if (v2.Location.X == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casachecando += 65;
                            }
                            else
                            {
                                casachecando = 500;
                            }

                        }
                    }
                }
            }
        }
        private void Verificarbispo(PictureBox v, int X, int Y, ref bool acerta, string adversario, PictureBox peca, ref PictureBox pecainimiga)
        {
            int casav = v.Location.Y - 65;
            int casah = v.Location.X - 65;
            while (casav >= 13 && casah >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casah -= 65;
                                casav -= 65;
                            }
                            else
                            {
                                casah = 5;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y + 65;
            casah = v.Location.X - 65;
            while (casav <= 468 && casah >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casah -= 65;
                                casav += 65;
                            }
                            else
                            {
                                casah = 5;
                                casav = 500;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y - 65;
            casah = v.Location.X + 65;
            while (casav >= 13 && casah <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casah += 65;
                                casav -= 65;
                            }
                            else
                            {
                                casah = 500;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y + 65;
            casah = v.Location.X + 65;
            while (casav <= 468 && casah <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                pecainimiga = v;
                            }

                            if (v2.Tag == null || v2 == peca)
                            {
                                casah += 65;
                                casav += 65;
                            }
                            else
                            {
                                casah = 500;
                                casav = 500;
                            }
                        }
                    }
                }
            }
        }
        private void Verificartorrexeque(PictureBox v, int X, int Y, ref bool acerta, string adversario, ref string direcaoxeque, ref int xecadoraX, ref int xecadoraY, ref PictureBox xecadora)
        {
            int casachecando = v.Location.Y - 65;
            while (casachecando >= 13)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == v.Location.X)
                    {
                        if (v2.Location.Y == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "verticalC";

                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casachecando -= 65;
                            }
                            else
                            {
                                casachecando = 0;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.Y + 65;
            while (casachecando <= 468)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == v.Location.X)
                    {
                        if (v2.Location.Y == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "verticalB";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casachecando += 65;
                            }
                            else
                            {
                                casachecando = 500;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.X - 65;
            while (casachecando >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.Y == v.Location.Y)
                    {
                        if (v2.Location.X == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "horizontalE";
                            }
                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casachecando -= 65;
                            }
                            else
                            {
                                casachecando = 0;
                            }
                        }
                    }
                }
            }

            casachecando = v.Location.X + 65;
            while (casachecando <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.Y == v.Location.Y)
                    {
                        if (v2.Location.X == casachecando)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "horizontalD";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casachecando += 65;
                            }
                            else
                            {
                                casachecando = 500;
                            }

                        }
                    }
                }
            }
        }
        private void Verificarbispoxeque(PictureBox v, int X, int Y, ref bool acerta, string adversario, ref string direcaoxeque, ref int xecadoraX, ref int xecadoraY, ref PictureBox xecadora)
        {
            int casav = v.Location.Y - 65;
            int casah = v.Location.X - 65;
            while (casav >= 13 && casah >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "ec";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casah -= 65;
                                casav -= 65;
                            }
                            else
                            {
                                casah = 5;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y + 65;
            casah = v.Location.X - 65;
            while (casav <= 468 && casah >= 12)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "eb";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casah -= 65;
                                casav += 65;
                            }
                            else
                            {
                                casah = 5;
                                casav = 500;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y - 65;
            casah = v.Location.X + 65;
            while (casav >= 13 && casah <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "dc";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casah += 65;
                                casav -= 65;
                            }
                            else
                            {
                                casah = 500;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = v.Location.Y + 65;
            casah = v.Location.X + 65;
            while (casav <= 468 && casah <= 467)
            {
                foreach (PictureBox v2 in this.Controls)
                {
                    if (v2.Location.X == casah)
                    {
                        if (v2.Location.Y == casav)
                        {
                            if (v2.Location.X == X && v2.Location.Y == Y)
                            {
                                acerta = true;
                                xecadora = v;
                                xecadoraX = v.Location.X;
                                xecadoraY = v.Location.Y;
                                direcaoxeque = "db";
                            }

                            if (v2.Tag == null || (!v2.Tag.ToString().Contains(adversario) && v2.Tag.ToString().Contains("rei")))
                            {
                                casah += 65;
                                casav += 65;
                            }
                            else
                            {
                                casah = 500;
                                casav = 500;
                            }
                        }
                    }
                }
            }
        }
        private void Verificartorrexecadora(PictureBox v, int X, int Y, ref bool acerta, string adversario, ref string direcaoxeque)
        {
            int casachecando = 0;
            if (direcaoxeque == "verticalC")
            {
                casachecando = v.Location.Y - 65;
                while (casachecando >= 13)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == v.Location.X)
                        {
                            if (v2.Location.Y == casachecando)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casachecando -= 65;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }
            else if(direcaoxeque == "verticalB")
            {
                casachecando = v.Location.Y + 65;
                while (casachecando <= 468)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == v.Location.X)
                        {
                            if (v2.Location.Y == casachecando)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casachecando += 65;
                                }
                                else
                                {
                                    casachecando = 500;
                                }
                            }
                        }
                    }
                }
            }
            else if(direcaoxeque == "horizontalE")
            {
                casachecando = v.Location.X - 65;
                while (casachecando >= 12)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.Y == v.Location.Y)
                        {
                            if (v2.Location.X == casachecando)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }
                                if (v2.Tag == null)
                                {
                                    casachecando -= 65;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }
            else if(direcaoxeque == "horizontalD")
            {
                casachecando = v.Location.X + 65;
                while (casachecando <= 467)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.Y == v.Location.Y)
                        {
                            if (v2.Location.X == casachecando)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casachecando += 65;
                                }
                                else
                                {
                                    casachecando = 500;
                                }

                            }
                        }
                    }
                }
            }
        }
        private void Verificarbispoxecador(PictureBox v, int X, int Y, ref bool acerta, string adversario, ref string direcaoxeque)
        {
            int casav = 0;
            int casah = 0;

            if (direcaoxeque == "ec")
            {
                casav = v.Location.Y - 65;
                casah = v.Location.X - 65;
                while (casav >= 13 && casah >= 12)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == casah)
                        {
                            if (v2.Location.Y == casav)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casah -= 65;
                                    casav -= 65;
                                }
                                else
                                {
                                    casah = 5;
                                    casav = 5;
                                }
                            }
                        }
                    }
                }
            }
            else if (direcaoxeque == "eb")
            {
                casav = v.Location.Y + 65;
                casah = v.Location.X - 65;
                while (casav <= 468 && casah >= 12)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == casah)
                        {
                            if (v2.Location.Y == casav)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casah -= 65;
                                    casav += 65;
                                }
                                else
                                {
                                    casah = 5;
                                    casav = 500;
                                }
                            }
                        }
                    }
                }
            }
            else if (direcaoxeque == "dc")
            {
                casav = v.Location.Y - 65;
                casah = v.Location.X + 65;
                while (casav >= 13 && casah <= 467)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == casah)
                        {
                            if (v2.Location.Y == casav)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casah += 65;
                                    casav -= 65;
                                }
                                else
                                {
                                    casah = 500;
                                    casav = 5;
                                }
                            }
                        }
                    }
                }
            }
            else if (direcaoxeque == "db")
            {
                casav = v.Location.Y + 65;
                casah = v.Location.X + 65;
                while (casav <= 468 && casah <= 467)
                {
                    foreach (PictureBox v2 in this.Controls)
                    {
                        if (v2.Location.X == casah)
                        {
                            if (v2.Location.Y == casav)
                            {
                                if (v2.Location.X == X && v2.Location.Y == Y)
                                {
                                    acerta = true;
                                }

                                if (v2.Tag == null)
                                {
                                    casah += 65;
                                    casav += 65;
                                }
                                else
                                {
                                    casah = 500;
                                    casav = 500;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Checarcasa(int X, int Y, string adversario, ref bool acerta, PictureBox peca, ref PictureBox pecainimiga)
        {
            foreach(PictureBox v in this.Controls)
            {
                if(v.Tag != null)
                {
                    if (v.Tag.ToString().Contains(adversario))
                    {
                        if (v.Tag.ToString().Contains("peao"))
                        {
                            Console.WriteLine($"Checando Peão");
                            if (adversario == "preto")
                            {
                                if(Y == v.Location.Y + 65)
                                {
                                    if(X == v.Location.X - 65 || X == v.Location.X + 65)
                                    {
                                        acerta = true;
                                        pecainimiga = v;
                                    }
                                }
                            }
                            else
                            {
                                if (Y == v.Location.Y - 65)
                                {
                                    if (X == v.Location.X - 65 || X == v.Location.X + 65)
                                    {
                                        acerta = true;
                                        pecainimiga = v;
                                    }
                                }
                            }
                        }
                        else if (v.Tag.ToString().Contains("cavalo"))
                        {
                            Console.WriteLine($"Checando Cavalo");
                            if (X == v.Location.X + 130 || X == v.Location.X - 130)
                            {
                                if(Y == v.Location.Y + 65 || Y == v.Location.Y - 65)
                                {
                                    acerta = true;
                                    pecainimiga = v;
                                }
                            }
                            else if (X == v.Location.X + 65 || X == v.Location.X - 65)
                            {
                                if (Y == v.Location.Y + 130 || Y == v.Location.Y - 130)
                                {
                                    acerta = true;
                                    pecainimiga = v;
                                }
                            }
                        }
                        else  if (v.Tag.ToString().Contains("torre"))
                        {
                            Console.WriteLine($"Checando Torre");
                            Verificartorre(v, X, Y, ref acerta, adversario, peca, ref pecainimiga);
                        }
                        else if (v.Tag.ToString().Contains("bispo"))
                        {
                            Console.WriteLine($"Checando Bispo");
                            Verificarbispo(v, X, Y, ref acerta, adversario, peca, ref pecainimiga);
                        }
                        else if (v.Tag.ToString().Contains("rainha"))
                        {
                            Console.WriteLine($"Checando Rainha");
                            Verificartorre(v, X, Y, ref acerta, adversario, peca, ref pecainimiga);
                            Verificarbispo(v, X, Y, ref acerta, adversario, peca, ref pecainimiga);
                        }
                        else if (v.Tag.ToString().Contains("rei"))
                        {
                            Console.WriteLine($"Checando Rei");
                            if (X == v.Location.X + 65 || X == v.Location.X - 65 || X == v.Location.X)
                            {
                                if(Y == v.Location.Y + 65 || Y == v.Location.Y - 65 || Y == v.Location.Y)
                                {
                                    acerta = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Checarcasaxeque(int X, int Y, string adversario, ref bool acerta, ref string direcaoxeque, ref int xecadoraX, ref int xecadoraY, ref PictureBox xecadora)
        {
            foreach (PictureBox v in this.Controls)
            {
                if (v.Tag != null)
                {
                    if (v.Tag.ToString().Contains(adversario))
                    {
                        if (v.Tag.ToString().Contains("peao"))
                        {
                            Console.WriteLine($"Checando Peão");
                            if (adversario == "preto")
                            {
                                if (Y == v.Location.Y + 65)
                                {
                                    if (X == v.Location.X - 65 || X == v.Location.X + 65)
                                    {
                                        acerta = true;
                                        xecadora = v;
                                        xecadoraX = v.Location.X;
                                        xecadoraY = v.Location.Y;
                                    }
                                }
                            }
                            else
                            {
                                if (Y == v.Location.Y - 65)
                                {
                                    if (X == v.Location.X - 65 || X == v.Location.X + 65)
                                    {
                                        acerta = true;
                                        xecadora = v;
                                        xecadoraX = v.Location.X;
                                        xecadoraY = v.Location.Y;
                                    }
                                }
                            }
                        }
                        else if (v.Tag.ToString().Contains("cavalo"))
                        {
                            Console.WriteLine($"Checando Cavalo");
                            if (X == v.Location.X + 130 || X == v.Location.X - 130)
                            {
                                if (Y == v.Location.Y + 65 || Y == v.Location.Y - 65)
                                {
                                    acerta = true;
                                    xecadora = v;
                                    xecadoraX = v.Location.X;
                                    xecadoraY = v.Location.Y;
                                }
                            }
                            else if (X == v.Location.X + 65 || X == v.Location.X - 65)
                            {
                                if (Y == v.Location.Y + 130 || Y == v.Location.Y - 130)
                                {
                                    acerta = true;
                                    xecadora = v;
                                    xecadoraX = v.Location.X;
                                    xecadoraY = v.Location.Y;
                                }
                            }
                        }
                        else if (v.Tag.ToString().Contains("torre"))
                        {
                            Console.WriteLine($"Checando Torre");
                            Verificartorrexeque(v, X, Y, ref acerta, adversario, ref direcaoxeque, ref xecadoraX, ref xecadoraY, ref xecadora);
                        }
                        else if (v.Tag.ToString().Contains("bispo"))
                        {
                            Console.WriteLine($"Checando Bispo");
                            Verificarbispoxeque(v, X, Y, ref acerta, adversario, ref direcaoxeque, ref xecadoraX, ref xecadoraY, ref xecadora);
                        }
                        else if (v.Tag.ToString().Contains("rainha"))
                        {
                            Console.WriteLine($"Checando Rainha");
                            Verificartorrexeque(v, X, Y, ref acerta, adversario, ref direcaoxeque, ref xecadoraX, ref xecadoraY, ref xecadora);
                            Verificarbispoxeque(v, X, Y, ref acerta, adversario, ref direcaoxeque, ref xecadoraX, ref xecadoraY, ref xecadora);
                        }
                        else if (v.Tag.ToString().Contains("rei"))
                        {
                            Console.WriteLine($"Checando Rei");
                            if (X == v.Location.X + 65 || X == v.Location.X - 65 || X == v.Location.X)
                            {
                                if (Y == v.Location.Y + 65 || Y == v.Location.Y - 65 || Y == v.Location.Y)
                                {
                                    acerta = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Checarsairxeque(int X, int Y, string adversario, ref bool acerta, ref PictureBox xecadora, ref string direcaoxeque)
        {
            PictureBox v = xecadora;

            if(v.Location.X == X && v.Location.Y == Y)
            {
                acerta = true;
            }
         
            if (v.Tag.ToString().Contains("torre"))
                        {
                            Console.WriteLine($"Checando Torre");
                            Verificartorrexecadora(v, X, Y, ref acerta, adversario, ref direcaoxeque);
                        }
            else if (v.Tag.ToString().Contains("bispo"))
                        {
                            Console.WriteLine($"Checando Bispo");
                            Verificarbispoxecador(v, X, Y, ref acerta, adversario, ref direcaoxeque);
                        }
            else if (v.Tag.ToString().Contains("rainha"))
                        {
                            Console.WriteLine($"Checando Rainha");
                            Verificartorrexecadora(v, X, Y, ref acerta, adversario, ref direcaoxeque);
                            Verificarbispoxecador(v, X, Y, ref acerta, adversario, ref direcaoxeque);
                        } 
        }

        private void Acharpeca(string tipopeca, PictureBox pecaverificadora, ref PictureBox peca)
        {

            string time;
            if (pecaverificadora.Tag.ToString().Contains("branco"))
            {
                time = "branco";
            }
            else
            {
                time = "preto";
            }

            foreach (PictureBox v in this.Controls)
            {
                if(v.Tag != null)
                {
                    if (v.Tag.ToString().Contains(time))
                    {
                        if (v.Tag.ToString().Contains(tipopeca))
                        {
                            peca = v; break;
                        }
                    }
                }
            }
        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Moverpeca(PictureBox a, PictureBox b)
        {
            bool ativaranpassant = false;
            if (b.Tag.ToString().Contains("peao"))
            {
                if (!b.Tag.ToString().Contains("mexeu"))
                {
                    b.Tag += "mexeu";
                }

                if (b.Tag.ToString().Contains("branco"))
                {
                    if (b.Location.Y - a.Location.Y == 130)
                    {
                        ativaranpassant = true;
                    }
                }
                else
                {
                    if (a.Location.Y - b.Location.Y == 130)
                    {
                        ativaranpassant = true;
                    }
                }

                if (b.Tag.ToString().Contains("branco"))
                {
                    if(a.Location.Y == 13)
                    {
                        Form2 form2 = new Form2();
                        form2.ShowDialog();

                        if(form2.BotaoPressionado == 1)
                        {
                            b.BackgroundImage = Properties.Resources.rainha_branca;
                            b.Tag = "rainha branco promocao";
                        }
                        else if (form2.BotaoPressionado == 2)
                        {
                            b.BackgroundImage = Properties.Resources.cavalo_branco;
                            b.Tag = "cavalo branco promocao";
                        }
                        else if (form2.BotaoPressionado == 3)
                        {
                            b.BackgroundImage = Properties.Resources.bispo_branco;
                            b.Tag = "bispo branco promocao";
                        }
                        else if (form2.BotaoPressionado == 4)
                        {
                            b.BackgroundImage = Properties.Resources.torre_branca;
                            b.Tag = "torre branco promocao";
                        }

                    }
                }
                else
                {
                    if(a.Location.Y == 468)
                    {
                        Form3 form3 = new Form3();
                        form3.ShowDialog();

                        if (form3.BotaoPressionado == 1)
                        {
                            b.BackgroundImage = Properties.Resources.rainha_preta;
                            b.Tag = "rainha preto promocao";
                        }
                        else if (form3.BotaoPressionado == 2)
                        {
                            b.BackgroundImage = Properties.Resources.cavalo_preto;
                            b.Tag = "cavalo preto promocao";
                        }
                        else if (form3.BotaoPressionado == 3)
                        {
                            b.BackgroundImage = Properties.Resources.bispo_preto;
                            b.Tag = "bispo preto promocao";
                        }
                        else if (form3.BotaoPressionado == 4)
                        {
                            b.BackgroundImage = Properties.Resources.torre_preta;
                            b.Tag = "torre preto promocao";
                        }
                    }
                }

                if (daranpassant)
                {
                    daranpassant = false;
                    if (a.Location.X == b.Location.X - 65 || a.Location.X == b.Location.X + 65)
                    {
                        if (b.Tag.ToString().Contains("branco"))
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Tag.ToString().Contains("preto"))
                                    {
                                        if (v.Location.X == a.Location.X)
                                        {
                                            if (v.Location.Y == b.Location.Y)
                                            {
                                                if (v == anpassant)
                                                {
                                                    v.Tag = null;
                                                    v.BackgroundImage = null;
                                                    anpassant = null;
                                                    rodadaanpassant = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Tag.ToString().Contains("branco"))
                                    {
                                        if (v.Location.X == a.Location.X)
                                        {
                                            if (v.Location.Y == b.Location.Y)
                                            {
                                                if (v == anpassant)
                                                {
                                                    v.Tag = null;
                                                    v.BackgroundImage = null;
                                                    anpassant = null;
                                                    rodadaanpassant = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if(b.Tag.ToString().Contains("torre") || b.Tag.ToString().Contains("rei"))
            {
                if (!b.Tag.ToString().Contains("mexeu"))
                {
                    b.Tag += "mexeu";
                }

                if (b.Tag.ToString().Contains("rei"))
                {
                    PictureBox torredoroque = null;
                    string adversario;
                    if (b.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                    else
                    {
                        adversario = "branco";
                    }

                    string roquedatorre = "";

                    if(a.Location.X < b.Location.X)
                    {
                        if(b.Location.X - a.Location.X == 130)
                        {
                            roquedatorre = "1";
                        }
                    }
                    else if(a.Location.X > b.Location.X)
                    {
                        if(a.Location.X - b.Location.X == 130)
                        {
                            roquedatorre = "2";
                        }
                    }

                    if(roquedatorre != "")
                    {
                        PictureBox casaqueatorrevai = null;
                        int casaY = b.Location.Y;
                        int casaX = 0;
                        foreach (PictureBox v in this.Controls)
                        {
                            if (v.Tag != null)
                            {
                                if (!v.Tag.ToString().Contains(adversario))
                                {
                                    if (v.Tag.ToString().Contains("torre"))
                                    {
                                        if (v.Tag.ToString().Contains(roquedatorre))
                                        {
                                            torredoroque = v;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if(v.Location.X == b.Location.X - 65)
                                {
                                    if(roquedatorre == "1")
                                    {
                                        casaX = v.Location.X;
                                    }
                                }
                                else if(v.Location.X == b.Location.X + 65)
                                {
                                    if (roquedatorre == "2")
                                    {
                                        casaX = v.Location.X;
                                    }
                                }
                            }
                        }
                        foreach(PictureBox v in this.Controls)
                        {
                            if(v.Tag == null)
                            {
                                if(v.Location.Y == casaY)
                                {
                                    if(v.Location.X == casaX)
                                    {
                                        casaqueatorrevai = v;
                                    }
                                }
                            }
                        }

                        torredoroque.Tag += "mexeu";

                        casaqueatorrevai.Tag = torredoroque.Tag;
                        casaqueatorrevai.BackgroundImage = torredoroque.BackgroundImage;
                        torredoroque.Tag = null;
                        torredoroque.BackgroundImage = null;
                    }

                }

            }

            if (xecadora != null)
            {
                xecadora = null;
                xecadoraX = 0;
                xecadoraY = 0;
                direcaoxeque = "";
            }

                a.Tag = b.Tag;
                a.BackgroundImage = b.BackgroundImage;
                b.Tag = null;
                b.BackgroundImage = null;

                if (ativaranpassant)
                {
                    anpassant = a;
                    rodadaanpassant = vez;
                }

            foreach (PictureBox v in this.Controls)
            {
                if (v.Tag != null)
                {
                    if (v.Tag.ToString().Contains("rei"))
                    {
                        string adversario = "";
                        if (v.Tag.ToString().Contains("branco"))
                        {
                            adversario = "preto";
                        }
                        else
                        {
                            adversario = "branco";
                        }
                        bool acerta = false;
                       Checarcasaxeque(v.Location.X, v.Location.Y, adversario, ref acerta, ref direcaoxeque, ref xecadoraX, ref xecadoraY, ref xecadora);
                        if (acerta)
                        {
                            v.BackColor = Color.Red;
                        }
                    }
                }
            }

            Checarfimdejogo("branco", ref jogadasbranco);
            Checarfimdejogo("preto", ref jogadaspreto);
            if (jogadasbranco == 0 || jogadaspreto == 0)
            {
                if (jogadasbranco == 0)
                {
                    bool mate = false;
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.Tag != null)
                        {
                            if (v.Tag.ToString().Contains("branco"))
                            {
                                if (v.Tag.ToString().Contains("rei"))
                                {
                                    if (v.BackColor == Color.Red)
                                    {
                                        mate = true;
                                    }
                                }
                            }
                        }
                    }

                    if (mate)
                    {
                        Tirarcores();
                        if (MessageBox.Show("Xeque-Mate, vitória das pretas", "Xadrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Limpar();
                        }
                    }
                    else
                    {
                        Tirarcores();
                        if (MessageBox.Show("Afogamento, a partida empatou", "Xadrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Limpar();
                        }
                    }
                }
                else if (jogadaspreto == 0)
                {
                    bool mate = false;
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.Tag != null)
                        {
                            if (v.Tag.ToString().Contains("preto"))
                            {
                                if (v.Tag.ToString().Contains("rei"))
                                {
                                    if (v.BackColor == Color.Red)
                                    {
                                        mate = true;
                                    }
                                }
                            }
                        }
                    }

                    if (mate)
                    {
                        Tirarcores();
                        if (MessageBox.Show("Xeque-Mate, vitória das brancas", "Xadrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Limpar();
                        }
                    }
                    else
                    {
                        Tirarcores();
                        if (MessageBox.Show("Afogamento, a partida empatou", "Xadrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Limpar();
                        }
                    }
                }
                
            }

            int cavalobranco = 0;
            int torrebranca = 0;
            int bispobranco = 0;
            int peaobranco = 0;
            int damabranca = 0;

            int cavalopreto = 0;
            int torrepreta = 0;
            int bispopreto = 0;
            int peaopreto = 0;
            int damapreta = 0;

            foreach (PictureBox v in this.Controls)
            {
                if (v.Tag != null)
                {
                    if (v.Tag.ToString().Contains("branco"))
                    {
                        if (v.Tag.ToString().Contains("cavalo"))
                        {
                            cavalobranco++;
                        }
                        if (v.Tag.ToString().Contains("torre"))
                        {
                            torrebranca++;
                        }
                        if (v.Tag.ToString().Contains("bispo"))
                        {
                            bispobranco++;
                        }
                        if (v.Tag.ToString().Contains("peao"))
                        {
                            peaobranco++;
                        }
                        if (v.Tag.ToString().Contains("dama"))
                        {
                            damabranca++;
                        }
                    }
                    else
                    {
                        if (v.Tag.ToString().Contains("cavalo"))
                        {
                            cavalopreto++;
                        }
                        if (v.Tag.ToString().Contains("torre"))
                        {
                            torrepreta++;
                        }
                        if (v.Tag.ToString().Contains("bispo"))
                        {
                            bispopreto++;
                        }
                        if (v.Tag.ToString().Contains("peao"))
                        {
                            peaopreto++;
                        }
                        if (v.Tag.ToString().Contains("dama"))
                        {
                            damapreta++;
                        }
                    }
                }
            }

            bool brancopodedarmate = true;
            bool pretopodedarmate = true;

            if(torrebranca == 0 && peaobranco == 0 && damabranca == 0 && cavalobranco <= 1 && bispobranco <= 1)
            {
                brancopodedarmate = false;
            }
            if (torrepreta == 0 && peaopreto == 0 && damapreta == 0 && cavalopreto <= 1 && bispobranco <= 1)
            {
                pretopodedarmate = false;
            }

            if(!brancopodedarmate && !pretopodedarmate)
            {
                Tirarcores();
                if (MessageBox.Show("Afogamento, a partida empatou", "Xadrez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Limpar();
                }
            }

        }
        private void Desabilitalita()
            {
                bool preto = false;
                bool branco = true;
                if (vez % 2 == 1)
                {
                    preto = true;
                    branco = false;
                }
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Tag == null)
                    {
                        v.Enabled = false;
                    }
                    else
                    {
                        if (v.Tag.ToString().Contains("preto"))
                        {
                            v.Enabled = preto;
                        }
                        else if (v.Tag.ToString().Contains("branco"))
                        {
                            v.Enabled = branco;
                        }
                    }
                }
            }

        private void Jogadastorre(PictureBox peca, string nome, bool acertaorei, PictureBox pecainimiga, ref int jogadas)
        {
            int casachecando = peca.Location.Y - 65;
            while (casachecando >= 13)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == peca.Location.X)
                    {
                        if (v.Location.Y == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casachecando -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    casachecando = 0;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.Y + 65;
            while (casachecando <= 468)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == peca.Location.X)
                    {
                        if (v.Location.Y == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casachecando += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    casachecando = 500;
                                }
                                else
                                {
                                    casachecando = 500;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.X - 65;
            while (casachecando >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.Y == peca.Location.Y)
                    {
                        if (v.Location.X == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casachecando -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    casachecando = 0;
                                }
                                else
                                {
                                    casachecando = 0;
                                }
                            }
                        }
                    }
                }
            }

            casachecando = peca.Location.X + 65;
            while (casachecando <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.Y == peca.Location.Y)
                    {
                        if (v.Location.X == casachecando)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casachecando += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    casachecando = 500;
                                }
                                else
                                {
                                    casachecando = 500;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Jogadasbispo(PictureBox peca, string nome, bool acertaorei, PictureBox pecainimiga, ref int jogadas)
        {
            int casav = peca.Location.Y - 65;
            int casah = peca.Location.X - 65;
            while (casav >= 13 && casah >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casah -= 65;
                                casav -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                                casah = 5;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y + 65;
            casah = peca.Location.X - 65;
            while (casav <= 468 && casah >= 12)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casah -= 65;
                                casav += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                                casah = 5;
                                casav = 500;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y - 65;
            casah = peca.Location.X + 65;
            while (casav >= 13 && casah <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casah += 65;
                                casav -= 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                                casah = 500;
                                casav = 5;
                            }
                        }
                    }
                }
            }

            casav = peca.Location.Y + 65;
            casah = peca.Location.X + 65;
            while (casav <= 468 && casah <= 467)
            {
                foreach (PictureBox v in this.Controls)
                {
                    if (v.Location.X == casah)
                    {
                        if (v.Location.Y == casav)
                        {
                            if (v.Tag == null)
                            {
                                if (xecadora == null)
                                {
                                    if (!acertaorei)
                                    {
                                        jogadas++;
                                    }
                                }
                                else
                                {
                                    bool acerta = false;
                                    Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                    if (acerta)
                                    {
                                        jogadas++;
                                    }
                                }
                                casah += 65;
                                casav += 65;
                            }
                            else
                            {
                                if (v.Tag.ToString().Contains(nome))
                                {
                                    if (xecadora == null)
                                    {
                                        if (!acertaorei || v == pecainimiga)
                                        {
                                            jogadas++;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;
                                        Checarsairxeque(v.Location.X, v.Location.Y, nome, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                                casah = 500;
                                casav = 500;
                            }
                        }
                    }
                }
            }
        }
        private void Jogadasrei(PictureBox peca, string adversario, ref int jogadas)
        {
            foreach (PictureBox v in this.Controls)
            {
                int X = v.Location.X;
                int Y = v.Location.Y;
                if (X == peca.Location.X || X == peca.Location.X + 65 || X == peca.Location.X - 65)
                {
                    if (Y == peca.Location.Y || Y == peca.Location.Y + 65 || Y == peca.Location.Y - 65)
                    {
                        PictureBox pecainimiga = null;
                        if (v.Tag == null)
                        {
                            Console.WriteLine($"Começando Checagem");
                            bool acerta = false;
                            Checarcasa(X, Y, adversario, ref acerta, peca, ref pecainimiga);

                            if (acerta == false)
                            {
                                jogadas++;
                            }
                        }
                        else if (v.Tag.ToString().Contains(adversario))
                        {
                            Console.WriteLine($"Começando Checagem");
                            bool acerta = false;
                            Checarcasa(X, Y, adversario, ref acerta, peca, ref pecainimiga);

                            if (acerta == false)
                            {
                                jogadas++;
                            }
                        }
                    }
                }
            } // Movimentação Padrão

            // Movimentação Roque
            if (!peca.Tag.ToString().Contains("mexeu") && peca.BackColor != Color.Red) // Verifica se a peça já se mexeu
            {
                bool torrelonga = false;
                bool torrecurta = false;
                bool alarainhalimpa = true;
                bool alareilimpa = true;
                foreach (PictureBox v in this.Controls) // Olha cada casa do tabuleiro
                {
                    if (v.Tag != null) // Olha se é uma peça
                    {
                        if (!v.Tag.ToString().Contains(adversario)) // Se é uma peça do seu time
                        {
                            if (v.Tag.ToString().Contains("torre")) // Ve se é uma torre
                            {
                                if (v.Tag.ToString().Contains("1")) // Verifica se é a torre do roque longo
                                {
                                    if (!v.Tag.ToString().Contains("mexeu")) // Olha se a torre do roque longo já se moveu na partida
                                    {
                                        torrelonga = true;
                                    }
                                }
                                else // Se for torre do roque curto
                                {
                                    if (!v.Tag.ToString().Contains("mexeu")) // Verifica se ela já se mexeu na partida
                                    {
                                        torrecurta = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (torrelonga || torrecurta)
                {
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.Tag != null)
                        {
                            if (v.Location.Y == peca.Location.Y)
                            {
                                if (torrelonga)
                                {
                                    if (v.Location.X < peca.Location.X && v.Location.X > 12)
                                    {
                                        alarainhalimpa = false;
                                    }
                                }
                                if (torrecurta)
                                {
                                    if (v.Location.X > peca.Location.X && v.Location.X < 67)
                                    {
                                        alareilimpa = false;
                                    }
                                }
                            }
                        }
                    }
                }

                if (alarainhalimpa)
                {
                    bool acerta = false;
                    PictureBox pecainimiga = null;
                    Checarcasa(peca.Location.X - 65, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                    if (!acerta)
                    {
                        Checarcasa(peca.Location.X - 130, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                        if (!acerta)
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag == null)
                                {
                                    if (v.Location.Y == peca.Location.Y)
                                    {
                                        if (v.Location.X == peca.Location.X - 130)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (alareilimpa)
                {
                    bool acerta = false;
                    PictureBox pecainimiga = null;
                    Checarcasa(peca.Location.X + 65, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                    if (!acerta)
                    {
                        Checarcasa(peca.Location.X + 130, peca.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                        if (!acerta)
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag == null)
                                {
                                    if (v.Location.Y == peca.Location.Y)
                                    {
                                        if (v.Location.X == peca.Location.X + 130)
                                        {
                                            jogadas++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Checarfimdejogo(string time, ref int jogadas)
        {
            jogadas = 0;

            foreach (PictureBox peca in this.Controls)
            {
                if(peca.Tag != null)
                {
                    if (peca.Tag.ToString().Contains(time))
                    {
                        PictureBox pecainimiga = null;
                        PictureBox rei = null;
                        Acharpeca("rei", peca, ref rei);

                        if (peca.Tag.ToString().Contains("cavalo"))
                        {
                            int verticalcima = peca.Location.Y - 130;
                            int verticalbaixo = peca.Location.Y + 130;
                            int horizontalesq = peca.Location.X - 65;
                            int horizontaldir = peca.Location.X + 65;
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.Y == verticalcima || v.Location.Y == verticalbaixo)
                                {
                                    if (v.Location.X == horizontalesq || v.Location.X == horizontaldir)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (peca.Tag.ToString().Contains("branco"))
                                            {
                                                if (v.Tag.ToString().Contains("preto"))
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        bool acerta = false;
                                                        Checarcasa(rei.Location.X, rei.Location.Y, "preto", ref acerta, peca, ref pecainimiga);
                                                        if (!acerta || v == pecainimiga)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (v.Tag.ToString().Contains("branco"))
                                                {

                                                    if (xecadora == null)
                                                    {
                                                        bool acerta = false;
                                                        Checarcasa(rei.Location.X, rei.Location.Y, "branco", ref acerta, peca, ref pecainimiga);

                                                        if (!acerta || v == pecainimiga)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string adversario = "";
                                            if (peca.Tag.ToString().Contains("branco"))
                                            {
                                                adversario = "preto";
                                            }
                                            else
                                            {
                                                adversario = "branco";
                                            }
                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                                                if (!acerta)
                                                {
                                                    jogadas++;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;

                                                Checarsairxeque(v.Location.X, v.Location.Y, adversario, ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    jogadas++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                            verticalcima = peca.Location.Y - 65;
                            verticalbaixo = peca.Location.Y + 65;
                            horizontalesq = peca.Location.X - 130;
                            horizontaldir = peca.Location.X + 130;
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.Y == verticalcima || v.Location.Y == verticalbaixo)
                                {
                                    if (v.Location.X == horizontalesq || v.Location.X == horizontaldir)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (peca.Tag.ToString().Contains("branco"))
                                            {
                                                if (v.Tag.ToString().Contains("preto"))
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        bool acerta = false;
                                                        Checarcasa(rei.Location.X, rei.Location.Y, "preto", ref acerta, peca, ref pecainimiga);

                                                        if (!acerta || v == pecainimiga)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (v.Tag.ToString().Contains("branco"))
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        bool acerta = false;
                                                        Checarcasa(rei.Location.X, rei.Location.Y, "branco", ref acerta, peca, ref pecainimiga);

                                                        if (!acerta || v == pecainimiga)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string adversario = "";
                                            if (peca.Tag.ToString().Contains("branco"))
                                            {
                                                adversario = "preto";
                                            }
                                            else
                                            {
                                                adversario = "branco";
                                            }

                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                                                if (!acerta)
                                                {
                                                    jogadas++;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;

                                                Checarsairxeque(v.Location.X, v.Location.Y, adversario, ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    jogadas++;
                                                }
                                            }

                                        }
                                    }
                                }

                            }
                        }
                        else if (peca.Tag.ToString().Contains("peao"))
                        {

                            string adversario;
                            if (peca.Tag.ToString().Contains("branco"))
                            {
                                adversario = "preto";
                            }
                            else
                            {
                                adversario = "branco";
                            }
                            bool acertaorei = false;
                            Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);
                            if (peca.Tag.ToString().Contains("mexeu"))
                            {
                                if (peca.Tag.ToString().Contains("branco"))
                                {
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Location.X == peca.Location.X)
                                        {
                                            if (v.Location.Y == peca.Location.Y - 65)
                                            {
                                                if (v.Tag == null)
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        if (!acertaorei)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                            {
                                                if (v.Location.Y == peca.Location.Y - 65)
                                                {
                                                    if (v.Tag.ToString().Contains("preto"))
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            if (!acertaorei || v == pecainimiga)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                }
                                else
                                {
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Location.X == peca.Location.X)
                                        {
                                            if (v.Location.Y == peca.Location.Y + 65)
                                            {
                                                if (v.Tag == null)
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        if (!acertaorei)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                            {
                                                if (v.Location.Y == peca.Location.Y + 65)
                                                {
                                                    if (v.Tag.ToString().Contains("branco"))
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            if (!acertaorei || v == pecainimiga)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                if (anpassant != null && !acertaorei)
                                {
                                    if (xecadora == null || xecadora == anpassant)
                                    {
                                        foreach (PictureBox v in this.Controls)
                                        {
                                            if (v.Tag != null)
                                            {
                                                if (v.Location.Y == peca.Location.Y)
                                                {
                                                    if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                                    {
                                                        if (v == anpassant)
                                                        {
                                                            if (peca.Tag.ToString().Contains("branco"))
                                                            {
                                                                foreach (PictureBox v2 in this.Controls)
                                                                {
                                                                    if (v2.Tag == null)
                                                                    {
                                                                        if (v2.Location.X == v.Location.X)
                                                                        {
                                                                            if (v2.Location.Y == v.Location.Y - 65)
                                                                            {
                                                                                jogadas++;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                foreach (PictureBox v2 in this.Controls)
                                                                {
                                                                    if (v2.Tag == null)
                                                                    {
                                                                        if (v2.Location.X == v.Location.X)
                                                                        {
                                                                            if (v2.Location.Y == v.Location.Y + 65)
                                                                            {
                                                                                jogadas++;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (peca.Tag.ToString().Contains("branco"))
                                {
                                    bool prosseguir = false;
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Location.X == peca.Location.X)
                                        {
                                            if (v.Location.Y == peca.Location.Y - 65)
                                            {
                                                if (v.Tag == null)
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        jogadas++;
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    prosseguir = true;
                                                }
                                            }
                                        }
                                    }

                                    if (prosseguir == true)
                                    {
                                        foreach (PictureBox v in this.Controls)
                                        {
                                            if (v.Location.X == peca.Location.X)
                                            {
                                                if (v.Location.Y == peca.Location.Y - 130)
                                                {
                                                    if (v.Tag == null)
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            jogadas++;
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                            {
                                                if (v.Location.Y == peca.Location.Y - 65)
                                                {
                                                    if (v.Tag.ToString().Contains("preto"))
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            jogadas++;
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                }
                                else
                                {
                                    bool prosseguir = false;
                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Location.X == peca.Location.X)
                                        {
                                            if (v.Location.Y == peca.Location.Y + 65)
                                            {
                                                if (v.Tag == null)
                                                {
                                                    if (xecadora == null)
                                                    {
                                                        jogadas++;
                                                    }
                                                    else
                                                    {
                                                        bool acerta = false;
                                                        Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                        if (acerta)
                                                        {
                                                            jogadas++;
                                                        }
                                                    }
                                                    prosseguir = true;
                                                }
                                            }
                                        }
                                    }

                                    if (prosseguir == true)
                                    {
                                        foreach (PictureBox v in this.Controls)
                                        {
                                            if (v.Location.X == peca.Location.X)
                                            {
                                                if (v.Location.Y == peca.Location.Y + 130)
                                                {
                                                    if (v.Tag == null)
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            jogadas++;
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    foreach (PictureBox v in this.Controls)
                                    {
                                        if (v.Tag != null)
                                        {
                                            if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                            {
                                                if (v.Location.Y == peca.Location.Y + 65)
                                                {
                                                    if (v.Tag.ToString().Contains("branco"))
                                                    {
                                                        if (xecadora == null)
                                                        {
                                                            jogadas++;
                                                        }
                                                        else
                                                        {
                                                            bool acerta = false;
                                                            Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                            if (acerta)
                                                            {
                                                                jogadas++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                }

                            }
                        }
                        else if (peca.Tag.ToString().Contains("torre"))
                        {
                            string adversario;
                            if (peca.Tag.ToString().Contains("branco"))
                            {
                                adversario = "preto";
                            }
                            else
                            {
                                adversario = "branco";
                            }
                            bool acertaorei = false;
                            Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);

                            Jogadastorre(peca, adversario, acertaorei, pecainimiga, ref jogadas);

                        }
                        else if (peca.Tag.ToString().Contains("bispo"))
                        {
                            string adversario;
                            if (peca.Tag.ToString().Contains("branco"))
                            {
                                adversario = "preto";
                            }
                            else
                            {
                                adversario = "branco";
                            }
                            bool acertaorei = false;
                            Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);
                            Jogadasbispo(peca, adversario, acertaorei, pecainimiga, ref jogadas);

                        }
                        else if (peca.Tag.ToString().Contains("rainha"))
                        {
                            string adversario;
                            if (peca.Tag.ToString().Contains("branco"))
                            {
                                adversario = "preto";
                            }
                            else
                            {
                                adversario = "branco";
                            }
                            bool acertaorei = false;
                            Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);

                            Jogadastorre(peca, adversario, acertaorei, pecainimiga, ref jogadas);
                            Jogadasbispo(peca, adversario, acertaorei, pecainimiga, ref jogadas);
                        }
                        else if (peca.Tag.ToString().Contains("rei"))
                        {

                            string adversario = "";
                            if (peca.Tag.ToString().Contains("branco"))
                            {
                                adversario = "preto";
                            }
                            else
                            {
                                adversario = "branco";
                            }

                            Jogadasrei(peca, adversario, ref jogadas);


                        }
                    }
                }
            }
        }

        private void CClick(object sender, EventArgs e)
           {

               PictureBox peca = null;

               foreach (PictureBox v in this.Controls)
                {
                    if (sender.Equals(v))
                    {
                        peca = v; break;
                    }
                }

               if (peca.Tag != null)
                {
                    if (selecionoupeca == false)
                    {
                        selecionoupeca = true;
                    }
                    else
                    {
                        if (peca.BackColor == Color.Green)
                        {
                            PictureBox pecamovendo = null;
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.BackColor == Color.Orange)
                                {
                                    pecamovendo = v; break;
                                }

                            }
                            vez++;
                            if (anpassant != null)
                            {
                                if (vez - rodadaanpassant == 2)
                                {
                                    rodadaanpassant = 0;
                                    anpassant = null;
                                }
                            }
                            Moverpeca(peca, pecamovendo);
                            selecionoupeca = false;
                        foreach (PictureBox v in this.Controls)
                        {
                            if (v.Tag == null)
                            {
                                v.Enabled = false;
                            }
                            if (v.BackColor == Color.Green || v.BackColor == Color.Orange)
                            {
                                if (v.BackColor == Color.Green)
                                {
                                    v.Enabled = false;
                                }
                            }
                        }
                                Desabilitalita();
                        }
                        else
                        {
                        foreach (PictureBox v in this.Controls)
                        {
                            if (v.Tag == null)
                            {
                                v.Enabled = false;
                            }
                            if (v.BackColor == Color.Green || v.BackColor == Color.Orange)
                            {
                                if (v.BackColor == Color.Green)
                                {
                                    v.Enabled = false;
                                }
                            }
                        }
                        Tirarcores();
                        }
                    }
                }
               if (peca.Tag == null)
                {
                    PictureBox pecamovendo = null;
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.BackColor == Color.Orange)
                        {
                            pecamovendo = v; break;
                        }
                    }
                    vez++;
                    if (anpassant != null)
                    {
                        if (vez - rodadaanpassant == 2)
                        {
                            rodadaanpassant = 0;
                            anpassant = null;
                        }
                    }
                    Moverpeca(peca, pecamovendo);
                    selecionoupeca = false;
                    Desabilitalita();
                }
               Tirarcores();
               if (peca.Tag != null && selecionoupeca == true)
               {

                PictureBox pecainimiga = null;
                PictureBox rei = null;
                Acharpeca("rei", peca, ref rei);

               if (peca.Tag.ToString().Contains("cavalo"))
                {

                    peca.BackColor = Color.Orange;
                    int verticalcima = peca.Location.Y - 130;
                    int verticalbaixo = peca.Location.Y + 130;
                    int horizontalesq = peca.Location.X - 65;
                    int horizontaldir = peca.Location.X + 65;
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.Location.Y == verticalcima || v.Location.Y == verticalbaixo)
                        {
                            if (v.Location.X == horizontalesq || v.Location.X == horizontaldir)
                            {
                                if (v.Tag != null)
                                {
                                    if (peca.Tag.ToString().Contains("branco"))
                                    {
                                        if (v.Tag.ToString().Contains("preto"))
                                        {
                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, "preto", ref acerta, peca, ref pecainimiga);
                                                if (!acerta || v == pecainimiga)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (v.Tag.ToString().Contains("branco"))
                                        {

                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, "branco", ref acerta, peca, ref pecainimiga);

                                                if (!acerta || v == pecainimiga)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string adversario = "";
                                    if (peca.Tag.ToString().Contains("branco"))
                                    {
                                        adversario = "preto";
                                    }
                                    else
                                    {
                                        adversario = "branco";
                                    }
                                    if (xecadora == null)
                                    {
                                        bool acerta = false;
                                        Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                                        if (!acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;

                                        Checarsairxeque(v.Location.X, v.Location.Y, adversario, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                }

                            }
                        }
                    }

                    verticalcima = peca.Location.Y - 65;
                    verticalbaixo = peca.Location.Y + 65;
                    horizontalesq = peca.Location.X - 130;
                    horizontaldir = peca.Location.X + 130;
                    foreach (PictureBox v in this.Controls)
                    {
                        if (v.Location.Y == verticalcima || v.Location.Y == verticalbaixo)
                        {
                            if (v.Location.X == horizontalesq || v.Location.X == horizontaldir)
                            {
                                if (v.Tag != null)
                                {
                                    if (peca.Tag.ToString().Contains("branco"))
                                    {
                                        if (v.Tag.ToString().Contains("preto"))
                                        {
                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, "preto", ref acerta, peca, ref pecainimiga);

                                                if (!acerta || v == pecainimiga)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (v.Tag.ToString().Contains("branco"))
                                        {
                                            if (xecadora == null)
                                            {
                                                bool acerta = false;
                                                Checarcasa(rei.Location.X, rei.Location.Y, "branco", ref acerta, peca, ref pecainimiga);

                                                if (!acerta || v == pecainimiga)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string adversario = "";
                                    if (peca.Tag.ToString().Contains("branco"))
                                    {
                                        adversario = "preto";
                                    }
                                    else
                                    {
                                        adversario = "branco";
                                    }

                                    if (xecadora == null)
                                    {
                                        bool acerta = false;
                                        Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acerta, peca, ref pecainimiga);

                                        if (!acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        bool acerta = false;

                                        Checarsairxeque(v.Location.X, v.Location.Y, adversario, ref acerta, ref xecadora, ref direcaoxeque);
                                        if (acerta)
                                        {
                                            v.BackColor = Color.Green;
                                            v.Enabled = true;
                                        }
                                    }

                                }
                            }
                        }

                    }
                }
               else if (peca.Tag.ToString().Contains("peao"))
                {

                    string adversario;
                    if (peca.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                    else
                    {
                        adversario = "branco";
                    }
                    bool acertaorei = false;
                    Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);

                    peca.BackColor = Color.Orange;
                    if (peca.Tag.ToString().Contains("mexeu"))
                    {
                        if (peca.Tag.ToString().Contains("branco"))
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.X == peca.Location.X)
                                {
                                    if (v.Location.Y == peca.Location.Y - 65)
                                    {
                                        if (v.Tag == null)
                                        {
                                            if (xecadora == null)
                                            {
                                                if (!acertaorei)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                    {
                                        if (v.Location.Y == peca.Location.Y - 65)
                                        {
                                            if (v.Tag.ToString().Contains("preto"))
                                            {
                                                if (xecadora == null)
                                                {
                                                    if (!acertaorei || v == pecainimiga)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        else
                        {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.X == peca.Location.X)
                                {
                                    if (v.Location.Y == peca.Location.Y + 65)
                                    {
                                        if (v.Tag == null)
                                        {
                                            if (xecadora == null)
                                            {
                                                if (!acertaorei)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                    {
                                        if (v.Location.Y == peca.Location.Y + 65)
                                        {
                                            if (v.Tag.ToString().Contains("branco"))
                                            {
                                                if (xecadora == null)
                                                {
                                                    if (!acertaorei || v == pecainimiga)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        if (anpassant != null && !acertaorei)
                        {
                          if(xecadora == null || xecadora == anpassant)
                          {
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Location.Y == peca.Location.Y)
                                    {
                                        if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                        {
                                            if (v == anpassant)
                                            {
                                                if (peca.Tag.ToString().Contains("branco"))
                                                {
                                                    foreach (PictureBox v2 in this.Controls)
                                                    {
                                                        if (v2.Tag == null)
                                                        {
                                                            if (v2.Location.X == v.Location.X)
                                                            {
                                                                if (v2.Location.Y == v.Location.Y - 65)
                                                                {
                                                                    v2.BackColor = Color.Green;
                                                                    v2.Enabled = true;
                                                                    daranpassant = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (PictureBox v2 in this.Controls)
                                                    {
                                                        if (v2.Tag == null)
                                                        {
                                                            if (v2.Location.X == v.Location.X)
                                                            {
                                                                if (v2.Location.Y == v.Location.Y + 65)
                                                                {
                                                                    v2.BackColor = Color.Green;
                                                                    v2.Enabled = true;
                                                                    daranpassant = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                          }
                        }
                    }
                    else
                    {
                        if (peca.Tag.ToString().Contains("branco"))
                        {
                            bool prosseguir = false;
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.X == peca.Location.X)
                                {
                                    if (v.Location.Y == peca.Location.Y - 65)
                                    {
                                        if (v.Tag == null)
                                        {
                                            if (xecadora == null)
                                            {
                                                v.BackColor = Color.Green;
                                                v.Enabled = true;
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            prosseguir = true;
                                        }
                                    }
                                }
                            }

                            if (prosseguir == true)
                            {
                                foreach (PictureBox v in this.Controls)
                                {
                                    if (v.Location.X == peca.Location.X)
                                    {
                                        if (v.Location.Y == peca.Location.Y - 130)
                                        {
                                            if (v.Tag == null)
                                            {
                                                if (xecadora == null)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                    {
                                        if (v.Location.Y == peca.Location.Y - 65)
                                        {
                                            if (v.Tag.ToString().Contains("preto"))
                                            {
                                                if (xecadora == null)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "preto", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        else
                        {
                            bool prosseguir = false;
                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Location.X == peca.Location.X)
                                {
                                    if (v.Location.Y == peca.Location.Y + 65)
                                    {
                                        if (v.Tag == null)
                                        {
                                            if (xecadora == null)
                                            {
                                                v.BackColor = Color.Green;
                                                v.Enabled = true;
                                            }
                                            else
                                            {
                                                bool acerta = false;
                                                Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                if (acerta)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                            }
                                            prosseguir = true;
                                        }
                                    }
                                }
                            }

                            if (prosseguir == true)
                            {
                                foreach (PictureBox v in this.Controls)
                                {
                                    if (v.Location.X == peca.Location.X)
                                    {
                                        if (v.Location.Y == peca.Location.Y + 130)
                                        {
                                            if (v.Tag == null)
                                            {
                                                if (xecadora == null)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            foreach (PictureBox v in this.Controls)
                            {
                                if (v.Tag != null)
                                {
                                    if (v.Location.X == peca.Location.X - 65 || v.Location.X == peca.Location.X + 65)
                                    {
                                        if (v.Location.Y == peca.Location.Y + 65)
                                        {
                                            if (v.Tag.ToString().Contains("branco"))
                                            {
                                                if (xecadora == null)
                                                {
                                                    v.BackColor = Color.Green;
                                                    v.Enabled = true;
                                                }
                                                else
                                                {
                                                    bool acerta = false;
                                                    Checarsairxeque(v.Location.X, v.Location.Y, "branco", ref acerta, ref xecadora, ref direcaoxeque);
                                                    if (acerta)
                                                    {
                                                        v.BackColor = Color.Green;
                                                        v.Enabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }

                    }
                }
               else if (peca.Tag.ToString().Contains("torre"))
                {

                    peca.BackColor = Color.Orange;
                    string adversario;
                    if (peca.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                    else
                    {
                        adversario = "branco";
                    }
                    bool acertaorei = false;
                    Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);

                    Mexertorre(peca, adversario, acertaorei, pecainimiga);

                }
               else if (peca.Tag.ToString().Contains("bispo"))
                {
                    peca.BackColor = Color.Orange;
                    string adversario;
                    if (peca.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                    else
                    {
                        adversario = "branco";
                    }
                    bool acertaorei = false;
                    Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);
                    Mexerbispo(peca, adversario, acertaorei, pecainimiga);

                }
               else if (peca.Tag.ToString().Contains("rainha"))
                {
                    peca.BackColor = Color.Orange;
                    string adversario;
                    if (peca.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                    else
                    {
                        adversario = "branco";
                    }
                    bool acertaorei = false;
                    Checarcasa(rei.Location.X, rei.Location.Y, adversario, ref acertaorei, peca, ref pecainimiga);

                    Mexertorre(peca, adversario, acertaorei, pecainimiga);
                    Mexerbispo(peca, adversario, acertaorei, pecainimiga);
                }
               else if (peca.Tag.ToString().Contains("rei"))
               {
                       peca.BackColor = Color.Orange;            

                   string adversario = "";
                   if (peca.Tag.ToString().Contains("branco"))
                    {
                        adversario = "preto";
                    }
                   else
                    {
                        adversario = "branco";
                    }

                   Mexerrei(peca, adversario);


               }

               }
           }
       }
   }
