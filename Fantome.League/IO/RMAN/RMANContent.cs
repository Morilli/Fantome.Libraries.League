using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.Libraries.League.IO.RMAN
{
    public class RMANContent
    {
        public RMANContent(byte[] data)
        {
            using (BinaryReader br = new BinaryReader(new MemoryStream(data)))
            {
                uint section1Length = br.ReadUInt32();
                ushort[] section1UnknownShorts = new ushort[section1Length];

                for (int i = 0; i < section1Length / 2; i++)
                {
                    section1UnknownShorts[i] = br.ReadUInt16();
                }

                //---------------------------------------------------------------

                long section2Position = br.BaseStream.Position;
                uint section2Length = br.ReadUInt32();
                uint[] section2Offsets = new uint[(section2Length - 4) / 4];

                for (int i = 0; i < (section2Length - 4) / 4; i++)
                {
                    section2Offsets[i] = br.ReadUInt32();
                }

                //---------------------------------------------------------------

                long section3Position = br.BaseStream.Position;
                uint section3OffsetCount = br.ReadUInt32();
                uint[] section3Offsets = new uint[section3OffsetCount];

                for (int i = 0; i < section3OffsetCount; i++)
                {
                    section3Offsets[i] = br.ReadUInt32();
                }

                //---------------------------------------------------------------

                int section4Unknown1 = br.ReadInt32();
                uint section4Length = br.ReadUInt32();
                byte[] section4Unknown2 = br.ReadBytes((int)section4Length - 4);
                uint section5OffsetsCount = br.ReadUInt32();
                long section5Position = br.BaseStream.Position;
                uint[] section5Offsets = new uint[section5OffsetsCount];

                for (int i = 0; i < section5OffsetsCount; i++)
                {
                    section5Offsets[i] = br.ReadUInt32();
                }

                //---------------------------------------------------------------

                List<RMANUnknownEntry> unknownStructs1 = new List<RMANUnknownEntry>();
                for(int i = 0; i < section5Offsets.Length; i++)
                {
                    unknownStructs1.Add(new RMANUnknownEntry(br));
                }
                
            }
        }
    }
}
