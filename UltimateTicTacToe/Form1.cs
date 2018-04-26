using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateTicTacToe
{
    public partial class Form1 : Form
    {
        int playerXPoints;
        int playerOPoints;
        int turn;
        int currentBox;
        List<FlowLayoutPanel> allPanels;
        List<FlowLayoutPanel> wonPanels;
        List<List<Button>> buttons;
        List<Button> usedButtons;
        public Form1()
        {
            InitializeComponent();
            initializeGame();
        }

        private void initializeGame() {
            turn = 1;
            playerXPoints = 0;
            playerOPoints = 0;
            currentBox = 0;

            displayScore();

            usedButtons = new List<Button>();
            buttons = new List<List<Button>>();
            wonPanels = new List<FlowLayoutPanel>();
            allPanels = new List<FlowLayoutPanel>();

            loadPannels(allPanels);
            loadButtons(buttons);
            resetButtons();
            clearPanels();
        }

        private void resetButtons() {
            foreach (List<Button> l in buttons) {
                foreach (Button b in l) {
                    b.Enabled = true;
                    b.Text = "";
                }
            }
        }

        private void printButtons() {
            foreach (List<Button> l in buttons) {
                Debug.WriteLine("/n");
                foreach (Button b in l) {
                    Debug.WriteLine(b.Name + " ");
                }
            }
        }

        private void buttonClikced(Button curr)
        {
            int currPanel = parsePanelNum(curr.Name) -1;
            int nextPanel = parseNextPanel(curr.Name) -1;
            int buttonPanel = parsePanelNum(curr.Name)-1 ;

            if (isPanelHighlighted(buttonPanel) || turn== 1)
            {
                updateButton(curr);
                curr.Enabled = false;

                updateScore(currPanel);
                displayScore();

                highlightPanels(currPanel, nextPanel);

                currentBox = nextPanel;
                incrementTurn();

                checkForWinner();
            }
        }

        private FlowLayoutPanel getPanel(int num) {
            return allPanels[num];
        }

        private bool buttonsDisabled(Button b1, Button b2, Button b3) {
            return !b1.Enabled && !b2.Enabled && !b3.Enabled;   
        }

        private void updateScore(int panel) {
            List<Button> b = this.buttons[panel];
            FlowLayoutPanel p = getPanel(panel);

            // horizontal 1
            if (buttonsDisabled(b[0],b[1],b[2]) &&  b[0].Text.Equals(b[1].Text) && b[0].Text.Equals(b[2].Text) && checkButtonsUsage(b[0], b[1], b[2])) {
                if (b[0].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[0]);
                usedButtons.Add(b[1]);
                usedButtons.Add(b[2]);

                wonPanels.Add(p);
            }

            // horizontal 2
            if (buttonsDisabled(b[3], b[4], b[5]) && b[3].Text.Equals(b[4].Text) && b[3].Text.Equals(b[5].Text) && checkButtonsUsage(b[3], b[4], b[5]))
            {
                if (b[3].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[3]);
                usedButtons.Add(b[4]);
                usedButtons.Add(b[5]);

                wonPanels.Add(p);
            }

            // horizontal 3;
            if (buttonsDisabled(b[6], b[7], b[8]) && b[6].Text.Equals(b[7].Text) && b[6].Text.Equals(b[8].Text) && checkButtonsUsage(b[6], b[7], b[8]))
            {
                if (b[6].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[6]);
                usedButtons.Add(b[7]);
                usedButtons.Add(b[8]);

                wonPanels.Add(p);
            }

            // vertical 1
            if (buttonsDisabled(b[0], b[3], b[6]) && b[0].Text.Equals(b[3].Text) && b[0].Text.Equals(b[6].Text) && checkButtonsUsage(b[0], b[3], b[6]))
            {
                if (b[0].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[0]);
                usedButtons.Add(b[3]);
                usedButtons.Add(b[6]);

                wonPanels.Add(p);
            }

            // vertical 2
            if (buttonsDisabled(b[1], b[4], b[7]) && b[1].Text.Equals(b[4].Text) && b[1].Text.Equals(b[7].Text) && checkButtonsUsage(b[1], b[4], b[7]))
            {
                if (b[1].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[1]);
                usedButtons.Add(b[4]);
                usedButtons.Add(b[7]);

                wonPanels.Add(p);
            }

            // vertical 3
            if (buttonsDisabled(b[2], b[5], b[8]) && b[2].Text.Equals(b[5].Text) && b[2].Text.Equals(b[8].Text) && checkButtonsUsage(b[2], b[5], b[8]))
            {
                if (b[2].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[2]);
                usedButtons.Add(b[5]);
                usedButtons.Add(b[8]);

                wonPanels.Add(p);
            }

            // diagonal 1
            if (buttonsDisabled(b[0], b[4], b[8]) && b[0].Text.Equals(b[4].Text) && b[0].Text.Equals(b[8].Text) && checkButtonsUsage(b[0], b[4], b[8]))
            {
                if (b[0].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[0]);
                usedButtons.Add(b[4]);
                usedButtons.Add(b[8]);

                wonPanels.Add(p);
            }


            // diagonal 2
            if (buttonsDisabled(b[2], b[4], b[6]) && b[2].Text.Equals(b[4].Text) && b[2].Text.Equals(b[6].Text) && checkButtonsUsage(b[2], b[4], b[6]))
            {
                if (b[2].Text.Equals("X"))
                    playerXPoints++;
                else
                    playerOPoints++;

                usedButtons.Add(b[2]);
                usedButtons.Add(b[4]);
                usedButtons.Add(b[6]);

                wonPanels.Add(p);
            }
        }

        private void displayScore() {
            scoreX.Text = playerXPoints +"";
            scoreO.Text = playerOPoints + "";
        }

        private void checkForWinner() {
            if (playerXPoints == 3)
            {
                DialogResult dr = MessageBox.Show("Player X won", "Result", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    initializeGame();
                    return;
                }
            }
            if (playerOPoints == 3) {
                DialogResult dr = MessageBox.Show("Player O won", "Result", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    initializeGame();
                    return;
                }
            }
        }

        private bool checkButtonsUsage(Button b1, Button b2, Button b3) {
            if (!usedButtons.Contains(b1) && !usedButtons.Contains(b2) && !usedButtons.Contains(b3))
                return true;
            return false;
        }

        public bool isPanelHighlighted(int num) {
            if (allPanels[num].BackColor == SystemColors.ControlDark)
                return true;
            return false;
        }

        public int parsePanelNum(String button) {
            return int.Parse(button[6]+"");
        }
        public void incrementTurn() {
            turn++;
        }

        public void updateButton(Button button) {
            button.ForeColor = Color.Red;
            if (turn % 2 == 0)
                button.Text = "O";
            else
                button.Text = "X";
        }
        public int parseNextPanel(String button)
        {
            return int.Parse(button[7] + "");
        }

        public void highlightPanels(int curr, int next)
        {
            FlowLayoutPanel currentPanel = getPanel(curr);
            FlowLayoutPanel nextPanel = getPanel(next);

            clearPanels();

            if (wonPanels.Contains(nextPanel))
            {
                setPanels();
            }
            else
            {
                currentPanel.BackColor = SystemColors.Control;
                nextPanel.BackColor = SystemColors.ControlDark;
            }
        }

        public void clearPanels() {
            foreach (Panel p in allPanels) {
                p.BackColor = SystemColors.Control;
            }
        }

        public void setPanels() {
            foreach (Panel p in allPanels) {
                p.BackColor = SystemColors.ControlDark;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button84_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button86_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button87_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button89_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button92_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button93_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button94_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button95_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button96_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button97_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button98_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void button99_Click(object sender, EventArgs e)
        {
            buttonClikced((Button)sender);
        }

        private void loadPannels(List<FlowLayoutPanel> panels)
        {
            panels.Add(panel1);
            panels.Add(panel2);
            panels.Add(panel3);
            panels.Add(panel4);
            panels.Add(panel5);
            panels.Add(panel6);
            panels.Add(panel7);
            panels.Add(panel8);
            panels.Add(panel9);
        }



        private void loadButtons(List<List<Button>> b)
        {
            List<Button> b1 = new List<Button>();
            List<Button> b2 = new List<Button>();
            List<Button> b3 = new List<Button>();
            List<Button> b4 = new List<Button>();
            List<Button> b5 = new List<Button>();
            List<Button> b6 = new List<Button>();
            List<Button> b7 = new List<Button>();
            List<Button> b8 = new List<Button>();
            List<Button> b9 = new List<Button>();

            b1.Add(button11);
            b1.Add(button12);
            b1.Add(button13);
            b1.Add(button14);
            b1.Add(button15);
            b1.Add(button16);
            b1.Add(button17);
            b1.Add(button18);
            b1.Add(button19);
            b.Add(b1);

            b2.Add(button21);
            b2.Add(button22);
            b2.Add(button23);
            b2.Add(button24);
            b2.Add(button25);
            b2.Add(button26);
            b2.Add(button27);
            b2.Add(button28);
            b2.Add(button29);
            b.Add(b2);

            b3.Add(button31);
            b3.Add(button32);
            b3.Add(button33);
            b3.Add(button34);
            b3.Add(button35);
            b3.Add(button36);
            b3.Add(button37);
            b3.Add(button38);
            b3.Add(button39);
            b.Add(b3);

            b4.Add(button41);
            b4.Add(button42);
            b4.Add(button43);
            b4.Add(button44);
            b4.Add(button45);
            b4.Add(button46);
            b4.Add(button47);
            b4.Add(button48);
            b4.Add(button49);
            b.Add(b4);

            b5.Add(button51);
            b5.Add(button52);
            b5.Add(button53);
            b5.Add(button54);
            b5.Add(button55);
            b5.Add(button56);
            b5.Add(button57);
            b5.Add(button58);
            b5.Add(button59);
            b.Add(b5);

            b6.Add(button61);
            b6.Add(button62);
            b6.Add(button63);
            b6.Add(button64);
            b6.Add(button65);
            b6.Add(button66);
            b6.Add(button67);
            b6.Add(button68);
            b6.Add(button69);
            b.Add(b6);

            b7.Add(button71);
            b7.Add(button72);
            b7.Add(button73);
            b7.Add(button74);
            b7.Add(button75);
            b7.Add(button76);
            b7.Add(button77);
            b7.Add(button78);
            b7.Add(button79);
            b.Add(b7);

            b8.Add(button81);
            b8.Add(button82);
            b8.Add(button83);
            b8.Add(button84);
            b8.Add(button85);
            b8.Add(button86);
            b8.Add(button87);
            b8.Add(button88);
            b8.Add(button89);
            b.Add(b8);


            b9.Add(button91);
            b9.Add(button92);
            b9.Add(button93);
            b9.Add(button94);
            b9.Add(button95);
            b9.Add(button96);
            b9.Add(button97);
            b9.Add(button98);
            b9.Add(button99);
            b.Add(b9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializeGame();
        }
    }
}
