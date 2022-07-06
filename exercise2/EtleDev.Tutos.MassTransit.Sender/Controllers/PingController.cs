using EtleDev.Tutos.MassTransit.Core;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EtleDev.Tutos.MassTransit.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ISendEndpointProvider sendEndpointProvider;
        private readonly IRequestClient<Ping> pingHandler;

        public PingController(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider, IRequestClient<Ping> pingHandler)
        {
            this.publishEndpoint = publishEndpoint;
            this.sendEndpointProvider = sendEndpointProvider;
            this.pingHandler = pingHandler;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Send()
        {
            try
            {
                //var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:myqueue"));

                await sendEndpointProvider.Send(new Machin { Content = "Ceci est un message" });

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Publish()
        {
            try
            {
                await publishEndpoint.Publish(new Bidule { Content = "Ceci est un autre message" });

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Ping()
        {
            try
            {
                var ping = new Ping { Id = Guid.NewGuid(), Date = DateTime.Now };
                var response = await pingHandler.GetResponse<Pong>(ping);

                var pong = response.Message;

                if (pong == null)
                {
                    return BadRequest("Pas de réponse");
                }

                return Ok(pong);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
