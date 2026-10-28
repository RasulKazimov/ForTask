using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagement.Application.DTOs;

namespace AirlineManagement.Application.Services;

public interface IReservationService
{
    Task<ReservationResponseDto> CreateReservationAsync(CreateReservationDto dto);
    Task CancelReservationAsync(int id, string reason);
    Task<IEnumerable<ReservationSummaryDto>> GetAllReservationsAsync();
}