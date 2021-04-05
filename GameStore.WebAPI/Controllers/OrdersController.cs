using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.Contracts;
using GameStore.BLL.Implementation;
using GameStore.Client.DTO;
using GameStore.Client.Requests.Create;
using GameStore.Client.Requests.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.DataAccess.Context;
using GameStore.DataAccess.Entities;
using GameStore.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameStore.WebAPI.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private ILogger<OrdersController> Logger { get; }
        private IOrderCreateService OrderCreateService { get; }
        private IOrderGetService OrderGetService { get; }
        private IOrderUpdateService OrderUpdateService { get; }
        private IGameGetService GameGetService { get; }
        private ICustomerGetService CustomerGetService { get; }
        private IMapper Mapper { get; }

        public OrdersController(ILogger<OrdersController> logger, IOrderCreateService orderCreateService, IOrderGetService orderGetService, IOrderUpdateService orderUpdateService, IGameGetService gameGetService, ICustomerGetService customerGetService, IMapper mapper)
        {
            Logger = logger;
            OrderCreateService = orderCreateService;
            OrderGetService = orderGetService;
            OrderUpdateService = orderUpdateService;
            GameGetService = gameGetService;
            CustomerGetService = customerGetService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(Mapper.Map<IEnumerable<OrderDTO>>(await OrderGetService.GetAsync()));
        }

        [Route("{id}")]
        [Route("get/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderGetService.GetAsync(new OrderIndentityModel((int) id)));

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet]
        [Route("new")]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            ViewData["GameId"] = new SelectList(Mapper.Map<IEnumerable<GameDTO>>(await GameGetService.GetAsync()), "Id", "Title");
            ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [Route("new")]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateDTO orderCreate)
        {
            try
            {
                var order =
                    Mapper.Map<OrderDTO>(
                        await OrderCreateService.CreateAsync(Mapper.Map<OrderUpdateModel>(orderCreate)));
                return Redirect($"/orders/{order.Id}");
            }
            catch
            {
                ViewData["GameId"] = new SelectList(Mapper.Map<IEnumerable<GameDTO>>(await GameGetService.GetAsync()), "Id", "Title");
                ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName");
                return View();
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderGetService.GetAsync(new OrderIndentityModel((int)id)));
            if (order == null)
            {
                return NotFound();
            }

            var updateDto = new OrderUpdateDTO
            {
                Id = order.Id,
                Arrived = order.Arrived,
                CustomerId = order.Customer.Id,
                GameId = order.Game.Id,
                Date = order.Date
            };

            ViewData["GameId"] = new SelectList(Mapper.Map<IEnumerable<GameDTO>>(await GameGetService.GetAsync()), "Id", "Title", updateDto.GameId);
            ViewData["CustomerId"] = new SelectList(Mapper.Map<IEnumerable<CustomerDTO>>(await CustomerGetService.GetAsync()), "Id", "FullName", updateDto.CustomerId);
            return View(updateDto);
        }


        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderUpdateDTO orderUpdate)
        {
            if (id != orderUpdate.Id)
            {
                return NotFound();
            }

            var order = Mapper.Map<OrderDTO>(await OrderUpdateService.UpdateAsync(Mapper.Map<OrderUpdateModel>(orderUpdate)));
            
            return Redirect($"/orders/{order.Id}");
        }
    }
}
