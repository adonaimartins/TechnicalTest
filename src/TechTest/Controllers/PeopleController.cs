using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechTest.Repositories;
using TechTest.Repositories.Models;

namespace TechTest.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository; // global PersonRepository is set to person REpository
        }

        private IPersonRepository PersonRepository { get; } //Global variable

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Person> person = this.PersonRepository.GetAll(); 

            return this.Ok(person);
            // TODO: Step 1
            //
            // Implement a JSON endpoint that returns the full list
            // of people from the PeopleRepository. If there are zero
            // people returned from PeopleRepository then an empty
            // JSON array should be returned.

        }//END OF METHOD

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = this.PersonRepository.Get(id);

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
            // TODO: Step 2
            //
            // Implement a JSON endpoint that returns a single person
            // from the PeopleRepository based on the id parameter.
            // If null is returned from the PeopleRepository with
            // the supplied id then a NotFound should be returned.
        }//END OF METHOD

        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonUpdate personUpdate)
        {
            Person person = this.PersonRepository.Get(id);

            if (person == null)
            {
                return NotFound(); //returns not found if the object is not found
            }
            else
            {
                //change values of object to the ones received
                person.Authorised = personUpdate.Authorised;
                person.Enabled = personUpdate.Enabled;
                person.Colours = personUpdate.Colours;

                this.PersonRepository.Update(person); //
                return Ok(person);//returns an OK response with a person object
            }

            // TODO: Step 3
            //
            // Implement an endpoint that receives a JSON object to
            // update a person using the PeopleRepository based on
            // the id parameter. Once the person has been successfully
            // updated, the person should be returned from the endpoint.
            // If null is returned from the PeopleRepository then a
            // NotFound should be returned.
        }//END OF METHOD
    }
}