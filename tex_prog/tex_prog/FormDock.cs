using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WindowsFormsShip
{
    public partial class FormDock : Form
    {
        private readonly DockCollection dockCollection;
        private readonly Logger logger;
        public FormDock()
        {
            InitializeComponent();
            dockCollection = new DockCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            logger = LogManager.GetCurrentClassLogger();
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
            {
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
            logger.Info($"Добавили парковку {textBoxNewLevelName.Text}");
            dockCollection.AddDock(textBoxNewLevelName.Text);
            ReloadLevels();
        }
        private void buttonDelDock_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxDocks.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info($"Удалили парковку {listBoxDocks.SelectedItem.ToString()}");
                    dockCollection.DelDock(textBoxNewLevelName.Text);
                    ReloadLevels();
                }
            }
        }
        private void buttonSetShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                var formShipConfig = new FormShipConfig();
                formShipConfig.AddEvent(AddShip);
                formShipConfig.Show();
            }
        }
        private void AddShip(Vehicle ship)
        {
            if (ship != null && listBoxDocks.SelectedIndex > -1)
            {
                try
                {
                    if ((dockCollection[listBoxDocks.SelectedItem.ToString()]) + (ship))
                    {
                        Draw();
                        logger.Info($"Добавлен автомобиль {ship}");
                    }
                    else
                    {
                        MessageBox.Show("Технику не удалось поставить");
                    }
                    Draw();
                }
                catch (DockOverflowException ex)
                {
                    logger.Warn($"Попытка поставить технику в полное депо.");
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная ошибка при попытке поставить технику");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void buttonTakeShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1 && maskedTextBox1.Text != "")
            {
                try
                {
                    var ship = dockCollection[listBoxDocks.SelectedItem.ToString()] -
                        (Convert.ToInt32(maskedTextBox1.Text) - 1);
                    if (ship != null)
                    {
                        FormShip form = new FormShip();
                        form.SetShip(ship);
                        form.ShowDialog();
                        logger.Info($"Изъят автомобиль {ship} с места {maskedTextBox1.Text}");
                        Draw();
                    }
                }
                catch (DockNotFoundException ex)
                {
                    logger?.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная ошибка при попытке изъять технику");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void listBoxDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на парковку {listBoxDocks.SelectedItem.ToString()}");
            Draw();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dockCollection.SaveData(saveFileDialog1.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная неудачная попытка сохранения файла");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dockCollection.LoadData(openFileDialog1.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog1.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (FileNotFoundException ex)
                {
                    logger.Warn($"Попытка найти не существующий фаил для загрузки");
                    MessageBox.Show(ex.Message, "Фаил отсутсвует", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (FileFormatException ex)
                {
                    logger.Warn($"Попытка загрузки файла с неверным форматом");
                    MessageBox.Show(ex.Message, "Неверный формат файла", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (TypeLoadException ex)
                {
                    logger.Warn($"Попытка загрузки в депо неизвестного типа обЪекта(ов)");
                    MessageBox.Show(ex.Message, "Неверный тип загружаемого объекта", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная неудачная попытка загрузки файла");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
