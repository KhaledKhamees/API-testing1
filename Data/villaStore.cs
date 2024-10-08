﻿using Apitest.Models;
using Apitest.Models.DTO;

namespace Apitest.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> Villas = new List<VillaDTO>()
        {
            new VillaDTO
            {
                Id = 1,
                Name = "Villa1",
            },
            new VillaDTO
            {
                Id = 2,
                Name = "Villa2",
            }
        };
    }
}
