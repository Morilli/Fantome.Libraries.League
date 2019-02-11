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
        public List<uint> Offsets { get; private set; } = new List<uint>();
        public List<RMANUnknownEntry> Entries { get; private set; } = new List<RMANUnknownEntry>();

        public RMANUnknownSector(BinaryReader br)
        {
            uint section4Unknown1 = br.ReadUInt32();
            uint unknownSize = br.ReadUInt32();
            byte[] unknownData = br.ReadBytes((int)unknownSize - 4);
            uint offsetsCount = br.ReadUInt32();
            this.Offset = br.BaseStream.Position;

            for (int i = 0; i < offsetsCount; i++)
            {
                this.Offsets.Add(br.ReadUInt32());
            }
            for (int i = 0; i < this.Offsets.Count; i++)
            {
                br.BaseStream.Seek(this.Offset + this.Offsets[i] + i * 4, SeekOrigin.Begin);
                this.Entries.Add(new RMANUnknownEntry(br));
            }
        }
    }
}
