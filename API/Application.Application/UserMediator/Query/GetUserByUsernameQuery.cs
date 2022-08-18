using API.Application.Application.Model;
using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.UserMediator.Query
{
    public record GetUserByUsernameQuery : IRequest<GetUserResponse>
    {
        public string Username {get;set;}
    }

    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, GetUserResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUserByUsernameHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetUserResponse> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(user => user.Username == request.Username)
                                    .ProjectTo<GetUserResponse>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();

            if(user == null) throw new UnauthorizedAccessException("User doesn't exist");

            return user;
        }
    }
}