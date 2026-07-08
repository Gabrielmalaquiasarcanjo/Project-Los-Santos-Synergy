using GTA.Math;
using GTA.Native;

namespace Project_Los_Santos_Synergy.plss.Systems.Extensions
{
    internal static class VectorExtensions
    {
        public static bool TryWorldToScreen(this Vector3 worldPos, out float x, out float y)
        {
            var screenX = new OutputArgument();
            var screenY = new OutputArgument();

            bool onScreen = Function.Call<bool>(
                Hash.GET_SCREEN_COORD_FROM_WORLD_COORD,
                worldPos.X, worldPos.Y, worldPos.Z,
                screenX, screenY
            );

            x = screenX.GetResult<float>();
            y = screenY.GetResult<float>();

            return onScreen;
        }
    }
}