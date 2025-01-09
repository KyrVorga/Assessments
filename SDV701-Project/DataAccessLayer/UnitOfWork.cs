namespace DataAccessLayer
{
    /// <summary>
    /// Represents a unit of work and manages repository instances.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ModelContext _context;
        private ClientRepository _clientRepository;
        private PetRepository _petRepository;
        private PetOwnerRepository _petOwnerRepository;
        private VeterinarianRepository _veterinarianRepository;
        private RoomRepository _roomRepository;
        private BookingRepository _bookingRepository;
        private ScheduleRepository _scheduleRepository;
        private TaskRepository _taskRepository;
        private TraitRepository _traitRepository;
        private PetTraitRepository _petTraitRepository;
        private PetVeterinarianRepository _petVeterinarianRepository;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Property for accessing the ClientRepository.
        /// </summary>
        public ClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_context);
                }
                return _clientRepository;
            }
        }

        /// <summary>
        /// Property for accessing the PetRepository.
        /// </summary>
        public PetRepository PetRepository
        {
            get
            {
                if (_petRepository == null)
                {
                    _petRepository = new PetRepository(_context);
                }
                return _petRepository;
            }
        }

        /// <summary>
        /// Property for accessing the PetOwnerRepository.
        /// </summary>
        public PetOwnerRepository PetOwnerRepository
        {
            get
            {
                if (_petOwnerRepository == null)
                {
                    _petOwnerRepository = new PetOwnerRepository(_context);
                }
                return _petOwnerRepository;
            }
        }

        /// <summary>
        /// Property for accessing the VeterinarianRepository.
        /// </summary>
        public VeterinarianRepository VeterinarianRepository
        {
            get
            {
                if (_veterinarianRepository == null)
                {
                    _veterinarianRepository = new VeterinarianRepository(_context);
                }
                return _veterinarianRepository;
            }
        }

        /// <summary>
        /// Property for accessing the RoomRepository.
        /// </summary>
        public RoomRepository RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_context);
                }
                return _roomRepository;
            }
        }

        /// <summary>
        /// Property for accessing the BookingRepository.
        /// </summary>
        public BookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_context);
                }
                return _bookingRepository;
            }
        }

        /// <summary>
        /// Property for accessing the ScheduleRepository.
        /// </summary>
        public ScheduleRepository ScheduleRepository
        {
            get
            {
                if (_scheduleRepository == null)
                {
                    _scheduleRepository = new ScheduleRepository(_context);
                }
                return _scheduleRepository;
            }
        }

        /// <summary>
        /// Property for accessing the TaskRepository.
        /// </summary>
        public TaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_context);
                }
                return _taskRepository;
            }
        }

        /// <summary>
        /// Property for accessing the TraitRepository.
        /// </summary>
        public TraitRepository TraitRepository
        {
            get
            {
                if (_traitRepository == null)
                {
                    _traitRepository = new TraitRepository(_context);
                }
                return _traitRepository;
            }
        }

        /// <summary>
        /// Property for accessing the PetTraitRepository.
        /// </summary>
        public PetTraitRepository PetTraitRepository
        {
            get
            {
                if (_petTraitRepository == null)
                {
                    _petTraitRepository = new PetTraitRepository(_context);
                }
                return _petTraitRepository;
            }
        }

        /// <summary>
        /// Property for accessing the PetVeterinarianRepository.
        /// </summary>
        public PetVeterinarianRepository PetVeterinarianRepository
        {
            get
            {
                if (_petVeterinarianRepository == null)
                {
                    _petVeterinarianRepository = new PetVeterinarianRepository(_context);
                }
                return _petVeterinarianRepository;
            }
        }

        /// <summary>
        /// Disposes the context and repositories to free up resources.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method (its value is true) or from a finalizer (its value is false).</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) { _context.Dispose(); }
            }
            _disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
