using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaCrack
{
    public partial class AddModPlayers : Form
    {
        public AddModPlayers()
        {
            InitializeComponent();
            fillComboBoxes();
        }

        public AddModPlayers(string name)
        {
            InitializeComponent();

            TB_name.Text = name;
            TB_name.Enabled = false;
            TB_name.ForeColor = Color.White;

            BT_accept.Text = "Modifier";
            Text = "Modifier un joueur";
            LB_title.Text = "Modification d'un joueur";
            
            if (Player.isAdmin(name))
            {
                BT_admin.BackgroundImage = Properties.Resources.correct;
                BT_admin.Tag = "yes";
            }

            fillComboBoxes();
            setComboBoxes();
        }

        private void setComboBoxes()
        {
            for (int i = 0; i < Program.categories.Count; i++)
            {
                string category = Program.categories[i].ToLower().Replace('é', 'e');
                ((ComboBox)Controls["CB_" + category]).SelectedIndex = Points.get(category, TB_name.Text);
            }

            Update();
        }

        private void fillComboBoxes()
        {
            for (int i = 0; i < Program.categories.Count; i++)
            {
                for (int j = 0; j <= Program.maxPoints; j++)
                {
                    string category = Program.categories[i].ToLower().Replace('é', 'e');
                    ((ComboBox)Controls["CB_" + category]).Items.Add(j);
                    ((ComboBox)Controls["CB_" + category]).SelectedIndex = 0;
                }
            }

            Update();
        }

        private void BT_admin_Click(object sender, EventArgs e)
        {
            if (BT_admin.Tag.ToString() == "no")
            {
                BT_admin.BackgroundImage = Properties.Resources.correct;
                BT_admin.Tag = "yes";
            }
            else
            {
                BT_admin.BackgroundImage = Properties.Resources.incorrect;
                BT_admin.Tag = "no";
            }
            Update();
        }

        private void BT_accept_Click(object sender, EventArgs e)
        {
            if (validScore())
            {
                try
                {
                    if (BT_accept.Text == "Ajouter")
                        Player.add(TB_name.Text);

                    BT_accept.Text = "Modifier";
                }
                catch (Exception)
                {
                    MessageBox.Show("Nom de joueur déjà présent dans la base de données.");
                }

                if (BT_accept.Text == "Modifier")
                {
                    Player.setAdmin(TB_name.Text, BT_admin.Tag.ToString() == "yes");

                    for (int i = 0; i < Program.categories.Count; i++)
                    {
                        string category = Program.categories[i];
                        int points = int.Parse(Controls["CB_" + category.ToLower().Replace('é', 'e')].Text);
                        Points.set(category, TB_name.Text, points);
                    }

                    this.Close();
                }
            }
            else
                MessageBox.Show("Un joueur ne peut avoir le nombre maximal de points dans tout les catégories.");
        }

        private bool validScore()
        {
            for (int i = 0; i < Program.categories.Count; i++)
            {
                int points = int.Parse(Controls["CB_" + Program.categories[i].ToLower().Replace('é', 'e')].Text);
                if (points < Program.maxPoints)
                    return true;
            }

            return false;
        }
    }
}
