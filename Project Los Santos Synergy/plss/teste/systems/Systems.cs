using GTA;
using GTA.Math;
using GTA.Native;

namespace Project_Los_Santos_Synergy.plss.teste.systems
{
    internal class Systems
    {
        public Vehicle GetVehicleInFrontOfPlayer(float distanceMax = 8.0f, float raioCapsula = 1.0f)
        {
            Ped player = Game.Player.Character;

            Vector3 origem = player.Position + (Vector3.WorldUp * 1.2f);
            Vector3 destino = origem + (player.ForwardVector * distanceMax);

            RaycastResult result = World.Raycast(
                origem,
                destino,
                raioCapsula,
                IntersectFlags.Vehicles,
                player
            );

            return (result.DidHit && result.HitEntity is Vehicle vehicle) ? vehicle : null;
        }
    }
}