using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookBoundCoreAPI.Entities;
using BookBoundCoreAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookBoundCoreAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));  
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Author>>> GetAuthors()
        {
            var authorEntities = await _authorsRepository.GetAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<Models.Author>>(authorEntities));
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<ActionResult<Models.Author>> GetAuthor(int authorId)
        {
            var authorEntity = await _authorsRepository.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Models.Author>(authorEntity));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(
            [FromBody] Models.AuthorForCreation authorForCreation)
        {
            // model validation
            if (authorForCreation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                // return 422 - Unprocessable Entity when validation fails
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var authorEntity = _mapper.Map<Author>(authorForCreation);
            _authorsRepository.AddAuthor(authorEntity);

            // save the changes
            await _authorsRepository.SaveChangesAsync();

            // Fetch the author from the data store
            await _authorsRepository.GetAuthorAsync(authorEntity.Id);

            return CreatedAtRoute("GetAuthor",
                new { authorId = authorEntity.Id },
                _mapper.Map<Models.Author>(authorEntity));
        }

        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId,
            [FromBody] Models.AuthorForUpdate authorforUpdate)
        {
            // model validation
            if (authorforUpdate == null)
            {
                //return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                // return 422 - Unprocessable Entity when validation fails
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var authorEntity = await _authorsRepository.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            // map the inputted object into the author entity
            // this ensures properties will get updated
            _mapper.Map(authorforUpdate, authorEntity);

            // call into UpdateAuthor even though in our implementation 
            // this doesn't contain code - doing this ensures the code stays
            // reliable when other repository implemenations (eg: a mock 
            // repository) are used.
            _authorsRepository.UpdateAuthor(authorEntity);

            await _authorsRepository.SaveChangesAsync();

            // return the updated author, after mapping it
            return Ok(_mapper.Map<Models.Author>(authorEntity));
        }

        [HttpPatch("{authorId}")]
        public async Task<IActionResult> PartiallyUpdateAuthor(int authorId,
            [FromBody] JsonPatchDocument<Models.AuthorForUpdate> patchDoc)
        {
            var authorEntity = await _authorsRepository.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            // the patch is on a DTO, not on the movie entity
            var authorToPatch = Mapper.Map<Models.AuthorForUpdate>(authorEntity);

            patchDoc.ApplyTo(authorToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            // map back to the entity, and save
            Mapper.Map(authorToPatch, authorEntity);

            // call into UpdateAuthor even though in our implementation 
            // this doesn't contain code - doing this ensures the code stays
            // reliable when other repository implemenations (eg: a mock 
            // repository) are used.
            _authorsRepository.UpdateAuthor(authorEntity);

            await _authorsRepository.SaveChangesAsync();

            // return the updated author, after mapping it
            return Ok(_mapper.Map<Models.Author>(authorEntity));
        } 

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var authorEntity = await _authorsRepository.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            _authorsRepository.DeleteAuthor(authorEntity);
            await _authorsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}