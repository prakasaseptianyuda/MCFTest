using System;
using System.Collections.Generic;

namespace Service1.API.Entities
{
    public partial class MsStorageLocation
    {
        public MsStorageLocation()
        {
            TrBpkb = new HashSet<TrBpkb>();
        }

        public string LocationId { get; set; } = null!;
        public string? LocationName { get; set; }

        public virtual ICollection<TrBpkb> TrBpkb { get; set; }
    }
}
