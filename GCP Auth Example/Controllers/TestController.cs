using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCP_Auth_Example.Models;
using GCP_Auth_Example.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GCP_Auth_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly FirebaseClient _firebaseClient;

        public TestController(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result  = await _firebaseClient.FetchDataFromFireStore<Student>("student").ConfigureAwait(false);
            return Ok(result);
        }
    }
}