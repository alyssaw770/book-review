using AutoMapper;
using BookReviewApp.Interfaces;
using BookReviewApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountryRepository : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryRepository(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        //maker sure parameter matches HttpGet parameter or API will not work
        public IActionResult GetCountry(int countryId)
        {
            if(!_countryRepository.CountryExits(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }
        [HttpGet("/authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByAuthor(authorId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
                                                    
        }
    }
}