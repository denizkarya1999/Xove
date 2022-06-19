using Xove.Domain.Models;
using System;

namespace Xove.Domain
{
    public static class SeedData
    {
        public static Guid DenizId = Guid.Parse("2ec15541-e319-4236-9f8e-d2aeebe22261");
        public static Partner Deniz => new Partner()
        {
            Age = 22,
            CurrentPosition = "Student - University of Michigan-Dearborn",
            FullName = "Deniz K Acikbas",
            Gender = "Cis Male",
            Interests = "Programming, Drawing, Cars, Video Games, Music, Netflix & Chill",
            Location = "Dearborn, Michigan",
            SexualOrientation = "Bisexual",
            ShortBiography = "Knows English, German and Turkish"
        };
    }
}
