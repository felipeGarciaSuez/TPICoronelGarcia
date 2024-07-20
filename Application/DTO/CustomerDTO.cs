﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CustomerDto : UserDto
    {
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
