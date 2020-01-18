using System;
using System.Collections.Generic;
using Reminder.Data.Core;

namespace Reminder.Data.Models
{
    [Serializable]
    public class Note : Entity
    {
        public Note()
        {
            GalleryItems = new List<GalleryItemModel>();
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public string UserId { get; set; }

        public UserModel User { get; set; }
        public ICollection<GalleryItemModel> GalleryItems { get; set; }
    }
}