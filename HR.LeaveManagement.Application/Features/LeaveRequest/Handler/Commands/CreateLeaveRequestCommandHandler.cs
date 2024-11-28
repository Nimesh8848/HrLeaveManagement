using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Request.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
           

            // Map LeaveRequestDto to LeaveRequest domain model
            var leaveRequest = _mapper.Map<HR.LeaveManagement.Domain.LeaveRequest>(request.LeaveRequestDto);

            // Save to repository
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

    

            // Return the Id of the created leave request
            return leaveRequest.Id;
        }
    }
}
