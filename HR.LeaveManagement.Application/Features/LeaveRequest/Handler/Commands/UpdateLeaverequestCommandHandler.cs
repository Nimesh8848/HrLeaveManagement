using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Request.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handler.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaverequest = await _leaveRequestRepository.Get(request.Id);
            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaverequest);
                await _leaveRequestRepository.Update(leaverequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null) {
                await _leaveRequestRepository.ChangeApprovalStatus(leaverequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }
            return Unit.Value;

        }
    }
}