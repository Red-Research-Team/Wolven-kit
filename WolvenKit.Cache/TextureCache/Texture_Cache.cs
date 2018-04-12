﻿using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using W3Edit.Textures;
using WolvenKit.CR2W;
using WolvenKit.Interfaces;

namespace WolvenKit.Cache
{
    public class TextureCache : IWitcherArchiveType
    {
        //The images packed into this Texture cache file
        public List<TextureCacheItem> Files;

        public string TypeName => "TextureCache";
        public string FileName { get; set; }
        public List<uint> Chunkoffsets;
        public uint TextureCount;
        public uint NamesBlockSize;
        public uint ChunkOffsetCount;
        public uint Magic;
        public uint Version;
        public List<string> Names;

        public TextureCache()
        {

        }

        public TextureCache(string filename)
        {
            this.Read(filename);
        }

        public void Read(string filepath)
        {
            FileName = filepath;
            Chunkoffsets = new List<uint>();
            using (var br = new BinaryReader(new FileStream(filepath, FileMode.Open)))
            {
                Files = new List<TextureCacheItem>();
                br.BaseStream.Seek(-20, SeekOrigin.End);
                TextureCount = br.ReadUInt32();
                NamesBlockSize = br.ReadUInt32();
                ChunkOffsetCount = br.ReadUInt32();
                Magic = br.ReadUInt32();
                Version = br.ReadUInt32();
                var jmp = -(20 + 12 + (TextureCount * 52) + NamesBlockSize + (ChunkOffsetCount * 4));
                br.BaseStream.Seek(jmp, SeekOrigin.End);
                for (var i = 0; i < ChunkOffsetCount; i++)
                {
                    Chunkoffsets.Add(br.ReadUInt32());
                }
                Names = new List<string>();
                for (var i = 0; i < TextureCount; i++)
                {
                    Names.Add(br.ReadCR2WString());
                }
                for (var i = 0; i < TextureCount; i++)
                {
                    var ti = new TextureCacheItem(this)
                    {
                        Name = Names[i],
                        ParentFile = FileName,
                        Id = br.ReadUInt32(),               //number (unique???)
                        Filenameoffset = br.ReadUInt32(),   //filename, start offset in block2
                        Offset = br.ReadUInt32(),           //* 4096 = start offset, first chunk
                        PackedSize = br.ReadUInt32(),       //packed size (all chunks)
                        UnpackedSize = br.ReadUInt32(),     //unpacked size
                        Bpp = br.ReadUInt32(),              //bpp? always 16
                        Width = br.ReadUInt16(),            //width
                        Height = br.ReadUInt16(),           //height
                        Mips = br.ReadUInt16(),             //mips
                        Typeinfo = br.ReadUInt16(),         //1/6/N, single, cubemaps, arrays
                        B1Offset = br.ReadUInt32(),         //offset in block1, second packed chunk
                        Rpc = br.ReadUInt32(),              //the number of remaining packed chunks
                        Unk1 = br.ReadUInt32(),             //???
                        Unk2 = br.ReadUInt32(),             //???
                        Dxt = br.ReadByte(),                //0-RGBA?, 7-DXT1, 8-DXT5, 10-???, 13-DXT3, 14-ATI1, 15-???, 253-???
                        Type = br.ReadByte(),               //3-cubemaps, 4-texture
                        Unk3 = br.ReadUInt16()              //0/1 ???
                    };
                    Files.Add(ti);
                }
                for (var i = 0; i < 3; i++)
                {
                    br.ReadBytes(4);
                }
                foreach (var t in Files)
                {
                    br.BaseStream.Seek(t.Offset * 4096, SeekOrigin.Begin);
                    t.ZSize = br.ReadUInt32(); //Compressed size
                    t.Size = br.ReadInt32(); //Uncompressed size
                    t.Part = br.ReadByte(); //maybe the 48bit part of OFFSET
                }
            }
        }

        public static void Write(BinaryWriter bw)
        {
            //TODO: Finish this!
        }
    }
}
