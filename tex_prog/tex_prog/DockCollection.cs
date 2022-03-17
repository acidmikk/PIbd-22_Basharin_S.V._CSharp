using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsShip
{
    class DockCollection
    {
        readonly Dictionary<string, Dock<Vehicle>> dockStages;
        public List<string> Keys => dockStages.Keys.ToList();
        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private readonly char separator = ':';
        public DockCollection(int pictureWidth, int pictureHeight)
        {
            dockStages = new Dictionary<string, Dock<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        public void AddDock(string name)
        {
            if (!dockStages.ContainsKey(name))
                dockStages.Add(name, new Dock<Vehicle>(pictureWidth, pictureHeight));
        }
        public void DelDock(string name)
        {
            if (dockStages.ContainsKey(name))
                dockStages.Remove(name);
        }
        public Dock<Vehicle> this[string ind]
        {
            get
            {
                if (dockStages.ContainsKey(ind))
                    return dockStages[ind];
                return null;
            }
        }

        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }


        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
            {
                sw.WriteLine("DockCollection");
                foreach (var level in dockStages)
                {
                    sw.WriteLine("Dock" + separator + level.Key);
                    foreach (ITransport ship in level.Value)
                    {
                        //Записываем тип мшаины
                        if (ship.GetType().Name == "Ship")
                        {
                            sw.WriteLine("Ship" + separator);
                        }
                        else if (ship.GetType().Name == "Teploboat")
                        {
                            sw.WriteLine("Teploboat" + separator);
                        }
                        //Записываемые параметры
                        sw.Write(ship);
                    }
                }
            }
        }

        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                if (sr.ReadLine().Contains("DockCollection"))
                {
                    dockStages.Clear();
                }
                else
                {
                    throw new FileFormatException("Неверный формат файла");
                }
                Vehicle transport = null;
                string key = string.Empty;
                string line;
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    if (line.Contains("Dock"))
                    {
                        key = line.Split(separator)[1];
                        dockStages.Add(key, new Dock<Vehicle>(pictureWidth, pictureHeight));
                    }
                    else if (line.Contains(separator))
                    {
                        if (line.Contains("Ship"))
                        {
                            transport = new Ship(line.Split(separator)[1]);
                        }
                        else if (line.Contains("Teploboat"))
                        {
                            transport = new Teploboat(line.Split(separator)[1]);
                        }
                        if (!(dockStages[key] + transport))
                        {
                            throw new TypeLoadException("Не удалось загрузить корабль в док");
                        }
                    }
                }
            }
        }
    }
}
