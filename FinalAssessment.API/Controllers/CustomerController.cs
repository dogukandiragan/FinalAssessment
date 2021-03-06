using AutoMapper;
using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Services;
using FinalAssessment.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace FinalAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
 
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;


        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _service = customerService;
        }



        [Authorize(Roles="Admin,Editor")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllAsync());
        }


   
        [HttpGet("/MonthlyCityReportforExcel")]
        public ActionResult ReportMonthly()
        {
            return Ok(_service.GetCityListWithSP());
        }

        

        [Authorize(Roles="Admin,Editor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var customer = await _service.GetByIdAsync(id);
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDTO);
        }


        //Adding customer with watermark.
        [Authorize(Roles="Admin,Editor")]
        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            Tuple<Byte[], string> watermarkedImageDetail= FinalAssessment.WorkerService.Watermark.watermarked(@customerDto.Imagestring);
            customerDto.Image = watermarkedImageDetail.Item1;
            customerDto.Imagestring = watermarkedImageDetail.Item2;
            var customer = await _service.AddAsync(_mapper.Map<CustomerApp>(customerDto));
            return Ok();

        }


        [Authorize(Roles="Admin,Editor")]
        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<CustomerApp>(customerDto));
            return Ok();
        }


        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(transaction);

            return Ok();
        }






    }
}
