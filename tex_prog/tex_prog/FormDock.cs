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
    public partial class FormDock : Form
    {
        private readonly DockCollection dockCollection;
        public FormDock()
        {
            InitializeComponent();
            dockCollection = new DockCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            Draw();
        }
        private void ReloadLevels()
        {
            int index = listBoxDocks.SelectedIndex;
            listBoxDocks.Items.Clear();
            for (int i = 0; i < dockCollection.Keys.Count; i++)
            {
                listBoxDocks.Items.Add(dockCollection.Keys[i]);
            }
            if (listBoxDocks.Items.Count > 0 && (index == -1 || index >=
           listBoxDocks.Items.Count))
            {
                listBoxDocks.SelectedIndex = 0;
            }
            else if (listBoxDocks.Items.Count > 0 && index > -1 && index <
           listBoxDocks.Items.Count)
            {
                listBoxDocks.SelectedIndex = index;
            }
        }
        private void Draw()
        {
            if (listBoxDocks.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
             //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу
             //listBox)
                 Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                dockCollection[listBoxDocks.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }
        private void buttonAddDock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dockCollection.AddDock(textBoxNewLevelName.Text);
            ReloadLevels();
        }
        private void buttonDelDock_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку{ listBoxDocks.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dockCollection.DelDock(textBoxNewLevelName.Text);
                    ReloadLevels();
                }
            }
        }
        private void buttonSetShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var ship = new Ship(100, 1000, dialog.Color);
                    if ((dockCollection[listBoxDocks.SelectedItem.ToString()] + ship) != -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }
        private void buttonSetSuperShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var ship = new Teploboat(100, 1000, dialog.Color, dialogDop.Color,
                       true, true, true);
                        if ((dockCollection[listBoxDocks.SelectedItem.ToString()] + ship) != -1)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Парковка переполнена");
                        }
                    }
                }
            }
        }
        private void buttonTakeShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1 && maskedTextBox1.Text != "")
            {
                var car = dockCollection[listBoxDocks.SelectedItem.ToString()] -
               Convert.ToInt32(maskedTextBox1.Text);
                if (car != null)
                {
                    FormShip form = new FormShip();
                    form.SetShip(car);
                    form.ShowDialog();
                }
                Draw();
            }
        }
        private void listBoxDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
