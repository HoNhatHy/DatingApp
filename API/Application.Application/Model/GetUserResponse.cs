﻿namespace API.Application.Application.Model
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public List<PhotoResponse> Photos { get; set; }
    }
}
