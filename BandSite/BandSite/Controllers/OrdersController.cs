using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandSite.Data;
using BandSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BandSite.Models.ViewModels;

namespace BandSite.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetApplicationUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Orders
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Order.Include(o => o.PaymentType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.PaymentType)
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "PaymentTypeId", "paymentType");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,DateCreated,paymentType,shippingAddress")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PaymentTypesID"] = new SelectList(_context.Set<PaymentType>(), "PaymentTypeId", "paymentType", order.PaymentType);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.Set<PaymentType>(), "PaymentTypeId", "paymentType", order.PaymentType);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,DateCreated,paymentType,shippingAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PaymentTypesId"] = new SelectList(_context.Set<PaymentType>(), "PaymentTypesId", "Type", order.PaymentType);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.SingleOrDefaultAsync(m => m.OrderId == id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<Order> createOrder()
        {
            var order = new Order();
            order.user = await GetApplicationUserAsync();
            _context.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        [Authorize]
        public async Task<IActionResult> buyItem(int? id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(x => x.ProductId == id);
            if(id == null)
            {
                return NotFound();
            }
            _context.Update(product);
            if(id == null)
            {
                return NotFound();
            }
            var user = await GetApplicationUserAsync();
            var order = await _context.Order.SingleOrDefaultAsync(o => o.user.Id == user.Id && o.PaymentType == null);
            if(order == null)
            {
                order = await createOrder();
            }
            var orderProduct = new OrderProduct();
            orderProduct.Order = order;
            orderProduct.Product = await _context.Product.SingleOrDefaultAsync(p => p.ProductId == id);
            _context.Add(orderProduct);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Products", new { id = id });
        }
        [HttpPost]
        public async Task<IActionResult> deleteCart(int? id, string url)
        {
            var orderProd= await _context.OrderProduct.FirstOrDefaultAsync(m => m.ProductId == id);
            _context.OrderProduct.Remove(orderProd);
            await _context.SaveChangesAsync();
            return Redirect($"http://{url}");
        }

        public async Task<IActionResult>orderDeet()
        {
            var user = await GetApplicationUserAsync();
            var vm = new ConfirmViewModel(_context, user);
            if (vm.PayMethods.Count() == 0)
            {
                return RedirectToAction("Create", "PaymentTypes");
            }
            else if (vm.Addresses.Count() == 0)
            {
                return RedirectToAction("Create", "Addresses");
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(int OrdId, int payId)
        {
            var user = await GetApplicationUserAsync();
            var currentOrder = await _context.Order.Include("OrderProduct.Product").SingleOrDefaultAsync(o => o.PaymentType == null && o.user.Id == user.Id);

            if (currentOrder == null || currentOrder.OrderProduct == null)
            {
                return NotFound();
            }
            foreach (var item in currentOrder.OrderProduct)
            {
                item.Product.Quantity = item.Product.Quantity - 1;
                _context.Product.Update(item.Product);
            }
            currentOrder.paymentType = payId;
            currentOrder.shippingAddress = OrdId;
            _context.Order.Update(currentOrder);
            await _context.SaveChangesAsync();
            var orderID = new { orderID = currentOrder.OrderId };
            return RedirectToAction("Index", orderID);
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
