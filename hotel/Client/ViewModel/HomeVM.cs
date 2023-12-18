﻿using System;

namespace Hotel.Client.ViewModel
{
    public class HomeVM
    {
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public int NoOfNights { get; set; } = 1;
    }
}
