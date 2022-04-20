using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections;

namespace JsonPokemon
{
    public partial class Form1 : Form
    {
        public int m_current = 0;
        private ArrayList Pokes = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            var p = new Pokemon
            {
                name = nametextBox.Text,
                type = typetextBox.Text,
                move = movetextBox.Text,
                HP = HPtextBox.Text,
                Height = HeighttextBox.Text,
                Weight = Weighttextbox.Text,
                decrpition = descriptiontextBox.Text,
                picture = pokemonpictureBox.ImageLocation
            };

          

            Pokes.Add(p);
            StreamWriter outfile = File.CreateText("Pokemon.JSON");
            foreach (var item in Pokes)
            {
                outfile.WriteLine(JsonSerializer.Serialize(item));
            }

            outfile.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inFile = File.OpenText("Pokemon.JSON");

            while (inFile.Peek() != -1)
            {
                string pString = inFile.ReadLine();
                Pokemon p = JsonSerializer.Deserialize<Pokemon>(pString);
                Pokes.Add(p);
            }
            show();

        }

        public void show()
        {
            Pokemon p = (Pokemon)Pokes[m_current];
            nametextBox.Text = p.name;
            typetextBox.Text = p.type;
            movetextBox.Text = p.move;
            HPtextBox.Text = p.HP;
            HeighttextBox.Text = p.Height;
            Weighttextbox.Text = p.Weight;
            descriptiontextBox.Text = p.decrpition;
            pokemonpictureBox.ImageLocation = p.picture;

        }

        private void previousbutton_Click(object sender, EventArgs e)
        {
            if (m_current == 0)
            {
                m_current = Pokes.Count - 1;
            }
            else if (m_current > 0)
            {
                m_current--;
            }
            Show();

        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            if (Pokes.Count == m_current + 1)
            {
                m_current = 0;
            }
            else if (m_current < Pokes.Count)
            {
                m_current++;
            }
            Show();

        }

        private void firstbutton_Click(object sender, EventArgs e)
        {

            Show();
        }

        private void lastbutton_Click(object sender, EventArgs e)
        {
            m_current = Pokes.Count - 1;
            Show();

        }
        private void AddNewbutton_Click(object sender, EventArgs e)
        {
            save();
            Clear();

        }

        private void loadbutton_Click(object sender, EventArgs e)
        {

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            Pokes.Remove(Pokes[m_current]);
            m_current =- 1;
            Show();
            save();

        }
        private void Clear()
        {
            nametextBox.Clear();
            typetextBox.Clear();
            movetextBox.Clear();
            descriptiontextBox.Clear();
            HPtextBox.Clear();
            pokemonpictureBox.Image = null;
        }
        private void save()
        {

        }

        private void pokemonpictureBox_Click(object sender, EventArgs e)
        {
        }
    }

}
