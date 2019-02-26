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
        Game game = new Game();

        public VoltorbFlipForm()
        {
            InitializeComponent();
        }

        private void VoltorbFlipForm_Load(object sender, EventArgs e)
        {            
            game.start();
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

            tile.Enabled = false;
            getTileCoord(ref tile);
        }
    }
}
