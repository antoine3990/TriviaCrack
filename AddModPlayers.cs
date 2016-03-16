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
        int maxPoints;

        public AddModPlayers(int pointsToWin)
        {
            InitializeComponent();
            maxPoints = pointsToWin;
            fillComboBoxes();
        }

        public AddModPlayers(int pointsToWin, string name)
        {
            InitializeComponent();

            TB_name.Text = name;
            TB_name.Enabled = false;
            TB_name.ForeColor = Color.White;
            maxPoints = pointsToWin;

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
            if (BT_accept.Text == "Modifier")
            {

            }
            else
            {

            }
        }
    }
}
