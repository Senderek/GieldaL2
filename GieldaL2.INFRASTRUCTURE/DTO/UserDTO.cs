﻿using System;

namespace GieldaL2.INFRASTRUCTURE.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string EMail { get; set; }
        public decimal Value { get; set; }
    }
}
