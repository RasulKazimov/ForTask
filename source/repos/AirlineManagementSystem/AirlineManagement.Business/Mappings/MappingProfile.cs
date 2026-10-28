using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AirlineManagement.Application.DTOs;
using AirlineManagement.Domain.Entities;

namespace AirlineManagement.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAircraftDto, Aircraft>();
        CreateMap<UpdateAircraftDto, Aircraft>();
        CreateMap<Aircraft, AircraftResponseDto>();

        CreateMap<CreateAirportDto, Airport>();
        CreateMap<UpdateAirportDto, Airport>();
        CreateMap<Airport, AirportResponseDto>();

        CreateMap<CreateFlightDto, Flight>();
        CreateMap<UpdateFlightDto, Flight>();
        CreateMap<Flight, FlightResponseDto>()
            .ForMember(dest => dest.AircraftModel, opt => opt.MapFrom(src => src.Aircraft.Model))
            .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.DepartureAirport.Name))
            .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.ArrivalAirport.Name));

        CreateMap<CreatePassengerDto, Passenger>();
        CreateMap<UpdatePassengerDto, Passenger>();
        CreateMap<Passenger, PassengerResponseDto>();

        CreateMap<Reservation, ReservationResponseDto>()
            .ForMember(dest => dest.PassengerName, opt => opt.MapFrom(src => src.Passenger.FullName))
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.FlightNumber));
        CreateMap<Reservation, ReservationSummaryDto>()
            .ForMember(dest => dest.PassengerName, opt => opt.MapFrom(src => src.Passenger.FullName))
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.FlightNumber));

        CreateMap<Ticket, TicketResponseDto>()
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Reservation.Flight.FlightNumber));

        CreateMap<CreateFlightPriceRuleDto, FlightPriceRule>();
        CreateMap<UpdateFlightPriceRuleDto, FlightPriceRule>();
        CreateMap<FlightPriceRule, FlightPriceRuleResponseDto>();
    }
}