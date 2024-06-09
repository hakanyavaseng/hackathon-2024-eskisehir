using HackAPI.Entities.DTOs.Analysis;
using HackAPI.Entities.Entities;
using HackAPI.Entities.Enums;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedCarbonEmission : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public SavedCarbonEmission(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        //0.6872 kg co2 per km for a fossil fuel truck
        //0.2226 kg co2 per km for a electric truck
        //0.6872-0.2226 = 0.4646 kg co2 per km saved
        //Calculate the total saved co2 emission
       





    }
}
