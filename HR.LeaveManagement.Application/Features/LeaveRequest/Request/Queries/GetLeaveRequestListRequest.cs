﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDto>>
    {
    }
}
