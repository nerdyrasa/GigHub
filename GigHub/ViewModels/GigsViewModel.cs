using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigsViewModel
    {
        public ILookup<int, Attendance> Attendances;
        public ILookup<string, Following> Followings;

        public IEnumerable<Gig> UpcomingGigs { get; set; }

    }
}