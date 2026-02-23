using OpenTK.Graphics.OpenGL4;

namespace NuclearEngine.Graphics
{
    public class Mesh
    {
        private int _vao;
        private int _vbo;
        private int _vertexCount;

        public Mesh(float[] vertices)
        {
            _vertexCount = vertices.Length / 5;

            _vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            GL.BindVertexArray(_vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);

            GL.BufferData(BufferTarget.ArrayBuffer,
                vertices.Length * sizeof(float),
                vertices,
                BufferUsageHint.StaticDraw);

            // Position
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // UV
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);
        }

        public void Bind()
        {
            GL.BindVertexArray(_vao);
        }

        public void Draw()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertexCount);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_vbo);
            GL.DeleteVertexArray(_vao);
        }
    }
}
