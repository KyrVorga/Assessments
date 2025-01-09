namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        BookingRepository BookingRepository { get; }
        ClientRepository ClientRepository { get; }
        PetRepository PetRepository { get; }
        PetOwnerRepository PetOwnerRepository { get; }
        RoomRepository RoomRepository { get; }
        VeterinarianRepository VeterinarianRepository { get; }
        TaskRepository TaskRepository { get; }
        TraitRepository TraitRepository { get; }
        ScheduleRepository ScheduleRepository { get; }
        PetTraitRepository PetTraitRepository { get; }
        PetVeterinarianRepository PetVeterinarianRepository { get; }

        void Dispose();
        void Save();
    }
}