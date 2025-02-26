using Entits;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingServices : IRatingServices
    {
        AdoNetManageContext _AdoNetManageContext;
        private readonly ILogger<UserRepository> _logger;
        RatingRepository ratingRepository;

        public RatingServices(AdoNetManageContext manageDbContext, ILogger<UserRepository> logger, RatingRepository _ratingRepository)
        {
            ratingRepository = _ratingRepository;
            this._AdoNetManageContext = manageDbContext;
            _logger = logger;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            return await ratingRepository.AddRating(rating);
        }

    }
}
