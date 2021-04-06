using medigold_backend.Helpers;
using medigold_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        DatabaseConnection databaseConnection = new DatabaseConnection("server=localhost; port=3306; database=MediGold; user=root; password=; convert zero datetime=True");

        [HttpGet]
        [Route("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            List<Patient> patientListFromDB = databaseConnection.GetAllPatients();
            return StatusCode(200, patientListFromDB);
        }

        [HttpPost]
        [Route("UpdatePatient")]
        public IActionResult UpdatePatient(UpdatePatientRequest request)
        {
            string response = databaseConnection.UpdatePatient(request.Id, request.Name, request.OutcomeDate, request.Status);
            return StatusCode(200, response);
        }

        [HttpPost]
        [Route("InsertPatient")]
        public IActionResult InsertPatient(InsertPatientRequest request)
        {
            string response = databaseConnection.InsertPatient(request.Name, request.DoB, request.InfectionDate);
            return StatusCode(200, response);
        }

        [HttpDelete]
        [Route("DeletePatient")]
        public IActionResult DeletePatient(int Id)
        {
            string response = databaseConnection.DeletePatient(Id);
            return StatusCode(200, response);
        }

        [HttpGet]
        [Route("GetInfectionsData")]
        public IActionResult GetInfectionsData()
        {
            List<CovidTrend> infectionsPerDay = databaseConnection.GetInfectionsData();
            return StatusCode(200, infectionsPerDay);
        }
    }

}
