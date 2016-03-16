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
    public partial class AdminPlayers : Form
    {
        string admin;
        int maxPoints;

        public AdminPlayers(int PointsToWin, string name)
        {
            admin = name;
            maxPoints = PointsToWin;

            InitializeComponent();
            fillCBplayers(CB_players);
        }

        public void fillCBplayers(ComboBox cb)
        {
            List<string> names = Player.get();

            cb.Items.Clear();
            for (int i = 0; i < names.Count; i++)
                if (names[i] != admin)
                    cb.Items.Add(names[i]);

            cb.SelectedIndex = 0;
            Update();
        }

        private void BT_add_Click(object sender, EventArgs e)
        {
            AddModPlayers form = new AddModPlayers(maxPoints);
            form.ShowDialog();

            fillCBplayers(CB_players);
        }

        private void BT_modify_Click(object sender, EventArgs e)
        {
            AddModPlayers form = new AddModPlayers(maxPoints, CB_players.SelectedItem.ToString());
            form.ShowDialog();

            fillCBplayers(CB_players);
        }

        private void BT_delete_Click(object sender, EventArgs e)
        {
            Player.remove(CB_players.Text);
            fillCBplayers(CB_players);
        }
    }
}
