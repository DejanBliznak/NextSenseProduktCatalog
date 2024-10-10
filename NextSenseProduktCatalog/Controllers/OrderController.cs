using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.ComponentModel.DataAnnotations;

namespace NextSenseProduktCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        
        private readonly IOrderService _orderService;
       
        public OrderController(
            IOrderService orderService
          
            )
        {
            _orderService= orderService;           
        }



        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder(AddOrderModel addOrderModel)
        {

            try
            {
               
               var order = await _orderService.AddOrder(addOrderModel);
                return new JsonResult(order);

            }
            catch (Exception ex)
            {              
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getorders")]
        public async Task<IActionResult> GetOrders([FromQuery] int size , int page , int? productId)
        {

            try
            {
                var orders = await _orderService.GetOrders(size , page, productId);
                return new JsonResult(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getorderdetails")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
           
            try
            {
                var order = await _orderService.GetOrderDetails(orderId);
                return new JsonResult(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reportfororderbyproductandmanufacturer")]
        public async Task<IActionResult> ReportForOrderByProductAndManufacturer()
        {           
            try
            {
                var reportForOrderByProductAndManufacturer = await _orderService.ReportForOrderByProductAndManufacturer();
                return new JsonResult(reportForOrderByProductAndManufacturer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reportfororderbydate")]
        public async Task<IActionResult> ReportForOrderByDate()
        {
            try
            {
                var reportForOrderByDate= await _orderService.ReportForOrderByDate();
                return new JsonResult(reportForOrderByDate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
