﻿namespace Adv.BLL.DTO.Address
{
    public class BoundedByDto
    {
        public int Id { get; set; }
        public int EnvelopeId { get; set; }
        public EnvelopeDto Envelope { get; set; }
    }
}