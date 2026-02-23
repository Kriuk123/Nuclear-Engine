using OpenTK.Mathematics;
using NuclearEngine.Core;
using NuclearEngine.Graphics;

namespace NuclearEngine.Objects
{
    public class Cube
    {
        public Transform Transform = new Transform();
        public Mesh Mesh { get; private set; }
        public Texture Texture { get; private set; }

        private static readonly float[] _vertices = 
        {
            // Back face
            -0.5f,-0.5f,-0.5f,  0f,0f,
             0.5f,-0.5f,-0.5f,  1f,0f,
             0.5f, 0.5f,-0.5f,  1f,1f,
             0.5f, 0.5f,-0.5f,  1f,1f,
            -0.5f, 0.5f,-0.5f,  0f,1f,
            -0.5f,-0.5f,-0.5f,  0f,0f,

            // Front face
            -0.5f,-0.5f,0.5f,   0f,0f,
             0.5f,-0.5f,0.5f,   1f,0f,
             0.5f, 0.5f,0.5f,   1f,1f,
             0.5f, 0.5f,0.5f,   1f,1f,
            -0.5f, 0.5f,0.5f,   0f,1f,
            -0.5f,-0.5f,0.5f,   0f,0f,

            // Left face
            -0.5f,0.5f,0.5f,    1f,0f,
            -0.5f,0.5f,-0.5f,   1f,1f,
            -0.5f,-0.5f,-0.5f,  0f,1f,
            -0.5f,-0.5f,-0.5f,  0f,1f,
            -0.5f,-0.5f,0.5f,   0f,0f,
            -0.5f,0.5f,0.5f,    1f,0f,

            // Right face
             0.5f,0.5f,0.5f,    1f,0f,
             0.5f,0.5f,-0.5f,   1f,1f,
             0.5f,-0.5f,-0.5f,  0f,1f,
             0.5f,-0.5f,-0.5f,  0f,1f,
             0.5f,-0.5f,0.5f,   0f,0f,
             0.5f,0.5f,0.5f,    1f,0f,

            // Bottom face
            -0.5f,-0.5f,-0.5f,  0f,1f,
             0.5f,-0.5f,-0.5f,  1f,1f,
             0.5f,-0.5f,0.5f,   1f,0f,
             0.5f,-0.5f,0.5f,   1f,0f,
            -0.5f,-0.5f,0.5f,   0f,0f,
            -0.5f,-0.5f,-0.5f,  0f,1f,

            // Top face
            -0.5f,0.5f,-0.5f,   0f,1f,
             0.5f,0.5f,-0.5f,   1f,1f,
             0.5f,0.5f,0.5f,    1f,0f,
             0.5f,0.5f,0.5f,    1f,0f,
            -0.5f,0.5f,0.5f,    0f,0f,
            -0.5f,0.5f,-0.5f,   0f,1f
        };

        public Cube(Vector3 position, Texture texture)
        {
            Transform.Position = position;
            Texture = texture;
            Mesh = new Mesh(_vertices);
        }
    }
}
