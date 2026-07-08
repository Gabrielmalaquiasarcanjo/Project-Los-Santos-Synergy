using GTA;
using GTA.Math;
using GTA.Native;

namespace Project_Los_Santos_Synergy.plss.Systems.Features.WorldSystem
{
    internal class VehicleDetector
    {
        public Vehicle GetVehicleInFrontOfPlayer(float distanceMax = 8.0f, float raioCapsula = 1.0f)
        {
            Ped player = Game.Player.Character;

            Vector3 origem = player.Position + (Vector3.WorldUp * 1.2f);
            Vector3 destino = origem + (player.ForwardVector * distanceMax);

            RaycastResult result = World.RaycastCapsule(
                origem,
                destino,
                raioCapsula,
                IntersectFlags.Vehicles,
                player
            );

            return (result.DidHit && result.HitEntity is Vehicle vehicle) ? vehicle : null;
        }

        public Vector3 GetVehicleHoodPosition(Vehicle vehicle)
        {
            if (vehicle.Bones.Contains("bonnet"))
            {
                return vehicle.Bones["bonnet"].Position + (Vector3.WorldUp * 0.15f);
            }

            // Fallback via native, já que Model.GetDimensions() não existe nessa versão do SHVDN
            var min = new OutputArgument();
            var max = new OutputArgument();

            Function.Call(Hash.GET_MODEL_DIMENSIONS, vehicle.Model.Hash, min, max);

            Vector3 maxDimensoes = max.GetResult<Vector3>();

            return vehicle.Position
                + (vehicle.ForwardVector * (maxDimensoes.Y * 0.7f))
                + (Vector3.WorldUp * 1.0f);
        }
    }
}