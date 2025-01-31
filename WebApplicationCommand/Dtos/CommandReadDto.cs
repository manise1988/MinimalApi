﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationCommand.Dtos
{
    public class CommandReadDto
    {
        public string? HowTo { get; set; }

        public string? Platform { get; set; }

        public string? CommandLine { get; set; }
    }
}
