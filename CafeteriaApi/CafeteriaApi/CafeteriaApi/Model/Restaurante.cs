﻿using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public decimal? Avaliacao { get; set; }
    }
}
