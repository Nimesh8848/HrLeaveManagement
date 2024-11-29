using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Request.Commands
{
    public class DeleteLeaveAllocationCommand:IRequest
    {
        public int Id { get; set; }
    }
}
