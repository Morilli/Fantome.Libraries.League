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
        public List<RMANUnknownSector> UnknownSectors { get; private set; } = new List<RMANUnknownSector>();

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

                uint section3OffsetCount = br.ReadUInt32();
                long section3Position = br.BaseStream.Position;
                uint[] section3Offsets = new uint[section3OffsetCount];

                for (int i = 0; i < section3OffsetCount; i++)
                {
                    section3Offsets[i] = br.ReadUInt32();
                }

                //---------------------------------------------------------------

                uint section4Unknown1 = br.ReadUInt32();

                for(int i = 0; i < section3OffsetCount; i++)
                {
                    this.UnknownSectors.Add(new RMANUnknownSector(br));
                }
                
            }
        }
    }
}
