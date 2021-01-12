using Microsoft.Xna.Framework.Graphics;

using System.Runtime.InteropServices;

namespace Microsoft.Xna
{
    // 4 vertices which reprepsent a sprite drawn as a quad
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SpriteVertices
    {
        public VertexPositionColorTexture vertexTL;
        public VertexPositionColorTexture vertexTR;
        public VertexPositionColorTexture vertexBL;
        public VertexPositionColorTexture vertexBR;

        public static IndexBuffer indexBuffer;
    }

}
