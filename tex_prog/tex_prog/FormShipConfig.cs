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
    public partial class FormShipConfig : Form
    {
        private Vehicle ship = null;
        private Action<Vehicle> eventAddShip;
        public FormShipConfig()
        {
            InitializeComponent();
            panel1.MouseDown += panelColor_MouseDown;
            panel2.MouseDown += panelColor_MouseDown;
            panel3.MouseDown += panelColor_MouseDown;
            panel4.MouseDown += panelColor_MouseDown;
            panel5.MouseDown += panelColor_MouseDown;
            panel6.MouseDown += panelColor_MouseDown;
            panel7.MouseDown += panelColor_MouseDown;
            panel8.MouseDown += panelColor_MouseDown;
            buttonCencel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void DrawShip()
        {
            if (ship != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxShip.Width, pictureBoxShip.Height);
                Graphics gr = Graphics.FromImage(bmp);
                ship.SetPosition(5, 5, pictureBoxShip.Width, pictureBoxShip.Height);
                ship.DrawTransport(gr);
                pictureBoxShip.Image = bmp;
            }
        }
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddShip == null)
            {
                eventAddShip = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddShip += ev;
            }
        }
        private void labelShip_MouseDown(object sender, MouseEventArgs e)
        {
            labelShip.DoDragDrop(labelShip.Text, DragDropEffects.Move | DragDropEffects.Copy);

        }

        private void labelTeploboat_MouseDown(object sender, MouseEventArgs e)
        {
            labelTeploboat.DoDragDrop(labelTeploboat.Text, DragDropEffects.Move | DragDropEffects.Copy);

        }

        private void panelShip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        private void panelShip_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный теплоход":
                    ship = new Ship((int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, 
                        Color.White);
                    break;
                case "Супер теплоход":
                    ship = new Teploboat((int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, 
                        Color.White, Color.Black, checkBoxWindow.Checked, checkBoxLine.Checked, 
                        checkBoxTrub.Checked);
                    break;
            }
            DrawShip();
        }
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void labelColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelColor_DragDrop(object sender, DragEventArgs e)
        {
            if (ship != null)
            {
                ship.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawShip();
            }
        }

        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (ship != null)
            {
                if (ship is Teploboat)
                {
                    (ship as Teploboat).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawShip();
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddShip?.Invoke(ship);
            Close();
        }
    }
}
