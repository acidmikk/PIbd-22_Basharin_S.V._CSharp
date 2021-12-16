using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsShip
{
    public partial class FormShip : Form
    {
		private ITransport ship;
		public FormShip()
		{
			InitializeComponent();
		}
		public void SetShip(ITransport ship)
		{
			this.ship = ship;
			Draw();
		}
			private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxBoat.Width, pictureBoxBoat.Height);
			Graphics g = Graphics.FromImage(bmp);
			ship?.DrawTransport(g);
			pictureBoxBoat.Image = bmp;
		}
		/*private void buttonCreateShip_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			ship = new Ship(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Honeydew);
			ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBoat.Width,
				pictureBoxBoat.Height);
			Draw();
		}
		private void buttonCreateSuperShip_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			ship = new Teploboat(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Honeydew, Color.DarkMagenta, true, true, true);
			ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBoat.Width,
				pictureBoxBoat.Height);
			Draw();
		}*/
		private void buttonMove_Click(object sender, EventArgs e)
		{
			string name = (sender as Button).Name;
			switch (name)
			{
				case "buttonUp":
					ship?.MoveTransport(Direction.Up);
					break;
				case "buttonDown":
					ship?.MoveTransport(Direction.Down);
					break;
				case "buttonLeft":
					ship?.MoveTransport(Direction.Left);
					break;
				case "buttonRight":
					ship?.MoveTransport(Direction.Right);
					break;
			}
			Draw();
		}
    }
}
