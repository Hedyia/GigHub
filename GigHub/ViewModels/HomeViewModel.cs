using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpCommingGigs { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}