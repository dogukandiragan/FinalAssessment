using AutoMapper;
using FinalAssessment.Core.DTOs;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
   
        private readonly IMapper _mapper;
        private readonly ITransactionService _service;


        public TransactionController(IMapper mapper, ITransactionService transactionService)
        {
            _mapper = mapper;
            _service = transactionService;
        }




        [Authorize(Roles="Admin,Editor")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllAsync());
        }




        [HttpGet("/WeeklyTransctionReportforExcel")]
        public IActionResult ReportWeekly()
        {
            return Ok(_service.GetTransactionListBySP());
        }



        [Authorize(Roles="Admin,Editor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            return Ok(transactionDto);
        }


        [Authorize(Roles="Admin,Editor")]
        [HttpPost]
        public async Task<IActionResult> Add(TransactionDto transactionDto)
        {
            var transaction = await _service.AddAsync(_mapper.Map<TransactionApp>(transactionDto));
            var TransactionDTO = _mapper.Map<TransactionDto>(transaction);
          
            return Ok();

        }



        [Authorize(Roles="Admin,Editor")]
        [HttpPut]
        public async Task<IActionResult> Update(TransactionDto transactionDto)
        {
            await _service.UpdateAsync(_mapper.Map<TransactionApp>(transactionDto));
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
