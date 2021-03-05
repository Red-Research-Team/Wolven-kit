using System;
using System.Collections.Generic;
using System.IO;
using CP77.CR2W.Types;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Materials;

namespace CP77.CR2W.Uncooker
{
    using MESH = MeshBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexEmpty>;
    using VCT = VertexColor1Texture2;
    using Vec2 = System.Numerics.Vector2;
    using Vec3 = System.Numerics.Vector3;
    using Vec4 = System.Numerics.Vector4;
    using VERTEX = VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexEmpty>;
    using VPNT = VertexPositionNormalTangent;

    public static class Mesh
    {
        #region Methods

        public static void ParseMesh(CR2WFile cr2w, List<byte[]> buffers, FileInfo outfile)
        {
            int meshbufferindex = Getmeshbufferindex(buffers);
            MeshesInfo meshesInfo = GetMeshesinfo(cr2w);
            List<RawMeshContainer> expMeshes = new List<RawMeshContainer>();
            MemoryStream gms = new MemoryStream(buffers[meshbufferindex]);

            for (int i = 0; i < meshesInfo.meshC; i++)
            {
                if (meshesInfo.LODLvl[i] == 1)
                    expMeshes.Add(ContainRawMesh(gms, meshesInfo.vertCounts[i], meshesInfo.indCounts[i], meshesInfo.vertOffsets[i], meshesInfo.tx0Offsets[i], meshesInfo.normalOffsets[i], meshesInfo.colorOffsets[i], meshesInfo.tx1Offsets[i], meshesInfo.indicesOffsets[i], meshesInfo.vpStrides[i], meshesInfo.qScale, meshesInfo.qTrans));
            }
            ContainedMeshToGLTF(expMeshes, outfile);
        }

        private static void ContainedMeshToGLTF(List<RawMeshContainer> meshes, FileInfo outfile)
        {
            var scene = new SharpGLTF.Scenes.SceneBuilder();

            int mIndex = -1;
            foreach (var mesh in meshes)
            {
                ++mIndex;
                long indCount = mesh.indices.Length;
                var expmesh = new MESH(string.Format(Path.GetFileNameWithoutExtension(outfile.FullName) + "_mesh_{0}", mIndex));

            UInt32[] vertCounts = new UInt32[meshC];
            UInt32[] indCounts = new UInt32[meshC];
            UInt32[] vertOffsets = new UInt32[meshC];
            UInt32[] tx0Offsets = new UInt32[meshC];
            UInt32[] normalOffsets = new UInt32[meshC];
            UInt32[] colorOffsets = new UInt32[meshC];
            UInt32[] tx1Offsets = new UInt32[meshC];
            UInt32[] indicesOffsets = new UInt32[meshC];
            UInt32[] vpStrides = new UInt32[meshC];
            UInt32[] LODLvl = new UInt32[meshC];
            for (int i = 0; i < meshC; i++)
            {
                vertCounts[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].NumVertices.Value;
                indCounts[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].NumIndices.Value;
                vertOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[0].Value;
                tx0Offsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[1].Value;
                normalOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[2].Value;
                colorOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[3].Value;
                tx1Offsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[4].Value;

                if ((cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkIndices.TeOffset == null)
                {
                    indicesOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.IndexBufferOffset.Value;
                }
                else
                {
                    indicesOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.IndexBufferOffset.Value + (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkIndices.TeOffset.Value;
                }
                vpStrides[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.VertexLayout.SlotStrides[0].Value;
                LODLvl[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].LodMask.Value;
            }
            Vector4 qScale = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.QuantizationScale;
            Vector4 qTrans = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.QuantizationOffset;

            var model = scene.ToGltf2();
            model.SaveGLB(Path.GetFullPath(outfile.FullName).Replace(".mesh", ".glb"));
        }

        private static RawMeshContainer ContainRawMesh(MemoryStream gfs, UInt32 vertCount, UInt32 indCount, UInt32 vertOffset, UInt32 tx0Offset, UInt32 normalOffset, UInt32 colorOffset, UInt32 tx1Offset, UInt32 indOffset, UInt32 vpStride, Vector4 qScale, Vector4 qTrans)
        {
            BinaryReader gbr = new BinaryReader(gfs);

            Vec3[] vertices = new Vec3[vertCount];
            uint[] indices = new uint[indCount];
            Vec2[] tx0coords = new Vec2[vertCount];
            Vec3[] normals = new Vec3[vertCount];
            Vec4[] tangents = new Vec4[vertCount];
            Vec4[] colors = new Vec4[vertCount];
            Vec2[] tx1coords = new Vec2[vertCount];

            // geting vertices
            for (int i = 0; i < vertCount; i++)
            {
                gfs.Position = vertOffset + i * vpStride;

                float x = (gbr.ReadInt16() / 32767f) * qScale.X.Value + qTrans.X.Value;
                float y = (gbr.ReadInt16() / 32767f) * qScale.Y.Value + qTrans.Y.Value;
                float z = (gbr.ReadInt16() / 32767f) * qScale.Z.Value + qTrans.Z.Value;
                vertices[i] = new Vec3(x, y, z);
            }
            // got vertices

            Converters converter = new Converters(); // contains methods for halffloats
            float[] values = new float[vertCount * 2];

            if (tx0Offset != 0)
            {
                // getting texturecoord0 as half floats
                gfs.Position = tx0Offset;
                for (int i = 0; i < vertCount * 2; i++)
                {
                    UInt16 read = gbr.ReadUInt16();
                    values[i] = converter.hfconvert(read);
                }
                for (int i = 0; i < vertCount; i++)
                {
                    tx0coords[i] = new Vec2(values[2 * i], values[2 * i + 1]);
                }
                // got texturecoord0 as half floats
            }

            UInt32 NorRead32;
            // getting 10bit normals
            for (int i = 0; i < vertCount; i++)
            {
                gfs.Position = normalOffset + 8 * i;
                NorRead32 = gbr.ReadUInt32();
                Vec4 tempv = converter.U32toVec4(NorRead32);
                normals[i] = new Vec3(tempv.X, tempv.Y, tempv.Z);
            }
            // got 10bit normals

            // getting 10bit tangents
            for (int i = 0; i < vertCount; i++)
            {
                gfs.Position = normalOffset + 4 + 8 * i;
                NorRead32 = gbr.ReadUInt32();
                Vec4 tempv = converter.U32toVec4(NorRead32);
                tangents[i] = new Vec4(tempv.X, tempv.Y, tempv.Z, 1f);
            }

            if (tx1Offset != 0)
            {
                // getting texturecoord1 as half floats
                gfs.Position = tx1Offset;
                for (int i = 0; i < vertCount * 2; i++)
                {
                    UInt16 read = gbr.ReadUInt16();
                    values[i] = converter.hfconvert(read);
                }
                for (int i = 0; i < vertCount; i++)
                {
                    tx1coords[i] = new Vec2(values[2 * i], values[2 * i + 1]);
                }
                // got texturecoord1 as half floats
            }

            if (colorOffset != 0)
            {
                // getting vert colors, not sure of the format TBH RN,just a hush, may not work, lulz
                for (int i = 0; i < vertCount; i++)
                {
                    gfs.Position = colorOffset + i * 8;
                    Vec4 tempv = new Vec4(gbr.ReadUInt16() / 65535f, gbr.ReadUInt16() / 65535f, gbr.ReadUInt16() / 65535f, gbr.ReadUInt16() / 65535f);
                    colors[i] = new Vec4(tempv.Y, tempv.Z, tempv.W, tempv.X);
                }
                // got vert colors
            }

            // getting uint16 faces/indices
            gfs.Position = indOffset;
            for (int i = 0; i < indCount; i++)
            {
                indices[i] = gbr.ReadUInt16();
            }
            // got uint16 faces/indices

            RawMeshContainer mesh = new RawMeshContainer()
            {
                vertices = vertices,
                indices = indices,
                tx0coords = tx0coords,
                normals = normals,
                tangents = tangents,
                colors = colors,
                tx1coords = tx1coords
            };
            return mesh;
        }

        private static int Getmeshbufferindex(List<byte[]> buffers)
        {
            int meshbufferindex = int.MaxValue;
            for (int i = 0; i < buffers.Count; i++)
            {
                MemoryStream bms = new MemoryStream(buffers[i]);
                BinaryReader bbr = new BinaryReader(bms);
                bms.Position = 6;

                if (bbr.ReadInt16() == Int16.MaxValue)
                {
                    meshbufferindex = i;
                    break;
                }
            }
            return meshbufferindex;
        }

        private static MeshesInfo GetMeshesinfo(CR2WFile cr2w)
        {
            int Index = int.MaxValue;
            for (int i = 0; i < cr2w.Chunks.Count; i++)
            {
                if (cr2w.Chunks[i].REDType == "rendRenderMeshBlob")
                {
                    Index = i;
                }
            }
            int meshC = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos.Count;

            UInt32[] vertCounts = new UInt32[meshC];
            UInt32[] indCounts = new UInt32[meshC];
            UInt32[] vertOffsets = new UInt32[meshC];
            UInt32[] tx0Offsets = new UInt32[meshC];
            UInt32[] normalOffsets = new UInt32[meshC];
            UInt32[] colorOffsets = new UInt32[meshC];
            UInt32[] tx1Offsets = new UInt32[meshC];
            UInt32[] indicesOffsets = new UInt32[meshC];
            UInt32[] vpStrides = new UInt32[meshC];
            UInt32[] LODLvl = new UInt32[meshC];
            for (int i = 0; i < meshC; i++)
            {
                vertCounts[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].NumVertices.val;
                indCounts[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].NumIndices.val;
                vertOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[0].val;
                tx0Offsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[1].val;
                normalOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[2].val;
                colorOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[3].val;
                tx1Offsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.ByteOffsets[4].val;

                if ((cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkIndices.TeOffset == null)
                {
                    indicesOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.IndexBufferOffset.val;
                }
                else
                {
                    indicesOffsets[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.IndexBufferOffset.val + (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkIndices.TeOffset.val;
                }
                vpStrides[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].ChunkVertices.VertexLayout.SlotStrides[0].val;
                LODLvl[i] = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.RenderChunkInfos[i].LodMask.val;
            }
            Vector4 qScale = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.QuantizationScale;
            Vector4 qTrans = (cr2w.Chunks[Index].data as rendRenderMeshBlob).Header.QuantizationOffset;

            MeshesInfo meshesInfo = new MeshesInfo()
            {
                vertCounts = vertCounts,
                indCounts = indCounts,
                vertOffsets = vertOffsets,
                tx0Offsets = tx0Offsets,
                normalOffsets = normalOffsets,
                colorOffsets = colorOffsets,
                tx1Offsets = tx1Offsets,
                indicesOffsets = indicesOffsets,
                vpStrides = vpStrides,
                LODLvl = LODLvl,
                qScale = qScale,
                qTrans = qTrans,
                meshC = meshC
            };
            return meshesInfo;
        }

        #endregion Methods

        #region Classes

        private class MeshesInfo
        {
            #region Properties

            public UInt32[] colorOffsets { get; set; }
            public UInt32[] indCounts { get; set; }
            public UInt32[] indicesOffsets { get; set; }
            public UInt32[] LODLvl { get; set; }
            public int meshC { get; set; }
            public UInt32[] normalOffsets { get; set; }
            public Vector4 qScale { get; set; }
            public Vector4 qTrans { get; set; }
            public UInt32[] tx0Offsets { get; set; }
            public UInt32[] tx1Offsets { get; set; }
            public UInt32[] vertCounts { get; set; }
            public UInt32[] vertOffsets { get; set; }
            public UInt32[] vpStrides { get; set; }

            #endregion Properties
        }

        private class RawMeshContainer
        {
            #region Properties

            public Vec4[] colors { get; set; }
            public uint[] indices { get; set; }
            public Vec3[] normals { get; set; }
            public Vec4[] tangents { get; set; }
            public Vec2[] tx0coords { get; set; }
            public Vec2[] tx1coords { get; set; }
            public Vec3[] vertices { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }

    public class Converters
    {
        #region Methods

        public UInt16 converthf(float value) // a floating point to halffloat uint16 equivalent representation -65504 <= value <= 65504
        {
            UInt16 sign = 0;
            UInt16 sp = 0;
            UInt16 pow = 0;
            if (float.IsNegative(value) && !float.IsNaN(value))
            {
                sign = 32768;
                value = -1 * value;
            }
            if (value > 65504)
            {
                value = 65504;      // if number provided is > Half.Max or < Half.Min then normalized
            }
            if (value >= 0 && value <= (float)0.000060975552)
            {
                pow = 0;
                sp = Convert.ToUInt16(value * 1024 * Math.Pow(2, 14));
            }
            else if (float.IsNaN(value) || float.IsPositiveInfinity(value))
            {
                sp = 0;
                pow = 31744;
                if (float.IsNaN(value))
                    sp = 55; // sp can be anything in this case i randomly put 55
            }
            else if (value >= (float)0.00006103515625 && value <= (float)65504)
            {
                Int16 temp1 = 14;
                UInt64 temp2 = Convert.ToUInt64((value * Math.Pow(2, temp1) - 1) * 1024);
                for (; temp2 > 1023; temp1--)
                {
                    temp2 = Convert.ToUInt64((value * Math.Pow(2, temp1 - 1) - 1) * 1024);
                }
                sp = Convert.ToUInt16(temp2);
                UInt16 temp3 = Convert.ToUInt16((-1 * temp1) + 15);
                pow = Convert.ToUInt16(temp3 << 10);
            }
            UInt16 U16 = Convert.ToUInt16(sign | sp | pow);
            return U16;
        }

        public float hfconvert(UInt16 read)// for converting ushort representation of a Half float to a float32
        {
            String bin = Convert.ToString(read, 2).PadLeft(16, '0');
            UInt16 sp = Convert.ToUInt16(bin.Substring(6, 10), 2);
            UInt16 pow = Convert.ToUInt16(bin.Substring(1, 5), 2);
            UInt16 sign = Convert.ToUInt16(bin.Substring(0, 1));

            float value = 0f;
            if (pow == 0)
            {
                value = Convert.ToSingle(Math.Pow(2, -14)) * (sp / 1024f);
            }
            else if (pow == 31)
            {
                if (sp == 0)
                    value = float.PositiveInfinity;
                else
                    value = float.NaN;
            }
            else
            {
                value = Convert.ToSingle(Math.Pow(2, pow - 15)) * (1 + sp / 1024f);
            }

            if (sign == 1)
            {
                value = (-1) * value;
            }

            return value;
        }

        public Vec4 U32toVec4(UInt32 U32)
        {
            Int16 X = Convert.ToInt16(U32 & 0x3ff);
            Int16 Y = Convert.ToInt16((U32 >> 10) & 0x3ff);
            Int16 Z = Convert.ToInt16((U32 >> 20) & 0x3ff);
            byte W = Convert.ToByte((U32) >> 30);
            return new Vec4((X - 512) / 512f, (Y - 512) / 512f, (Z - 512) / 512f, W / 3f);
        }

        #endregion Methods
    }
}
