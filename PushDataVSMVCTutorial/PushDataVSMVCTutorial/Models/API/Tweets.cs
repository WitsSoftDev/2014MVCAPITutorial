using System;

namespace PushDataVSMVCTutorial.Models.API
{
    using System.ComponentModel.DataAnnotations;

    public class Tweets
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string FromUser { get; set; }
        [Required]
        public string IdStr { get; set; }
        [Required]
        public string Text { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}