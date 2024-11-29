using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Request.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handler.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,Mapper mapper) {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var Leaveallocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
             _mapper.Map(request.LeaveAllocationDto, Leaveallocation);
            await _leaveAllocationRepository.Update(Leaveallocation);
            return Unit.Value;
        }
    }
}
