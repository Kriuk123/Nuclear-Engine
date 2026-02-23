using OpenTK.Mathematics;

namespace NuclearEngine.Core
{
    public class Transform
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = Vector3.One;

        public Matrix4 GetModelMatrix()
        {
            Matrix4 model = Matrix4.Identity;

            model *= Matrix4.CreateScale(Scale);
            model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X));
            model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y));
            model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z));
            model *= Matrix4.CreateTranslation(Position);

            return model;
        }
    }
}
