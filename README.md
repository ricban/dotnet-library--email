# Email Library

C# email library using MailKit 

Built with
* .NET 5
* C#
* MailKit


**Sample Usage 1:**

```
public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();

    //Add MailKit
    services.AddMailKit(optionBuilder =>
    {
        optionBuilder.UseMailKit(new MailKitOptions()
        {
            //get options from sercets.json
            Server = Configuration["Server"],
            Port = Convert.ToInt32(Configuration["Port"]),
            SenderName = Configuration["SenderName"],
            SenderEmail = Configuration["SenderEmail"],

            // can be optional with no authentication
            Account = Configuration["Account"],
            Password = Configuration["Password"],
            // enable ssl or tls
            Security = true
        });
    });
}

public class HomeController : Controller
{
    private readonly IEmailService _EmailService;

    public HomeController(IEmailService emailService)
    {
        _EmailService = emailService;
    }

    public IActionResult Email()
    {
        ViewData["Message"] = "ASP.NET Core mvc send email example";

        _EmailService.Send("xxxxx@gmail.com", "Email Subject", "Email Body");

        return View();
    }
}
```

**Sample Usage 2:**

```
var options = new MailKitOptions()
{
    Server = "smtp.gmail.com",
    SenderEmail = "firstname.lastname@gmail.com",
    SenderName = "Firstname Lastname",
    Account = "firstname.lastname@gmail.com",
    Password = "password",
    Port = 465,
    // or
    // Port = 587,
    Security = true
};

var provider = new MailKitProvider(options);
var emailService = new EmailService(provider);

// Async
await emailService.SendAsync("xxxxx@gmail.com", "Email Subject", "Email Body").ConfigureAwait(false);

// Sync
emailService.Send("xxxxx@gmail.com", "Email Subject", "Email Body");
```
