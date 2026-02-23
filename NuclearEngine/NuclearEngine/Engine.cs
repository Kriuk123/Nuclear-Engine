using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using NuclearEngine.Core;
using NuclearEngine.Graphics;
using NuclearEngine.Objects;

namespace NuclearEngine
{
    internal class Engine : GameWindow
    {
        private Shader _shader;
        private Renderer _renderer;

        // Scene objects
        private List<Cube> _cubes = new List<Cube>();

        //Camera
        private Camera _camera;
        private Vector2 _lastMousePos;
        private bool _firstMove = true;

        // Timing
        private float _time;

        public Engine(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws)
        {}

        protected override void OnLoad()
        {
            base.OnLoad();

            // --- OpenGL Setup ---
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0.2f, 0.2f, 0.3f, 1f);

            // --- Shader ---
            _shader = new Shader("Shaders/basic.vert", "Shaders/basic.frag");

            // --- Renderer ---
            _renderer = new Renderer(_shader);

            // --- Scene Objects ---
            var texture = new Texture("../../../Content/Textures/TEX_Grid.png");
            var texture2 = new Texture("../../../Content/Textures/TEX_Grid3.png");

            // Spawn multiple cubes
            _cubes.Add(new Cube(new Vector3(0, 0, 0), texture));
            _cubes.Add(new Cube(new Vector3(2, 0, 0), texture2));
            _cubes.Add(new Cube(new Vector3(-2, 0, 0), texture2));
            _cubes.Add(new Cube(new Vector3(0, 2, 0), texture2));
            _cubes.Add(new Cube(new Vector3(0, -2, 0), texture2));

            //Camera
            _camera = new Camera(new Vector3(0f, 0f, 3f));
            CursorState = CursorState.Grabbed;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            // Если ты это удалишь, то при изменении размера окна такой прикол будет...
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            _time += (float)args.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // --- Camera Matrices ---
            Matrix4 view = _camera.GetViewMatrix();
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_camera.Fov), Size.X / (float)Size.Y, 0.1f, 100f);

            // --- Render ---
            foreach (var cube in _cubes)
            {
                _renderer.Render(cube.Mesh, cube.Transform, view, projection, cube.Texture);
                cube.Transform.Rotation.Y = 35f * _time;
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            var input = KeyboardState;

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
                Close();

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W))
                _camera.ProcessKeyboard(_camera.Front, (float)args.Time);

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S))
                _camera.ProcessKeyboard(-_camera.Front, (float)args.Time);

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
                _camera.ProcessKeyboard(-_camera.Right, (float)args.Time);

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D))
                _camera.ProcessKeyboard(_camera.Right, (float)args.Time);
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            // DON'T CHANGE THE ORDER
            foreach (var cube in _cubes)
            {
                cube.Mesh.Dispose();
            }

            _shader.Dispose();
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            if (_firstMove)
            {
                _lastMousePos = new Vector2(e.X, e.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = e.X - _lastMousePos.X;
                var deltaY = e.Y - _lastMousePos.Y;

                _lastMousePos = new Vector2(e.X, e.Y);

                _camera.ProcessMouseMovement(deltaX, deltaY);
            }
        }
    }
}
