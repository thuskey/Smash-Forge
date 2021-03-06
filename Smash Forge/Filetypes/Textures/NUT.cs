﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Smash_Forge
{
    public class TextureSurface
    {
        public List<byte[]> mipmaps = new List<byte[]>();
        public uint cubemapFace = 0; //Not set currently
    }

    public class NutTexture : TreeNode
    {
        public List<TextureSurface> surfaces = new List<TextureSurface>();
        //Each texture should contain either 1 or 6 surfaces
        //Each surface should contain (1 <= n <= 255) mipmaps
        //Each surface in a texture should have the same amount of mipmaps and dimensions for them

        public byte surfaceCount {
            get {
                return (byte)surfaces.Count;
            }
        }
        public byte mipMapsPerSurface {
            get {
                return (byte)surfaces[0].mipmaps.Count;
            }
        }

        public int HASHID {
            get {
                return id;
            }
            set {
                Text = value.ToString("x").ToUpper();
                id = value;
            }
        }
        private int id;
        public int Width;
        public int Height;
        public PixelInternalFormat type;
        public OpenTK.Graphics.OpenGL.PixelFormat utype;
        public PixelType PixelType = PixelType.UnsignedByte;

        public uint ddsCaps2 {
            get {
                if (surfaces.Count == 6) return (uint)DDS.DDSCAPS2.CUBEMAP_ALLFACES;
                else                     return (uint)0;
            }
        }

        //Return a list containing every mipmap from every surface
        public List<byte[]> getAllMipmaps()
        {
            List<byte[]> mipmaps = new List<byte[]>();
            foreach (TextureSurface surface in surfaces)
            {
                foreach (byte[] mipmap in surface.mipmaps)
                {
                    mipmaps.Add(mipmap);
                }
            }
            return mipmaps;
        }
        //Move channel 0 to channel 3 (ABGR -> BGRA)
        public void swapChannelOrderUp()
        {
            foreach (byte[] mip in getAllMipmaps())
            {
                for (int t = 0; t < mip.Length; t += 4)
                {
                    byte t1 = mip[t];
                    mip[t] = mip[t + 1];
                    mip[t + 1] = mip[t + 2];
                    mip[t + 2] = mip[t + 3];
                    mip[t + 3] = t1;
                }
            }
        }
        //Move channel 3 to channel 0 (BGRA -> ABGR)
        public void swapChannelOrderDown()
        {
            foreach (byte[] mip in getAllMipmaps())
            {
                for (int t = 0; t < mip.Length; t += 4)
                {
                    byte t1 = mip[t + 3];
                    mip[t + 3] = mip[t + 2];
                    mip[t + 2] = mip[t + 1];
                    mip[t + 1] = mip[t];
                    mip[t] = t1;
                }
            }
        }

        public NutTexture()
        {
            ImageKey = "texture";
            SelectedImageKey = "texture";
        }
        
        public override string ToString()
        {
            return HASHID.ToString("x").ToUpper();
        }

        public int Size
        {
            get
            {
                switch (type)
                {
                    case PixelInternalFormat.CompressedRedRgtc1:
                    case PixelInternalFormat.CompressedRgbaS3tcDxt1Ext:
                        return (Width * Height / 2);
                    case PixelInternalFormat.CompressedRgRgtc2:
                    case PixelInternalFormat.CompressedRgbaS3tcDxt3Ext:
                    case PixelInternalFormat.CompressedRgbaS3tcDxt5Ext:
                        return (Width * Height);
                    case PixelInternalFormat.Rgba16:
                        return surfaces[0].mipmaps[0].Length / 2;
                    case PixelInternalFormat.Rgba:
                        return surfaces[0].mipmaps[0].Length;
                    default:
                        return surfaces[0].mipmaps[0].Length;
                }
            }
        }

        public int getNutFormat()
        {
            switch (type)
            {
                case PixelInternalFormat.CompressedRgbaS3tcDxt1Ext:
                    return 0;
                case PixelInternalFormat.CompressedRgbaS3tcDxt3Ext:
                    return 1;
                case PixelInternalFormat.CompressedRgbaS3tcDxt5Ext:
                    return 2;
                case PixelInternalFormat.Rgb16:
                    return 8;
                case PixelInternalFormat.Rgba:
                    if (utype == OpenTK.Graphics.OpenGL.PixelFormat.Rgba)
                        return 14;
                    else
                    if (utype == OpenTK.Graphics.OpenGL.PixelFormat.AbgrExt)
                        return 16;
                    else
                        return 17;
                case PixelInternalFormat.CompressedRedRgtc1:
                    return 21;
                case PixelInternalFormat.CompressedRgRgtc2:
                    return 22;
                default:
                    throw new NotImplementedException($"Unknown pixel format 0x{type:X}");
            }
        }

        public void setPixelFormatFromNutFormat(int typet)
        {
            switch (typet)
            {
                case 0x0:
                    type = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
                    break;
                case 0x1:
                    type = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
                    break;
                case 0x2:
                    type = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
                    break;
                case 8:
                    type = PixelInternalFormat.Rgb16;
                    utype = OpenTK.Graphics.OpenGL.PixelFormat.Rgb;
                    PixelType = PixelType.UnsignedShort565Reversed;
                    break;
                case 12:
                    type = PixelInternalFormat.Rgba16;
                    utype = OpenTK.Graphics.OpenGL.PixelFormat.Rgba;
                    break;
                case 14:
                    type = PixelInternalFormat.Rgba;
                    utype = OpenTK.Graphics.OpenGL.PixelFormat.Rgba;
                    break;
                case 16:
                    type = PixelInternalFormat.Rgba;
                    utype = OpenTK.Graphics.OpenGL.PixelFormat.AbgrExt;
                    break;
                case 17:
                    type = PixelInternalFormat.Rgba;
                    utype = OpenTK.Graphics.OpenGL.PixelFormat.Rgba;
                    break;
                case 21:
                    type = PixelInternalFormat.CompressedRedRgtc1;
                    break;
                case 22:
                    type = PixelInternalFormat.CompressedRgRgtc2;
                    break;
                default:
                    throw new NotImplementedException($"Unknown nut texture format 0x{typet:X}");
            }
        }
    }

    public class NUT : FileBase
    {
        // Dictionary<hash ID, OpenTK texture>
        public Dictionary<int, int> glTexByHashId = new Dictionary<int, int>();

        public ushort Version = 0x200;

        public override Endianness Endian { get; set; }

        public NUT()
        {
            Text = "model.nut";
            ImageKey = "nut";
            SelectedImageKey = "nut";

            ContextMenu = new ContextMenu();
            MenuItem edit = new MenuItem("Edit");
            ContextMenu.MenuItems.Add(edit);
            edit.Click += OpenEditor;
            MenuItem save = new MenuItem("Save As");
            ContextMenu.MenuItems.Add(save);
            save.Click += Save;
        }

        public NUT (string filename) : this()
        {
            Read(filename);
        }

        public NUT(FileData d) : this()
        {
            Read(d);
        }

        /*~NUT()
        {
            //Destroy();
        }*/

        public bool getTextureByID(int hash, out NutTexture suc)
        {
            suc = null;
            foreach (NutTexture t in Nodes)
                if (t.HASHID == hash)
                {
                    suc = t;
                    return true;
                }

            return false;
        }

        #region Functions
        NUTEditor Editor;

        private void OpenEditor(object sender, EventArgs args)
        {
            if (Editor == null || Editor.IsDisposed)
            {
                Editor = new NUTEditor(this);
                Editor.Text = Parent.Text + "\\" + Text;
                //Editor.ShowDialog();
                MainForm.Instance.AddDockedControl(Editor);
            }
            else
            {
                Editor.BringToFront();
            }
        }

        public void Save(object sender, EventArgs args)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Namco Universal Texture (.nut)|*.nut|" +
                             "All Files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, Rebuild());
                }
            }
        }
        #endregion

        public override byte[] Rebuild()
        {
            FileOutput o = new FileOutput();
            FileOutput data = new FileOutput();

            o.writeUInt(0x4E545033); // "NTP3"
            o.writeUShort(Version);
            o.writeUShort((ushort)Nodes.Count);
            o.writeInt(0);
            o.writeInt(0);

            //calculate total header size
            uint headerLength = 0;

            foreach (NutTexture texture in Nodes)
            {
                
                byte surfaceCount = (byte)texture.surfaces.Count;
                bool isCubemap = surfaceCount == 6;
                if (surfaceCount < 1 || surfaceCount > 6)
                    throw new NotImplementedException($"Unsupported surface amount {surfaceCount} for texture with hash 0x{texture.HASHID:X}. 1 to 6 faces are required.");
                else if (surfaceCount > 1 && surfaceCount < 6)
                    throw new NotImplementedException($"Unsupported cubemap face amount for texture with hash 0x{texture.HASHID:X}. Six faces are required.");
                byte mipMapCount = (byte)texture.surfaces[0].mipmaps.Count;

                ushort headerSize = 0x50;
                if (isCubemap)
                {
                    headerSize += 0x10;
                }
                if (mipMapCount > 1)
                {
                    headerSize += (ushort)(mipMapCount * 4);
                    while (headerSize % 0x10 != 0)
                        headerSize += 1;
                }

                headerLength += headerSize;
            }

            // write headers+data
            foreach (NutTexture texture in Nodes)
            {
                byte surfaceCount = (byte)texture.surfaces.Count;
                bool isCubemap = surfaceCount == 6;
                byte mipMapCount = (byte)texture.surfaces[0].mipmaps.Count;

                uint dataSize = 0;

                foreach (var mip in texture.getAllMipmaps())
                {
                    dataSize += (uint)mip.Length;
                    while (dataSize % 0x10 != 0)
                        dataSize += 1;
                }

                ushort headerSize = 0x50;
                if (isCubemap)
                {
                    headerSize += 0x10;
                }
                if (mipMapCount > 1)
                {
                    headerSize += (ushort)(mipMapCount * 4);
                    while (headerSize % 0x10 != 0)
                        headerSize += 1;
                }

                o.writeUInt(dataSize + headerSize);
                o.writeUInt(0);
                o.writeUInt(dataSize);
                o.writeUShort(headerSize);
                o.writeUShort(0);

                o.writeByte(0);
                o.writeByte(mipMapCount);
                o.writeByte(0);
                o.writeByte(texture.getNutFormat());
                o.writeShort(texture.Width);
                o.writeShort(texture.Height);
                o.writeInt(0);
                o.writeUInt(texture.ddsCaps2);

                o.writeUInt((uint)(headerLength + data.size()));
                headerLength -= headerSize;
                o.writeInt(0);
                o.writeInt(0);
                o.writeInt(0);

                if (isCubemap)
                {
                    o.writeInt(texture.surfaces[0].mipmaps[0].Length);
                    o.writeInt(texture.surfaces[0].mipmaps[0].Length);
                    o.writeInt(0);
                    o.writeInt(0);
                }

                if (texture.getNutFormat() == 14 || texture.getNutFormat() == 17)
                {
                    texture.swapChannelOrderDown();
                }

                for (byte surfaceLevel = 0; surfaceLevel < surfaceCount; ++surfaceLevel)
                {
                    for (byte mipLevel = 0; mipLevel < mipMapCount; ++mipLevel)
                    {
                        int ds = data.size();
                        data.writeBytes(texture.surfaces[surfaceLevel].mipmaps[mipLevel]);
                        data.align(0x10);
                        if (mipMapCount > 1 && surfaceLevel == 0)
                            o.writeInt(data.size() - ds);
                    }
                }
                o.align(0x10);

                if (texture.getNutFormat() == 14 || texture.getNutFormat() == 17)
                {
                    texture.swapChannelOrderUp();
                }

                o.writeUInt(0x65587400); // "eXt\0"
                o.writeInt(0x20);
                o.writeInt(0x10);
                o.writeInt(0x00);

                o.writeUInt(0x47494458); // "GIDX"
                o.writeInt(0x10);
                o.writeInt(texture.HASHID);
                o.writeInt(0);
            }
            o.writeOutput(data);

            return o.getBytes();
        }

        public override void Read(string filename)
        {
            Read(new FileData(filename));
        }

        public void Read(FileData d)
        {
            Endian = Endianness.Big;
            d.Endian = Endian;
            uint magic = d.readUInt();

            if (magic == 0x4E545033)
            {
                ReadNTP3(d);
            }
            else if (magic == 0x4E545755)
            {
                ReadNTWU(d);
            }
            else if (magic == 0x4E545744)
            {
                d.Endian = Endianness.Little;
                ReadNTP3(d);
            }
        }

        public void ReadNTP3(FileData d)
        {
            d.seek(0x4);

            Version = d.readUShort();
            ushort count = d.readUShort();
            if (Version == 0x100)
                count -= 1;

            d.skip(0x8);
            int headerPtr = 0x10;

            for (ushort i = 0; i < count; ++i)
            {
                d.seek(headerPtr);

                NutTexture tex = new NutTexture();
                tex.type = PixelInternalFormat.Rgba32ui;

                int totalSize = d.readInt();
                d.skip(4);
                int dataSize = d.readInt();
                int headerSize = d.readUShort();
                d.skip(2);

                //It might seem that mipMapCount and pixelFormat would be shorts, but they're bytes because they stay in the same place regardless of endianness
                d.skip(1);
                byte mipMapCount = d.readByte();
                d.skip(1);
                tex.setPixelFormatFromNutFormat(d.readByte());
                tex.Width = d.readUShort();
                tex.Height = d.readUShort();
                d.skip(4);
                uint caps2 = d.readUInt();

                bool isCubemap = false;
                byte surfaceCount = 1;
                if ((caps2 & (uint)DDS.DDSCAPS2.CUBEMAP) == (uint)DDS.DDSCAPS2.CUBEMAP)
                {
                    //Only supporting all six faces
                    if ((caps2 & (uint)DDS.DDSCAPS2.CUBEMAP_ALLFACES) == (uint)DDS.DDSCAPS2.CUBEMAP_ALLFACES)
                    {
                        isCubemap = true;
                        surfaceCount = 6;
                    }
                    else
                    {
                        throw new NotImplementedException($"Unsupported cubemap face amount for texture {i} with hash 0x{tex.HASHID:X}. Six faces are required.");
                    }
                }

                int dataOffset = d.readInt() + headerPtr;
                d.readInt();
                d.readInt();
                d.readInt();

                //The size of a single cubemap face (discounting mipmaps). I don't know why it is repeated. If mipmaps are present, this is also specified in the mipSize section anyway.
                int cmapSize1 = 0;
                int cmapSize2 = 0;
                if (isCubemap)
                {
                    cmapSize1 = d.readInt();
                    cmapSize2 = d.readInt();
                    d.skip(8);
                }

                int[] mipSizes = new int[mipMapCount];
                if (mipMapCount == 1)
                {
                    if (isCubemap)
                        mipSizes[0] = cmapSize1;
                    else
                        mipSizes[0] = dataSize;
                }
                else
                {
                    for (byte mipLevel = 0; mipLevel < mipMapCount; ++mipLevel)
                    {
                        mipSizes[mipLevel] = d.readInt();
                    }
                    d.align(0x10);
                }

                d.skip(0x10); //eXt data - always the same

                d.skip(4); //GIDX
                d.readInt(); //Always 0x10
                tex.HASHID = d.readInt();
                d.skip(4); // padding align 8

                if (Version == 0x100)
                    dataOffset = d.pos();

                for (byte surfaceLevel = 0; surfaceLevel < surfaceCount; ++surfaceLevel)
                {
                    TextureSurface surface = new TextureSurface();
                    for (byte mipLevel = 0; mipLevel < mipMapCount; ++mipLevel)
                    {
                        byte[] texArray = d.getSection(dataOffset, mipSizes[mipLevel]);
                        surface.mipmaps.Add(texArray);
                        dataOffset += mipSizes[mipLevel];
                    }
                    tex.surfaces.Add(surface);
                }

                if (tex.getNutFormat() == 14 || tex.getNutFormat() == 17)
                {
                    tex.swapChannelOrderUp();
                }

                headerPtr += headerSize;

                Nodes.Add(tex);
            }

            foreach (NutTexture tex in Nodes)
            {
                if (!glTexByHashId.ContainsKey(tex.HASHID))
                {
                    Debug.WriteLine(tex.HASHID);
                    glTexByHashId.Add(tex.HASHID, CreateGlTexture(tex, true));
                }
            }
        }

        public void ReadNTWU(FileData d)
        {
            d.seek(0x4);

            Version = d.readUShort();
            ushort count = d.readUShort();

            d.skip(0x8);
            int headerPtr = 0x10;

            for (ushort i = 0; i < count; ++i)
            {
                d.seek(headerPtr);

                NutTexture tex = new NutTexture();
                tex.type = PixelInternalFormat.Rgba32ui;

                int totalSize = d.readInt();
                d.skip(4);
                int dataSize = d.readInt();
                int headerSize = d.readUShort();
                d.skip(2);

                d.skip(1);
                byte mipMapCount = d.readByte();
                d.skip(1);
                tex.setPixelFormatFromNutFormat(d.readByte());
                tex.Width = d.readUShort();
                tex.Height = d.readUShort();
                d.readInt(); //Always 1?
                uint caps2 = d.readUInt();

                bool isCubemap = false;
                byte surfaceCount = 1;
                if ((caps2 & (uint)DDS.DDSCAPS2.CUBEMAP) == (uint)DDS.DDSCAPS2.CUBEMAP)
                {
                    //Only supporting all six faces
                    if ((caps2 & (uint)DDS.DDSCAPS2.CUBEMAP_ALLFACES) == (uint)DDS.DDSCAPS2.CUBEMAP_ALLFACES)
                    {
                        isCubemap = true;
                        surfaceCount = 6;
                    }
                    else
                    {
                        throw new NotImplementedException($"Unsupported cubemap face amount for texture {i} with hash 0x{tex.HASHID:X}. Six faces are required.");
                    }
                }

                int dataOffset = d.readInt() + headerPtr;
                int mipDataOffset = d.readInt() + headerPtr;
                int gtxHeaderOffset = d.readInt() + headerPtr;
                d.readInt();

                int cmapSize1 = 0;
                int cmapSize2 = 0;
                if (isCubemap)
                {
                    cmapSize1 = d.readInt();
                    cmapSize2 = d.readInt();
                    d.skip(8);
                }

                int imageSize = 0; //Total size of first mipmap of every surface
                int mipSize = 0; //Total size of mipmaps other than the first of every surface
                if (mipMapCount == 1)
                {
                    if (isCubemap)
                        imageSize = cmapSize1;
                    else
                        imageSize = dataSize;
                }
                else
                {
                    imageSize = d.readInt();
                    mipSize = d.readInt();
                    d.skip((mipMapCount - 2) * 4);
                    d.align(0x10);
                }

                d.skip(0x10); //eXt data - always the same

                d.skip(4); //GIDX
                d.readInt(); //Always 0x10
                tex.HASHID = d.readInt();
                d.skip(4); // padding align 8

                d.seek(gtxHeaderOffset);
                GTX.GX2Surface gtxHeader = new GTX.GX2Surface();

                gtxHeader.dim = d.readInt();
                gtxHeader.width = d.readInt();
                gtxHeader.height = d.readInt();
                gtxHeader.depth = d.readInt();
                gtxHeader.numMips = d.readInt();
                gtxHeader.format = d.readInt();
                gtxHeader.aa = d.readInt();
                gtxHeader.use = d.readInt();
                gtxHeader.imageSize = d.readInt();
                gtxHeader.imagePtr = d.readInt();
                gtxHeader.mipSize = d.readInt();
                gtxHeader.mipPtr = d.readInt();
                gtxHeader.tileMode = d.readInt();
                gtxHeader.swizzle = d.readInt();
                gtxHeader.alignment = d.readInt();
                gtxHeader.pitch = d.readInt();

                //mipOffsets[0] is not in this list and is simply the start of the data (dataOffset)
                //mipOffsets[1] is relative to the start of the data (dataOffset + mipOffsets[1])
                //Other mipOffsets are relative to mipOffset[1] (dataOffset + mipOffsets[1] + mipOffsets[i])
                int[] mipOffsets = new int[mipMapCount];
                mipOffsets[0] = 0;
                for (byte mipLevel = 1; mipLevel < mipMapCount; ++mipLevel)
                {
                    mipOffsets[mipLevel] = 0;
                    mipOffsets[mipLevel] = mipOffsets[1] + d.readInt();
                }

                for (byte surfaceLevel = 0; surfaceLevel < surfaceCount; ++surfaceLevel)
                {
                    tex.surfaces.Add(new TextureSurface());
                }

                int w = tex.Width, h = tex.Height;
                for (byte mipLevel = 0; mipLevel < mipMapCount; ++mipLevel)
                {
                    int p = gtxHeader.pitch / (gtxHeader.width / w);

                    int size;
                    if (mipMapCount == 1)
                        size = imageSize;
                    else if (mipLevel + 1 == mipMapCount)
                        size = (mipSize + mipOffsets[1]) - mipOffsets[mipLevel];
                    else
                        size = mipOffsets[mipLevel + 1] - mipOffsets[mipLevel];

                    size /= surfaceCount;

                    for (byte surfaceLevel = 0; surfaceLevel < surfaceCount; ++surfaceLevel)
                    {
                        gtxHeader.data = d.getSection(dataOffset + mipOffsets[mipLevel] + (size * surfaceLevel), size);

                        //Real size
                        //Leave the below line commented for now because it breaks RGBA textures
                        //size = ((w + 3) >> 2) * ((h + 3) >> 2) * (GTX.getBPP(gtxHeader.format) / 8);
                        if (size < (GTX.getBPP(gtxHeader.format) / 8))
                            size = (GTX.getBPP(gtxHeader.format) / 8);

                        byte[] deswiz = GTX.swizzleBC(
                            gtxHeader.data,
                            w,
                            h,
                            gtxHeader.format,
                            gtxHeader.tileMode,
                            p,
                            gtxHeader.swizzle
                        );
                        tex.surfaces[surfaceLevel].mipmaps.Add(new FileData(deswiz).getSection(0, size));
                    }

                    w /= 2;
                    h /= 2;

                    if (w < 1)
                        w = 1;
                    if (h < 1)
                        h = 1;
                }

                headerPtr += headerSize;

                Nodes.Add(tex);
            }

            RefreshGlTexturesByHashId();

            //Console.WriteLine("\tMIP: " + size.ToString("x") + " " + dataOffset.ToString("x") + " " + mipSize.ToString("x") + " " + p + " " + (size == 0 ? ds + dataSize - dataOffset : size));

            //Console.WriteLine(tex.id.ToString("x") + " " + dataOffset.ToString("x") + " " + mipSize.ToString("x") + " " + p + " " + swizzle);
            //Console.WriteLine((tex.width >> mipLevel) + " " + (tex.height >> mipLevel));

            //File.WriteAllBytes("C:\\s\\Smash\\extract\\data\\fighter\\duckhunt\\model\\body\\mip1.bin", bytearray);

            //Console.WriteLine(GL.GetError());
            /*int j = 0;
            foreach(byte[] b in textures[0].mipmaps)
            {
                if (j == 3)
                {
                    for(int w = 3; w < 8; w++)
                    {
                        for (int p = 3; p < 6; p++)
                        {
                            byte[] deswiz = GTX.swizzleBC(
                                b,
                                (int)Math.Pow(2, w),
                                64,
                                51,
                                4,
                                 (int)Math.Pow(2, p),
                                197632
                            );
                            File.WriteAllBytes("C:\\s\\Smash\\extract\\data\\fighter\\duckhunt\\model\\body\\chunk_" + (int)Math.Pow(2, p) + "_" + (int)Math.Pow(2, w), deswiz);
                        }
                    }
                    
                }
                j++;
            }*/
        }

        public void RefreshGlTexturesByHashId()
        {
            glTexByHashId.Clear();

            foreach (NutTexture tex in Nodes)
            {
                if (!glTexByHashId.ContainsKey(tex.HASHID))
                {
                    glTexByHashId.Add(tex.HASHID, CreateGlTexture(tex, false));
                }
            }
        }

        public static bool texIdUsed(int texId)
        {
            foreach (var nut in Runtime.TextureContainers)
                foreach(NutTexture tex in nut.Nodes)
                    if (tex.HASHID == texId)
                        return true;
            return false;
        }

        public void ChangeTextureIds(int newTexId)
        {
            // Check if tex ID fixing would cause any naming conflicts. 
            if (TexIdDuplicate4thByte())
            {
                MessageBox.Show("The first six digits should be the same for all textures to prevent duplicate IDs after changing the Tex ID.",
                    "Duplicate Texture ID");
                return;
            }

            foreach (NutTexture tex in Nodes)
            {
                int originalTexture = glTexByHashId[tex.HASHID];
                glTexByHashId.Remove(tex.HASHID);

                // Only change the first 3 bytes.
                tex.HASHID = tex.HASHID & 0xFF;
                int first3Bytes = (int)(newTexId & 0xFFFFFF00);
                tex.HASHID = tex.HASHID | first3Bytes;

                glTexByHashId.Add(tex.HASHID, originalTexture);
            }
        }

        public bool TexIdDuplicate4thByte()
        {
            // Check for duplicates. 
            List<byte> previous4thBytes = new List<byte>();
            foreach (NutTexture tex in Nodes)
            {
                byte fourthByte = (byte) (tex.HASHID & 0xFF);
                if (!(previous4thBytes.Contains(fourthByte)))
                    previous4thBytes.Add(fourthByte);
                else
                    return true;
                    
            }

            return false;
        }

        public void Destroy()
        {
            DeleteGlTextures();
            Nodes.Clear();
        }

        private void DeleteGlTextures()
        {
            foreach (var kv in glTexByHashId)
            {
                if (GL.IsTexture(kv.Value))
                    GL.DeleteTexture(kv.Value);
            }
        }

        public override string ToString()
        {
            return "NUT";
        }

        public static int CreateGlTexture(NutTexture t, bool isDds = false)
        {
            int texID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texID);

            bool compressedFormatWithMipMaps = t.type == PixelInternalFormat.CompressedRgbaS3tcDxt1Ext
                || t.type == PixelInternalFormat.CompressedRgbaS3tcDxt3Ext
                || t.type == PixelInternalFormat.CompressedRgbaS3tcDxt5Ext
                || t.type == PixelInternalFormat.CompressedRedRgtc1
                || t.type == PixelInternalFormat.CompressedRgRgtc2;

            if (compressedFormatWithMipMaps)
            {
                // Always load the first level.
                GL.CompressedTexImage2D<byte>(TextureTarget.Texture2D, 0, t.type, t.Width, t.Height, 0, t.Size, t.surfaces[0].mipmaps[0]);

                // Reading mip maps past the first level is only supported for DDS currently.
                if (t.surfaces[0].mipmaps.Count > 1 && isDds)
                    LoadMipMapsCompressed(t);
                else
                    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }
            else
            {
                AutoGenerateMipMaps(t);
            }

            return texID;
        }

        private static void AutoGenerateMipMaps(NutTexture t)
        {
            for (int i = 0; i < t.surfaces.Count; ++i)
            {
                // Only load the first level and generate the other mip maps.
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, t.surfaces[i].mipmaps.Count);
                GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, t.type, t.Width, t.Height, 0, t.utype, t.PixelType, t.surfaces[i].mipmaps[0]);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }
        }

        private static void LoadMipMapsCompressed(NutTexture t)
        {
            for (int i = 0; i < t.surfaces.Count; ++i)
            {
                // Generate the mip maps.
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, t.surfaces[i].mipmaps.Count);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                // Initialize the data for each level.
                for (int j = 0; j < t.surfaces[i].mipmaps.Count; ++j)
                {
                    GL.CompressedTexImage2D<byte>(TextureTarget.Texture2D, j, t.type,
                     t.Width / (int)Math.Pow(2, j), t.Height / (int)Math.Pow(2, j), 0, t.surfaces[i].mipmaps[j].Length, t.surfaces[i].mipmaps[j]);
                }
            }
        }
    }
}
