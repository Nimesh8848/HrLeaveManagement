using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Request.Commands
{
    public class CreateLeaveTypeCommand:IRequest<int>
    {
        public  CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
