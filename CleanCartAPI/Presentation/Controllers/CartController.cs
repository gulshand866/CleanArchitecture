using Application.Dtos.Cart;
using Application.Interfaces;
using Infrastructure.KafkaProducers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public readonly ICartService _cartService;
        private readonly IKafkaProducer _kafkaProducer;


        public CartController(ILogger<CartController> logger, ICartService cartService, IKafkaProducer kafkaProducer)
        {
            _cartService = cartService;
            _logger = logger;
            _kafkaProducer = kafkaProducer;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(CartIncomingDTO data)
        {
            try
            {
                var _product = await _cartService.AddToCart(data);

                return Ok(_product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(Guid id)
        {
            try
            {
                var cart = await _cartService.GetCart(id);

                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CartCheckout(Guid id)
        {
            try
            {
                var cart = await _cartService.GetCart(id);

                var order = new CartCheckoutDTO()
                {
                    UserId = cart.UserId,
                    Products = cart.Products,
                };

                await _kafkaProducer.ProduceMessage(order);

                var res2 = await _cartService.CartCheckout(id);

                var response = new
                {
                    Cart = res2
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
