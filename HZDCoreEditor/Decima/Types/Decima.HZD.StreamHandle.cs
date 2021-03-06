﻿using BinaryStreamExtensions;
using System.IO;
using System.Text;

namespace Decima.HZD
{
    public class StreamHandle
    {
        public string ResourcePath;
        public ulong Unknown1;
        public ulong Unknown2;

        public static StreamHandle FromData(BinaryReader reader)
        {
            var x = new StreamHandle();
            uint stringLength = reader.ReadUInt32();

            if (stringLength > 0)
                x.ResourcePath = Encoding.UTF8.GetString(reader.ReadBytesStrict(stringLength));

            // Likely file offsets or length
            x.Unknown1 = reader.ReadUInt64();
            x.Unknown2 = reader.ReadUInt64();

            return x;
        }
    }
}