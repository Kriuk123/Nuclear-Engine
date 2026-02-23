using NuclearEngine.Core;
using OpenTK.Mathematics;

namespace NuclearEngine.Graphics
{
    public class Renderer
    {
        private Shader _shader;

        public Renderer(Shader shader)
        {
            _shader = shader;
        }

        public void Render(Mesh mesh, Transform transform, Matrix4 view, Matrix4 projection, Texture texture)
        {
            _shader.Use();

            _shader.SetMatrix4("model", transform.GetModelMatrix());
            _shader.SetMatrix4("view", view);
            _shader.SetMatrix4("projection", projection);

            texture.Use();
            _shader.SetInt("texture0", 0);
            _shader.SetFloat("tiling", 1.0f);

            mesh.Bind();
            mesh.Draw();
        }
    }
}
