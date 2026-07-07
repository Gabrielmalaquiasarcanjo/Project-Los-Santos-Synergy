using GTA;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Los_Santos_Synergy.plss.teste.carspawn
{
    internal class CarSpawn
    {
        public void CarSpawnMethod()
        {
            Vehicle vehicle = World.CreateVehicle(VehicleHash.Baller, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f, Game.Player.Character.Heading +90);
            vehicle.CanTiresBurst = false;
            vehicle.Mods.CustomPrimaryColor = Color.FromArgb(255, 0, 0); // Red color
            vehicle.Mods.CustomSecondaryColor = Color.FromArgb(0, 0, 255); // Blue color
            vehicle.PlaceOnGround();
            vehicle.Mods.LicensePlate = "PLSS";
            GTA.UI.Notification.Show("Spawned: BALLER ");

        }
    }
}
