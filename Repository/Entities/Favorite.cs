﻿namespace Repository.Entities
{
    public class Favorite : BaseEntity
    {
        public string MovieId { get; set; }
        public string Image { get; set; }
        public bool IsFavorite { get; set; }
    }
}
