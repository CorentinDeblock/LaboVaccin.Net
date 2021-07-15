using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class Lot
    {
        [Key]
        public int Id { get; set; }
        public uint LotId { get; set; }

        public int ProviderId { get; set; }

        public Provider Provider { get; set; }
    }
}
