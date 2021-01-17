using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Graphics
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct VertexPositionColorTexture : IVertexType
    {
        [FieldOffset(0)] public Vector3 Position;
        [FieldOffset(12)] public Color Color;
        [FieldOffset(16)] public Vector2 TextureCoordinate;
        public unsafe PackedVector.NormalizedShort4 TextureCoordinateI
        {
            get
            {
                fixed (Vector2* f = &TextureCoordinate)
                {
                    return *(PackedVector.NormalizedShort4*)f;
                }
            }
            set
            {
                fixed (Vector2* f = &TextureCoordinate)
                {
                    *(PackedVector.NormalizedShort4*)f = value;
                }

            }
        }
        
        public static readonly VertexDeclaration VertexDeclaration;
        public static readonly VertexDeclaration VertexDeclaration2;

        public VertexPositionColorTexture(Vector3 position, Color color, Vector2 textureCoordinate)
        {
            Position = position;
            Color = color;
            TextureCoordinate = textureCoordinate;
        }
		
        VertexDeclaration IVertexType.VertexDeclaration
        {
            get
            {
                return VertexDeclaration;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Position.GetHashCode();
                hashCode = (hashCode * 397) ^ Color.GetHashCode();
                hashCode = (hashCode * 397) ^ TextureCoordinate.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return "{{Position:" + this.Position + " Color:" + this.Color + " TextureCoordinate:" + this.TextureCoordinate + "}}";
        }

        public static bool operator ==(VertexPositionColorTexture left, VertexPositionColorTexture right)
        {
            return (((left.Position == right.Position) && (left.Color == right.Color)) && (left.TextureCoordinate == right.TextureCoordinate));
        }

        public static bool operator !=(VertexPositionColorTexture left, VertexPositionColorTexture right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != base.GetType())
                return false;

            return (this == ((VertexPositionColorTexture)obj));
        }

        static VertexPositionColorTexture()
        {
            var elements = new VertexElement[] 
            { 
                new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0), 
                new VertexElement(12, VertexElementFormat.Color, VertexElementUsage.Color, 0), 
                new VertexElement(16, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0) 
            };
            VertexDeclaration = new VertexDeclaration(elements);

            // alternate format, 4 normalized shorts same binary size and layout
            var elements2 = new VertexElement[]
            {
                new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                new VertexElement(12, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(16, VertexElementFormat.NormalizedShort4, VertexElementUsage.TextureCoordinate, 0)
            };
            VertexDeclaration2 = new VertexDeclaration(elements2);
        }
    }
}
