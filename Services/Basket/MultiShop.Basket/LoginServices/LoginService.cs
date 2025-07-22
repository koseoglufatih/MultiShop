namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            httpContextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
               
                    var userIdClaim = httpContextAccessor?.HttpContext?.User?.FindFirst("sub");
                    if (userIdClaim == null)
                    {
                        return "1";
                    }

                    return userIdClaim.Value;
                }
        }
    }
}
