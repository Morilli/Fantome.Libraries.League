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
                ushort[] section1UnknownShorts = new ushort[(section1Length - 4) / 2];

                for (int i = 0; i < (section1Length - 4) / 2; i++)
                {
                    section1UnknownShorts[i] = br.ReadUInt16();
                }

                uint section1Unknown = br.ReadUInt32();
            }
        }
    }
}
