using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class RoomImg
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public string? ImgUrl { get; set; }

    public virtual Roomtype? Room { get; set; }
}
