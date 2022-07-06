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

        public PingController(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            this.publishEndpoint = publishEndpoint;
            this.sendEndpointProvider = sendEndpointProvider;
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
    }
}
