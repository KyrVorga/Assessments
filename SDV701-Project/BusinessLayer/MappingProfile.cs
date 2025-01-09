using AutoMapper;
using DataAccessLayer.Models;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Defines the mapping profile for AutoMapper to map between entity models and DTOs.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Map Cat to CatModel
            CreateMap<Cat, CatModel>()
                .ForMember(dest => dest.OwnerIDs, opt => opt.MapFrom(src => src.PetOwners.Select(po => po.ClientID).ToList()))
                .ForMember(dest => dest.BookingIDs, opt => opt.MapFrom(src => src.Bookings.Select(b => b.ID).ToList()))
                .ForMember(dest => dest.TraitIDs, opt => opt.MapFrom(src => src.PetTraits.Select(pt => pt.TraitID).ToList()))
                .ForMember(dest => dest.VeterinarianIDs, opt => opt.MapFrom(src => src.PetVeterinarians.Select(pv => pv.VeterinarianID).ToList()));

            CreateMap<Cat, IPetModel>().As<CatModel>();

            // Map Bird to BirdModel
            CreateMap<Bird, BirdModel>()
                .ForMember(dest => dest.OwnerIDs, opt => opt.MapFrom(src => src.PetOwners.Select(po => po.ClientID).ToList()))
                .ForMember(dest => dest.BookingIDs, opt => opt.MapFrom(src => src.Bookings.Select(b => b.ID).ToList()))
                .ForMember(dest => dest.TraitIDs, opt => opt.MapFrom(src => src.PetTraits.Select(pt => pt.TraitID).ToList()))
                .ForMember(dest => dest.VeterinarianIDs, opt => opt.MapFrom(src => src.PetVeterinarians.Select(pv => pv.VeterinarianID).ToList()));

            CreateMap<Bird, IPetModel>().As<BirdModel>();

            // Map Client to ClientModel
            CreateMap<Client, ClientModel>()
                .ForMember(dest => dest.PetIDs, opt => opt.MapFrom(src => src.PetOwners.Select(po => po.PetID).ToList()))
                .ForMember(dest => dest.BookingIDs, opt => opt.MapFrom(src => src.Bookings.Select(b => b.ID).ToList()));


            // Map Booking to BookingModel
            CreateMap<Booking, BookingModel>();

            // Map Room to RoomModel
            CreateMap<Room, RoomModel>();


            // Map Task to TaskModel
            CreateMap<DataAccessLayer.Models.Task, TaskModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => src.Measurement.ToString()))
                .ForMember(dest => dest.ScheduleIDs, opt => opt.MapFrom(src => src.Schedules.Select(s => s.ID).ToList()));

            // Map Veterinarian to VeterinarianModel
            CreateMap<Veterinarian, VeterinarianModel>();

            // Map Schedule to ScheduleModel
            CreateMap<Schedule, ScheduleModel>();

            // Map Trait to TraitModel
            CreateMap<Trait, TraitModel>();





            // Reverse mappings
            CreateMap<CatModel, Cat>()
                .ForMember(dest => dest.PetOwners, opt => opt.MapFrom(src => src.OwnerIDs.Select(id => new PetOwner { ClientID = id }).ToList()))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.BookingIDs.Select(id => new Booking { ID = id }).ToList()))
                .ForMember(dest => dest.PetTraits, opt => opt.MapFrom(src => src.TraitIDs.Select(id => new PetTrait { TraitID = id }).ToList()))
                .ForMember(dest => dest.PetVeterinarians, opt => opt.MapFrom(src => src.VeterinarianIDs.Select(id => new PetVeterinarian { VeterinarianID = id }).ToList()));

            CreateMap<BirdModel, Bird>()
                .ForMember(dest => dest.PetOwners, opt => opt.MapFrom(src => src.OwnerIDs.Select(id => new PetOwner { ClientID = id }).ToList()))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.BookingIDs.Select(id => new Booking { ID = id }).ToList()))
                .ForMember(dest => dest.PetTraits, opt => opt.MapFrom(src => src.TraitIDs.Select(id => new PetTrait { TraitID = id }).ToList()))
                .ForMember(dest => dest.PetVeterinarians, opt => opt.MapFrom(src => src.VeterinarianIDs.Select(id => new PetVeterinarian { VeterinarianID = id }).ToList()));

            CreateMap<ClientModel, Client>()
                .ForMember(dest => dest.PetOwners, opt => opt.MapFrom(src => src.PetIDs.Select(id => new PetOwner { PetID = id }).ToList()))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.BookingIDs.Select(id => new Booking { ID = id }).ToList()));

            CreateMap<BookingModel, Booking>();

            CreateMap<RoomModel, Room>();

            CreateMap<TaskModel, DataAccessLayer.Models.Task>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => src.Measurement))
                .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.ScheduleIDs.Select(id => new Schedule { ID = id }).ToList()));


            CreateMap<VeterinarianModel, Veterinarian>();
            CreateMap<ScheduleModel, Schedule>();
            CreateMap<TraitModel, Trait>();

        }
    }
}
