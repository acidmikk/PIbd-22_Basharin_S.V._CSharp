using System;
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
    }
}
