using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Request.Commands
{
    public class DeleteLeaveRequestCommand:IRequest
    {
        public int Id { get; set; }
    }
}
