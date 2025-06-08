using System;
using System.Collections.Generic;

namespace ApnaBazaar.Models.Db;

public partial class ProductGallery
{
    public int Id { get; set; }

    public int? ProducrId { get; set; }

    public string? ImageName { get; set; }
}
