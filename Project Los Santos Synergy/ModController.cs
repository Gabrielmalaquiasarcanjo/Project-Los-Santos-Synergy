using GTA;
using GTA.Math;
using GTA.UI;
using Project_Los_Santos_Synergy.plss.Systems.Features.WorldSystem;
using Project_Los_Santos_Synergy.plss.Systems.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Los_Santos_Synergy
{
    public class ModController : Script
    {
        private DateTime _nextCheck = DateTime.MinValue;
        private Vehicle _vehicleOnScreen;
        private bool _promptVisible;

        private readonly CarSpawn _carSpawn = new CarSpawn();
        private readonly VehicleDetector _systems = new VehicleDetector();

        private readonly TextElement _promptText = new TextElement(
            "Pressione ~INPUT_CONTEXT~ para interagir",
            PointF.Empty,
            0.35f,
            Color.White,
            GTA.UI.Font.ChaletLondon,
            Alignment.Center,
            true,  // shadow
            true   // outline
        );

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
                _vehicleOnScreen = _systems.GetVehicleInFrontOfPlayer();
                _nextCheck = DateTime.Now.AddMilliseconds(250);
            }

            _promptVisible = false;

            if (_vehicleOnScreen != null)
            {
                Vector3 hoodPosition = _systems.GetVehicleHoodPosition(_vehicleOnScreen);

                if (hoodPosition.TryWorldToScreen(out float x, out float y))
                {
                    float pixelX = x * GTA.UI.Screen.Resolution.Width;
                    float pixelY = y * GTA.UI.Screen.Resolution.Height;

                    _promptText.Position = new PointF(pixelX, pixelY);
                    _promptText.Draw();
                    _promptVisible = true;
                }
            }
        }
    
        private void OnKeyDown(object sender, KeyEventArgs e) { }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                _carSpawn.CarSpawnMethod();
            }

            if (e.KeyCode == Keys.E && _promptVisible && _vehicleOnScreen != null)
            {
                OnInteractWithVehicle(_vehicleOnScreen);
            }
        }

        private void OnInteractWithVehicle(Vehicle vehicle)
        {
            GTA.UI.Notification.Show($"Interagindo com: {vehicle.DisplayName}", false);
            // aqui entra a lógica real (entrar no carro, roubar, inspecionar, etc)
        }
    }
}