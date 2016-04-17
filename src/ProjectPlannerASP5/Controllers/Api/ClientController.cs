using System;
using System.Net;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlanner.Cqrs.Base.CQRS.Commands;
using ProjectPlanner.CRM.Interfaces.Presentation;
using ProjectPlannerASP5.ViewModels;
using System.Linq;
using ProjectPlanner.CRM.Interfaces.Application.Commands;

namespace ProjectPlannerASP5.Controllers.Api
{
    [Authorize]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IGate _gate;
        private readonly ILogger<ClientController> _logger;
        private readonly IClientFinder _clientFinder;

        public ClientController(IGate gate, ILogger<ClientController> logger, IClientFinder clientFinder)
        {
            _gate = gate;
            _logger = logger;
            _clientFinder = clientFinder;
        }

        [HttpGet("")]
        public JsonResult GetAll()
        {
            try
            {   
                var results = _clientFinder.FindClients().ToList();

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get clients", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the clients");
            }
        }

        [HttpGet("{clientId}")]
        public JsonResult Get(int clientId)
        {
            try
            {
                var client = _clientFinder.GetClient(clientId);

                return Json(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the client", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the client");
            }
        }

        [HttpGet("{clientId}/[action]")]
        public JsonResult Details(int clientId)
        {
            var client = _clientFinder.GetClientDetails(clientId);

            if (client == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NoContent;
                return Json(null);
            }

            return Json(client);
        }

        [HttpPost("")]
        public JsonResult Create([FromBody]EditClientViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to saving a new client");

                    var createClientCommand = new CreateClientCommand(vm.Type, vm.Code, vm.Name, vm.Description,
                        vm.Phone, vm.EmailAddress);
                    _gate.Dispatch(createClientCommand);
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new { id = createClientCommand.ClientId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new client", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpPut("")]
        public JsonResult Update([FromBody]EditClientViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to updating client: {vm.Code}.");

                    var changeclientInformationCommand = new ChangeClientInfoCommand(vm.Code, vm.Name, vm.Description,
                        vm.Phone, vm.EmailAddress);
                    _gate.Dispatch(changeclientInformationCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update client information", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpDelete("{clientId}")]
        public JsonResult Delete(int clientId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to delete a client.");

                    var deleteClientCommand = new DeleteClientCommand(clientId);
                    _gate.Dispatch(deleteClientCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete client", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpGet("getLookups")]
        public JsonResult GetClientLookups()
        {
            var projects = _clientFinder.GetLookups();

            return Json(projects);
        }
    }
}