using OpenTK.Mathematics;

namespace NuclearEngine.Core
{
    public class Camera
    {
        public Vector3 Position;

        private Vector3 _front = -Vector3.UnitZ;
        private Vector3 _up = Vector3.UnitY;
        private Vector3 _right = Vector3.UnitX;

        private float _yaw = -90f;
        private float _pitch = 0f;

        public float Fov = 75f;

        private const float Speed = 3f;
        private const float Sensitivity = 0.2f;

        public Camera(Vector3 position)
        {
            Position = position;
            UpdateVectors();
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + _front, _up);
        }

        public void ProcessKeyboard(Vector3 direction, float deltaTime)
        {
            float velocity = Speed * deltaTime;
            Position += direction * velocity;
        }

        public void ProcessMouseMovement(float deltaX, float deltaY)
        {
            deltaX *= Sensitivity;
            deltaY *= Sensitivity;

            _yaw += deltaX;
            _pitch -= deltaY;

            _pitch = MathHelper.Clamp(_pitch, -89f, 89f);

            UpdateVectors();
        }

        public void ProcessScroll(float offset)
        {
            Fov -= offset;
            Fov = MathHelper.Clamp(Fov, 1f, 90f);
        }

        private void UpdateVectors()
        {
            Vector3 front;

            front.X = MathF.Cos(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));

            front.Y = MathF.Sin(MathHelper.DegreesToRadians(_pitch));

            front.Z = MathF.Sin(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));

            _front = Vector3.Normalize(front);
            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));
        }

        public Vector3 Front => _front;
        public Vector3 Right => _right;
    }
}
