using GTA;
using GTA.UI;
using Project_Los_Santos_Synergy.plss.teste.carspawn;
using Project_Los_Santos_Synergy.plss.teste.systems;
using System;
using System.Windows.Forms;

namespace Project_Los_Santos_Synergy
{
    public class ModController : Script
    {
        private DateTime _nextCheck = DateTime.MinValue;
        private Vehicle _vehicleCache;

        private readonly CarSpawn _carSpawn = new CarSpawn();
        private readonly Systems _systems = new Systems();

        public ModController()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DateTime.Now >= _nextCheck)
            {
                _vehicleCache = _systems.GetVehicleInFrontOfPlayer();
                _nextCheck = DateTime.Now.AddMilliseconds(250);
            }

            if (_vehicleCache != null)
            {
                GTA.UI.Screen.ShowSubtitle($"Veículo detectado: {_vehicleCache.DisplayName}");
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e) { }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                _carSpawn.CarSpawnMethod();
            }
        }
    }
}