using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IUnitOfWork unitOfWork;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            this.locationRepository = locationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateLocation(Location location)
        {
            locationRepository.AddLocation(location);

            unitOfWork.Commit();
        }
    }
}
