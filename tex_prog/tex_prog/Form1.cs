using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tex_prog
{
    public partial class Form1 : Form
    {
		teploboat windowBoat;
		Direction direction;
		public Form1()
		{
			InitializeComponent();
		}
		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxBoat.Width, pictureBoxBoat.Height);
			Graphics g = Graphics.FromImage(bmp);
			windowBoat.DrawTransport(g);
			pictureBoxBoat.Image = bmp;
		}
		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Random rand = new Random();
			windowBoat = new teploboat();
			windowBoat.SetPosition(rand.Next(pictureBoxBoat.Width), rand.Next(pictureBoxBoat.Height), pictureBoxBoat.Width, pictureBoxBoat.Height);
			windowBoat.Init(5, 10, Color.LightCoral, Color.LightBlue, true, true, true);
			Draw();
		}
		private void buttonMove_Click(object sender, EventArgs e)
		{
			string name = (sender as Button).Name;
			switch (name)
			{
				case "buttonUp":
					windowBoat.MoveTransport(Direction.Up);
					break;
				case "buttonDown":
					windowBoat.MoveTransport(Direction.Down);
					break;
				case "buttonLeft":
					windowBoat.MoveTransport(Direction.Left);
					break;
				case "buttonRight":
					windowBoat.MoveTransport(Direction.Right);
					break;
			}
			Draw();
		}
	}
}
