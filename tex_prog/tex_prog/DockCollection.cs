using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsShip
{
    class DockCollection
    {
        readonly Dictionary<string, Parking<Vehicle>> dockStages;
        public List<string> Keys => dockStages.Keys.ToList();
        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private readonly char separator = ':';
        public DockCollection(int pictureWidth, int pictureHeight)
        {
            dockStages = new Dictionary<string, Parking<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        public void AddDock(string name)
        {
            if (!dockStages.ContainsKey(name))
                dockStages.Add(name, new Parking<Vehicle>(pictureWidth, pictureHeight));
        }
        public void DelDock(string name)
        {
            if (dockStages.ContainsKey(name))
                dockStages.Remove(name);
        }
        public Parking<Vehicle> this[string ind]
        {
            get
            {
                if (dockStages.ContainsKey(ind))
                    return dockStages[ind];
                return null;
            }
        }


        public bool SaveData(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
            {
                sw.WriteLine("DockCollection");
                foreach (var level in dockStages)
                {
                    sw.WriteLine("Dock" + separator + level.Key);
                    ITransport ship = null;
                    for (int i = 0; (ship = level.Value.GetNext(i)) != null; i++)
                    {
                        if (ship != null)
                        {
                            if (ship.GetType().Name == "Ship")
                            {
                                sw.WriteLine("Ship" + separator + ship);
                            }
                            if (ship.GetType().Name == "Teploboat")
                            {
                                sw.WriteLine("Teploboat" + separator + ship);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool SaveDock(string filename, string levelname)
        {
            if (!dockStages.ContainsKey(filename))
            {
                return false;
            }
            Parking<Vehicle> level = dockStages[levelname];
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
            {
                sw.WriteLine("Dock" + separator + levelname);
                ITransport ship = null;
                for (int i = 0; (ship = level.GetNext(i)) != null; i++)
                {
                    if (ship != null)
                    {
                        if (ship.GetType().Name == "Ship")
                        {
                            sw.WriteLine("Ship" + separator + ship);
                        }
                        if (ship.GetType().Name == "Teploboat")
                        {
                            sw.WriteLine("Teploboat" + separator + ship);
                        }
                    }
                }
            }
            return true;
        }

        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                if (sr.ReadLine().Contains("DockCollection"))
                {
                    dockStages.Clear();
                }
                else
                {
                    return false;
                }
                Vehicle transport = null;
                string key = string.Empty;
                string line;
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    if (line.Contains("Dock"))
                    {
                        key = line.Split(separator)[1];
                        dockStages.Add(key, new Parking<Vehicle>(pictureWidth, pictureHeight));
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
                        if ((dockStages[key] + transport) == -1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
