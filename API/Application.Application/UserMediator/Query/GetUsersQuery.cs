using API.Application.Application.Model;
using API.Application.Infrastructure.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Application.UserMediator.Query
{
    public record GetUsersQuery : IRequest<List<GetUserResponse>>;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUserResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mapper.ProjectTo<GetUserResponse>(_context.Users).ToListAsync();
            return response;
        }
    }
}
