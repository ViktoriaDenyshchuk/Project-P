using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using SweetCreativity1.Reposotories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using System.Reflection;
using Microsoft.AspNetCore.SignalR;


namespace SweetCreativity.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReposotory orderReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativity1Context _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;
        public OrderController(IOrderReposotory orderReposotory, IWebHostEnvironment webHostEnviroment, [FromServices] SweetCreativity1Context context, Microsoft.AspNetCore.Identity.UserManager<User> userManager, IHubContext<ChatHub> hubContext)
        {
            this.orderReposotory = orderReposotory;
            this.webHostEnvironment = webHostEnviroment;
            this._context = context;
            this._userManager = userManager;
            _hubContext = hubContext;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var orders = orderReposotory.GetAll();
            var statusList = _context.Statuses.ToList();

            foreach (var order in orders)
            {
                order.Status = statusList.FirstOrDefault(s => s.Id == order.StatusId);
            }

            return View(orders);
        }

        [Authorize(Roles = "Client")]
        public IActionResult IndexClient()
        {
            // Check if the current user is in the "Client" role
            if (User.IsInRole("Client"))
            {
                // Get the current user's ID
                var userId = _userManager.GetUserId(User);

                // Get only the orders that belong to the current user
                var userOrders = orderReposotory.GetAll().Where(order => order.UserId == userId);

                // Get the status list from the database
                var statusList = _context.Statuses.ToList();

                // Set the Status property for each order
                foreach (var order in userOrders)
                {
                    order.Status = statusList.FirstOrDefault(s => s.Id == order.StatusId);
                }

                return View(userOrders);
            }
            else
            {
                // Redirect to a different action or show an error message
                return RedirectToAction("AccessDenied", "Account");
            }
        }

        [Authorize(Roles = "Seller")]
        public IActionResult IndexSeller()
        {
            // Check if the current user is in the "Seller" role
            if (User.IsInRole("Seller"))
            {
                // Get the current user's ID
                var sellerId = _userManager.GetUserId(User);

                // Get only the orders that belong to the current seller
                var sellerOrders = _context.Orders
    .Include(order => order.Listing)
    .Where(order => order.Listing.UserId == sellerId)
    .ToList();

                // Get the status list from the database
                var statusList = _context.Statuses.ToList();

                // Set the Status property for each order
                foreach (var order in sellerOrders)
                {
                    // Ensure that the Listing navigation property is not null
                    if (order.Listing != null)
                    {
                        if (order.StatusId != null)
                        {
                            order.Status = statusList.FirstOrDefault(s => s.Id == order.StatusId);
                        }
                    }
                }

                return View(sellerOrders);
            }
            else
            {
                // Redirect to a different action or show an error message
                return RedirectToAction("AccessDenied", "Account");
            }
        }


        //[Authorize(Roles = "Admin, Client, Seller")]
        //public IActionResult Details(int id)
        //{
        //    var order = _context.Orders.Find(id);

        //    // Отримати список статусів з бази даних
        //    var statusList = _context.Statuses.ToList();

        //    // Передати список статусів у ViewBag
        //    ViewBag.StatusList = new SelectList(statusList, "Id", "StatusName");
        //    return View(orderReposotory.Get(id));
        //}
        [Authorize(Roles = "Admin, Client, Seller")]
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.ChatMessage)
                .Include(o => o.Listing)
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Перевірити, чи поточний користувач має право переглядати це замовлення
            if (!User.IsInRole("Admin") && _userManager.GetUserId(User) != order.UserId && _userManager.GetUserId(User) != order.Listing.UserId)
            {
                return Forbid();
            }

            // Отримати список статусів з бази даних
            var statusList = _context.Statuses.ToList();

            // Передати список статусів у ViewBag
            ViewBag.StatusList = new SelectList(statusList, "Id", "StatusName");
            ViewBag.OwnerName = order.User?.FullName;

            return View(orderReposotory.Get(id));
        }


        //[Authorize(Roles = "Client")]
        //[HttpGet]
        ////[HttpGet("Create/{listingId}")]
        //public IActionResult Create(int listingId)
        //{
        //    var listing = _context.Listings.FirstOrDefault(l => l.Id == listingId);

        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = new Order
        //    {
        //        Listing = listing,
        //        NameOrder = listing.Title,
        //        PriceOne = listing.Price,
        //        ListingPhotoPath = listing.CoverPath,
        //        //CoverPath = listing.CoverPath,
        //        // Інші властивості order
        //    };

        //    return View(order);
        //}
        //[Authorize(Roles = "Client")]
        //[HttpPost]
        //public IActionResult Create(Order model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //string wwwRootPath = webHostEnvironment.WebRootPath;

        //        //string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

        //        //string extension = Path.GetExtension(model.CoverFile.FileName);
        //        //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        //model.CoverPath = "/img/user/" + fileName;
        //        //string path = Path.Combine(wwwRootPath + "/img/user/", fileName);

        //        //using (var fileStream = new FileStream(path, FileMode.Create))
        //        //{
        //        //    model.CoverFile.CopyTo(fileStream);
        //        //}

        //        orderReposotory.Add(model);
        //        return RedirectToAction(nameof(IndexClient));
        //    }
        //    return View(model);

        //}
        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult Create(int listingId)
        {
            // Retrieve the listing based on the provided listingId
            var listing = _context.Listings.FirstOrDefault(l => l.Id == listingId);

            if (listing == null)
            {
                return NotFound();
            }

            // Create a new order and associate it with the retrieved listing
            var order = new Order
            {
                Listing = listing,
                ListingId = listingId,
                NameOrder = listing.Title,
                PriceOne = listing.Price,
                ListingPhotoPath = listing.CoverPath,
                UserId = _userManager.GetUserId(User)
            };

            return View(order);
        }

        //[Authorize(Roles = "Client")]
        //[HttpPost]
        //public IActionResult Create(Order model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.UserId = _userManager.GetUserId(User);

        //        orderReposotory.Add(model);
        //        _context.SaveChanges();

        //        return RedirectToAction(nameof(IndexClient));
        //    }

        //    return View(model);
        //}

        //[Authorize(Roles = "Client")]
        //[HttpGet]
        //public IActionResult Create(int listingId)
        //{
        //    // Retrieve the listing based on the provided listingId
        //    var listing = _context.Listings.FirstOrDefault(l => l.Id == listingId);

        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    // Create a new order and associate it with the retrieved listing
        //    var order = new Order
        //    {
        //        Listing = listing,
        //        ListingId = listingId,
        //        NameOrder = listing.Title,
        //        PriceOne = listing.Price,
        //        ListingPhotoPath = listing.CoverPath,
        //        UserId = _userManager.GetUserId(User)
        //    };

        //    return View(order);
        //}
        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                // Встановити UserId на ідентифікатор поточного користувача
                model.UserId = _userManager.GetUserId(User);

                // Продовжити з іншими перевірками...

                // Calculate and set TotalPrice
                model.TotalPrice = CalculateTotalPrice(model);

                // Save to the database or perform other actions
                orderReposotory.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(IndexClient));
            }

            return View(model);
        }






        //private decimal CalculateTotalPrice(Order order)
        //{
        //    // Логіка обчислення загальної ціни з урахуванням знижки
        //    decimal totalPrice = (decimal)(order.Quantity * order.PriceOne);
        //    if (order.Discount > 0)
        //    {
        //        totalPrice -= totalPrice * (decimal)(order.Discount / 100.0);
        //    }
        //    return totalPrice;
        //}
        private decimal CalculateTotalPrice(Order order)
        {
            decimal totalPrice = (decimal)(order.Quantity * order.PriceOne);

            if (order.Discount > 0)
            {
                // Use ?? to handle null Discount values
                totalPrice -= totalPrice * (decimal)(order.Discount ?? 0) / 100.0m;
            }

            return totalPrice;
        }



        private decimal CalculateDiscountPercentage(int orderCount)
        {
            // Логіка розрахунку знижки на основі кількості замовлень
            if (orderCount == 1)
            {
                return (decimal)5.0; // 5% для першого замовлення
            }
            else if (orderCount == 5)
            {
                return (decimal)10.0; // 10% для п'ятого замовлення
            }
            else if (orderCount == 10)
            {
                return (decimal)15.0; // 15% для десятого замовлення
            }
            else
            {
                return (decimal)0.0; // Без знижки для інших замовлень
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(orderReposotory.Get(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            orderReposotory.Delete(order);

            return RedirectToAction("Index");
        }

        ////[HttpPost]
        ////public IActionResult UpdateStatus(int id, int statusId)
        ////{
        ////    var order = _orderRepository.Get(id);
        ////    if (order != null)
        ////    {
        ////        order.StatusId = statusId;
        ////        _orderRepository.Update(order);
        ////    }

        ////    return RedirectToAction("Details", new { id });
        ////}
        ///
        [Authorize(Roles = "Seller")]
        [HttpPost]
        public IActionResult UpdateStatus(int id, int statusId)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.StatusId = statusId;
                _context.SaveChanges();
            }

            return RedirectToAction("IndexSeller");
        }
        //Варіант 1
        //[HttpPost]
        //public async Task<IActionResult> AddMessage(int orderId, string textMessage, string userId)
        //{
        //    var order = await _context.Orders
        //        .Include(o => o.ChatMessage)
        //        .FirstOrDefaultAsync(o => o.Id == orderId);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var newMessage = new ChatMessage
        //    {
        //        TextMessage = textMessage,
        //        CreatedAtMessage = DateTime.Now,
        //        UserId = userId // Додайте ідентифікатор користувача до відгуку
        //    };

        //    order.ChatMessage.Add(newMessage);
        //    await _context.SaveChangesAsync();

        //    // Після додавання відгуку перенаправте користувача на сторінку оголошення
        //    return RedirectToAction("Details", new { id = orderId });
        //}
        [HttpPost]
        public async Task<IActionResult> AddMessage(int orderId, string textMessage, string userId)
        {
            var order = await _context.Orders
                .Include(o => o.ChatMessage)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var newMessage = new ChatMessage
            {
                TextMessage = textMessage,
                CreatedAtMessage = DateTime.Now,
                UserId = userId,
                SenderName = user.FullName  // Set the SenderName property to the user's full name
            };

            order.ChatMessage.Add(newMessage);
            await _context.SaveChangesAsync();

            // Notify all clients through SignalR with the sender's name and message
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user.FullName, textMessage);

            // Pass the sender's name to the view
            ViewBag.UserFullName = user.FullName;

            return RedirectToAction("Details", new { id = orderId, userFullName = user.FullName });
        }



    }



}