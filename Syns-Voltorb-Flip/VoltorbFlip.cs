using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syns_Voltorb_Flip
{
    public partial class VoltorbFlipForm : Form
    {
        Game game;

        public VoltorbFlipForm()
        {
            InitializeComponent();
            game = new Game(this);
        }

        private void VoltorbFlipForm_Load(object sender, EventArgs e)
        {
            setLblColors();
            game.start();
        }

        public void setLblColors()
        {
            voltorbRow0Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbRow1Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbRow2Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbRow3Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbRow4Lbl.BackColor = System.Drawing.Color.Transparent;

            voltorbCol0Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbCol1Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbCol2Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbCol3Lbl.BackColor = System.Drawing.Color.Transparent;
            voltorbCol4Lbl.BackColor = System.Drawing.Color.Transparent;

            pointSumRow0Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumRow1Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumRow2Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumRow3Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumRow4Lbl.BackColor = System.Drawing.Color.Transparent;

            pointSumCol0Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumCol1Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumCol2Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumCol3Lbl.BackColor = System.Drawing.Color.Transparent;
            pointSumCol4Lbl.BackColor = System.Drawing.Color.Transparent;
        }

        public void updatePointSums(int[] rowPointSums, int[] colPointSums)
        {
            pointSumRow0Lbl.Text = "Pts: " + rowPointSums[0];
            pointSumRow1Lbl.Text = "Pts: " + rowPointSums[1];
            pointSumRow2Lbl.Text = "Pts: " + rowPointSums[2];
            pointSumRow3Lbl.Text = "Pts: " + rowPointSums[3];
            pointSumRow4Lbl.Text = "Pts: " + rowPointSums[4];

            pointSumCol0Lbl.Text = "Pts: " + colPointSums[0];
            pointSumCol1Lbl.Text = "Pts: " + colPointSums[1];
            pointSumCol2Lbl.Text = "Pts: " + colPointSums[2];
            pointSumCol3Lbl.Text = "Pts: " + colPointSums[3];
            pointSumCol4Lbl.Text = "Pts: " + colPointSums[4];
        }

        // Uses the name of a tile to obtain its row/col for reference in the grid array.
        public void getTileCoord(ref Button tile)
        {
            int row = Convert.ToInt32(tile.Name.Substring(4, 1));
            int col = Convert.ToInt32(tile.Name.Substring(5));
            Console.WriteLine("Tile [" + row + ", " + col + "]");

            tile.Text = game.checkTile(row, col).ToString();
        }

        private void tileOnClick(object sender, EventArgs e)
        {
            Button tile = sender as Button; // Gets the button that was clicked, making this a universal onClick method.

            //tile.Enabled = false;
            getTileCoord(ref tile);
        }
    }
}
