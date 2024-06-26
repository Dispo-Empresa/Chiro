﻿using System.ComponentModel.DataAnnotations;

namespace Chiro.Domain.DTOs
{
    public class ResizeProjectDTO
    {
        [Required(ErrorMessage = "O campo Id deve ser preenchido.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Width deve ser preenchido.")]
        public double Width { get; set; }

        [Required(ErrorMessage = "O campo Height deve ser preenchido.")]
        public double Height { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }
    }
}
