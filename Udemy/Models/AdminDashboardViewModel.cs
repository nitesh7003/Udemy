using System.Collections.Generic;

namespace Udemy.Models
{
    public class AdminDashboardViewModel
    {
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public Topic NewTopic { get; set; } = new Topic();
        public int VideoCount { get; set; } // New property for video count



    }
}
