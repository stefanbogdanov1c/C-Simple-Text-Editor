using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kolokvijum1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            openFileDlg.Title = "Otvorite fajl:";


            //ovde postavljamo filter koji ce se tip fajla otvoriti
            openFileDlg.Filter = "Rich Text Format|*.rtf|Text file|*.txt";

            //proveravamo greske
            try
            {
                //ukoliko je fajl otvoren
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    //ukoliko fajl ima ime
                    if (openFileDlg.FileName != "")
                    {
                        //u if-uu trazimo ekstenziju rtf, i ukoliko to jeste ekstenzija, ispisujemo tekst sa detaljima
                        if (Path.GetExtension(openFileDlg.FileName) == ".rtf")
                        {
                            richTextBox.LoadFile(openFileDlg.FileName, RichTextBoxStreamType.RichText);
                        }
                        //ukoliko ekstenzija nije rtf ispisujemo tekst bez ikakvih detalja
                        else
                        {
                            richTextBox.LoadFile(openFileDlg.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDlg.Title = "Gde zelite da sacuvate fajl?";

            //zadaje da mozemo da sacuvamo fajl samo kao rtf fajl

            saveFileDlg.Filter = " Rich Text Format|*.rtf ";

            //cuvanje u fajl
            try {
                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    //kao argument uzima putanju gde ce se fajl sacuvati
                    richTextBox.SaveFile(saveFileDlg.FileName);


                }
            }
            catch(Exception greska)
            {
                MessageBox.Show(greska.ToString()); ;
            }
        }


        //odabir fonta
        private void selectFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionFont = fontDlg.Font;

                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString()); ;
            }
        }

        //bold
        private void fontBoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Bold);
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString()); ;
            }
        }

        //italic
        private void fontItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Italic);
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString()); ;
            }
        }


        //odabir boje
        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionColor = colorDlg.Color;
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString()); ;
            }
        }

        private void btnSearchReplace_Click(object sender, EventArgs e)
        {
            //pretvaramo vrednost iz textboxova u string kako bi se njima moglo manipulisati

            //textbox koji trazimo
            string search = txtSearch.Text.Trim();

            //textbox kojim menjamo
            string replace = txtReplace.Text.Trim();

            //richtextbox u kome se sav text nalazi
            string text = richTextBox.Text.Trim();

            //tekst koji ce kasnije biti prikazan
            string replaced;

            try
            {
                //ako je richtextbox prazan
                if (text == "")
                {
                    MessageBox.Show("Richtext mora imati neki sadrzaj");
                    richTextBox.Focus();
                }
                //ako je search prazan
                else if (search == "")
                {
                    MessageBox.Show("search prazan");
                    txtSearch.Focus();
                    
                }
                //ako je replace prazan
                else if (replace == "")
                {
                    MessageBox.Show("replace prazan");
                    txtReplace.Focus();

                }
                //svi uslovi su ispunjeni
                else
                {
                    replaced = text.Replace(search, replace);
                    richTextBox.Text = replaced;

                }

            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.ToString());
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ilazak iz aplikacije
            try
            {
                Application.Exit();
            }
            catch (Exception greska){
                MessageBox.Show(greska.ToString());
            }
        }
    }
}
