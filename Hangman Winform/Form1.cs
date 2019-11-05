using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman_Winform
{
    public partial class Form1 : Form
    {

        private string randomWord = "";

        private string displayWord = "";

        int wrongGuesses = 0;


        public Form1()
        {
            InitializeComponent();
            displayWord = GetWord();
            WordLabel.Text = displayWord;
        }
        enum parts
        {
            post,
            bar,
            line,
            head,
            torso,
            leftArm,
            rightArm,
            leftLeg,
            rightLeg
        }
        void Drawing(parts part)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.DimGray, 7);
            if (part == parts.post)
            {
                g.DrawLine(p, new Point(130, 300), new Point(130, 5));
            }
            else if (part == parts.bar)
            {
                g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            }
            else if (part == parts.line)
            {
                g.DrawLine(p, new Point(60, 0), new Point(60, 40));
            }
            else if (part == parts.head)
            {
                g.DrawEllipse(p, new Rectangle(40, 40, 40, 40));
            }
            else if (part == parts.torso)
            {
                g.DrawLine(p, new Point(60, 80), new Point(60, 170));
            }
            else if (part == parts.leftArm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(30, 120));
            }
            else if (part == parts.rightArm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(90, 120));
            }
            else if (part == parts.leftLeg)
            {
                g.DrawLine(p, new Point(60, 160), new Point(30, 210));
            }
            else if (part == parts.rightLeg)
            {
                g.DrawLine(p, new Point(60, 160), new Point(90, 210));
                var result = MessageBox.Show("You Lost.\nHow utterly disappointing.\nWould you like to play again?", "Hangman", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Restart();
                }

            }
        }

        private string GetWord()
        {
            Random word = new Random();
            string[] wordArray = new string[] { "COMPLICATED", "INORDINATE", "XENIAL", "FACETIOUS", "INSIDIOUS", "CRYPTIC", "LETHARGY", "SANGUINE" };

            randomWord = (wordArray[word.Next(0, wordArray.Length)]);
            displayWord = "";
            for (int i = 0; i < randomWord.Length; i++)
            {
                displayWord += "_ ";
            }

            return displayWord;
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            Button guess = sender as Button;
            guess.Enabled = false;
            GuessedLettersLabel.Text += guess.Text + " ";
            if (randomWord.Contains(guess.Text))
            {

                for (int index = 0; index < randomWord.Length; index++)
                {
                    if (randomWord[index].ToString() == guess.Text)
                    {
                        WordLabel.Text = WordLabel.Text.Remove(index * 2, 1);
                        WordLabel.Text = WordLabel.Text.Insert(index * 2, guess.Text);
                    }
                }
            }
            else
            {
                Drawing((parts)wrongGuesses);
                wrongGuesses++;
            }
            if (!WordLabel.Text.Contains("_"))
            {
                var result = MessageBox.Show("You Win!\nWould you like to play again?", "Hangman", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Restart();
                }
            }

        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Would you like to play again?", "Hangman", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                Application.Restart();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }    
    }       
}
