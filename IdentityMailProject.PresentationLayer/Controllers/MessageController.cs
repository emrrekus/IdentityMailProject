using IdentityMailProject.BusinessLayer.Abstract;
using IdentityMailProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMailProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly UserManager<AppUser> _userManager;

        private readonly IMessageService _messageService;



        public MessageController(ICategoryService categoryService, UserManager<AppUser> userManager, IMessageService messageService)
        {
            _categoryService = categoryService;
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.categories = _categoryService.TGetAll();
            var inboxMessages = await _messageService.TMessageListByUserIdAsync(user.Id);

            return View(inboxMessages);
        }

        [HttpGet]
        public async Task<IActionResult> GetInboxMessages()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);


                var inboxMessages = await _messageService.TMessageListByUserIdAsync(user.Id);
                var dto = inboxMessages.Select(m => new
                {
                    Content = m.Content,
                    SentDate = m.SentDate,
                    MessageId = m.MessageId
                }).ToList();

                return Json(dto);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSentMessages()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var sentMessages = await _messageService.TGetSentMessagesByUserIdAsync(user.Id);
                var dto = sentMessages.Select(m => new
                {
                    Content = m.Content,
                    SentDate = m.SentDate,
                    MessageId = m.MessageId
                }).ToList();

                return Json(dto);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryMessages(int categoryId)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
              

                var categoryMessages = await _messageService.TGetMessagesByCategoryAndUserAsync(categoryId, user.Id);

                var dto = categoryMessages.Select(m => new
                {
                    Content = m.Content,
                    SentDate = m.SentDate,
                    MessageId = m.MessageId
                }).ToList();

                return Json(dto);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMail(int messageId)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var message = await _messageService.TGetMessageDetailAsync(messageId);
                if (message == null)
                {
                    return Json(new { success = false, message = "Mesaj bulunamadı." });
                }

                var result = new
                {
                    success = true,
                    Subject = message.Subject,
                    Content = message.Content,
                    SentDate = message.SentDate,
                    Sender = message.Recipients.Select(n => new
                    {
                        Name = n.SenderUser.Name,
                        Surname = n.SenderUser.Surname,
                        Email = n.SenderUser.Email,
                    }).FirstOrDefault(),

                    Recipent = message.Recipients.Select(r => new
                    {
                        Name = r.RecipientUser.Name,
                        Surname = r.RecipientUser.Surname,
                        Mail = r.RecipientUser.Email
                    }).ToList()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> SendMail(IFormCollection form)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return Json(new { success = false, message = "Kullanıcı oturumu bulunamadı." });
                }
                var recipients = form["Recipients"].ToString().Split(',').Select(email => email.Trim()).ToList();
                var subject = form["Subject"].ToString();
                var content = form["Content"].ToString();
                List<int> recipientIds = new List<int>();
                foreach (var recipientEmail in recipients)
                {
                    var recipient = await _userManager.FindByEmailAsync(recipientEmail);
                    if (recipient != null)
                    {
                        recipientIds.Add(recipient.Id);
                    }
                }
                if (!recipientIds.Any())
                {
                    return Json(new { success = false, message = "Geçerli alıcı bulunamadı." });
                }
                var message = new Message
                {
                    Subject = subject,
                    Content = content,
                    SentDate = DateTime.Now
                };

                await _messageService.TCreateMailAsync(message, user.Id, recipientIds);

                return Json(new { success = true, message = "Mesaj başarıyla gönderildi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }



    }
}