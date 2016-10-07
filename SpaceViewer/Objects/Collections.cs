﻿namespace SpaceViewer.Objects
{
    public class AttributeCollection
    {
        public vec3 VertexPosition, VertexNormal, TextureCoord;
    }

    public class UniformCollection
    {
        public mat4 ProjectionMatrix, ModelViewMatrix, NormalMatrix;
        public int Sampler, UseLighting, AmbientColor, LightingDirection, DirectionalColor;
    }

    public class BufferCollection
    {
        public object VertexPositions, VertexNormals, TextureCoords;
        public object Indices;
    }

    public class MatrixCollection
    {
        public mat4 Projection = mat4.identity();
        public mat4 ModelView = mat4.identity();
        public mat4 Normal = mat4.identity();
        public mat4 Billboard = mat4.identity();
    }

    public static class CubeData
    {
        public static readonly float[] Positions = new float[] {
            // Front face
            -1, -1,  1,
             1, -1,  1,
             1,  1,  1,
            -1,  1,  1,

            // Back face
            -1, -1, -1,
            -1,  1, -1,
             1,  1, -1,
             1, -1, -1,

            // Top face
            -1,  1, -1,
            -1,  1,  1,
             1,  1,  1,
             1,  1, -1,

            // Bottom face
            -1, -1, -1,
             1, -1, -1,
             1, -1,  1,
            -1, -1,  1,

            // Right face
             1, -1, -1,
             1,  1, -1,
             1,  1,  1,
             1, -1,  1,

            // Left face
            -1, -1, -1,
            -1, -1,  1,
            -1,  1,  1,
            -1,  1, -1,
        };

        public static readonly float[] Normals = new float[] {
            // Front face
             0,  0,  1,
             0,  0,  1,
             0,  0,  1,
             0,  0,  1,

            // Back face
             0,  0, -1,
             0,  0, -1,
             0,  0, -1,
             0,  0, -1,

            // Top face
             0,  1,  0,
             0,  1,  0,
             0,  1,  0,
             0,  1,  0,

            // Bottom face
             0, -1,  0,
             0, -1,  0,
             0, -1,  0,
             0, -1,  0,

            // Right face
             1,  0,  0,
             1,  0,  0,
             1,  0,  0,
             1,  0,  0,

            // Left face
            -1,  0,  0,
            -1,  0,  0,
            -1,  0,  0,
            -1,  0,  0
        };

        public static readonly float[] TexCoords = new float[] {
            // Front face
            0, 0,
            1, 0,
            1, 1,
            0, 1,

            // Back face
            1, 0,
            1, 1,
            0, 1,
            0, 0,

            // Top face
            0, 1,
            0, 0,
            1, 0,
            1, 1,

            // Bottom face
            1, 1,
            0, 1,
            0, 0,
            1, 0,

            // Right face
            1, 0,
            1, 1,
            0, 1,
            0, 0,

            // Left face
            0, 0,
            1, 0,
            1, 1,
            0, 1
        };

        public static readonly ushort[] Indices = new ushort[] {
            0, 1, 2,      0, 2, 3,    // Front face
            4, 5, 6,      4, 6, 7,    // Back face
            8, 9, 10,     8, 10, 11,  // Top face
            12, 13, 14,   12, 14, 15, // Bottom face
            16, 17, 18,   16, 18, 19, // Right face
            20, 21, 22,   20, 22, 23  // Left face
        };
    }
}
