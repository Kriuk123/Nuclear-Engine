using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace NuclearEngine
{
    public class Program
    {
        static void Main()
        {
            var gameSettings = GameWindowSettings.Default;

            var nativeSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1280, 720),
                Title = "Nuclear 3D",
                Flags = ContextFlags.ForwardCompatible
            };

            using (var _window = new Engine(gameSettings, nativeSettings))
            {
                _window.Run();
            }
        }
    }
}