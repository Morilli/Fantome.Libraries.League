using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fantome.Libraries.League.IO.RMAN
{
    public class RMANUnknownSector
    {
        public long Offset { get; private set; }
        public List<RMANUnknownEntry> Entries { get; private set; } = new List<RMANUnknownEntry>();

        public RMANUnknownSector(BinaryReader br)
        {
            uint unknownSize = br.ReadUInt32();
            byte[] unknownData = br.ReadBytes((int)unknownSize - 4);
            uint offsetsCount = br.ReadUInt32();
            this.Offset = br.BaseStream.Position;

            uint[] offsets = new uint[offsetsCount];
            for (int i = 0; i < offsetsCount; i++)
            {
                offsets[i] = br.ReadUInt32();
            }
            for (int i = 0; i < offsets.Length; i++)
            {
                this.Entries.Add(new RMANUnknownEntry(br));
            }
        }
    }
}
