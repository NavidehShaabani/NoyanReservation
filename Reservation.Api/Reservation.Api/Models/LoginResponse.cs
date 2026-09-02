namespace Reservation.Api.Models
{




    public class LoginUserRow
    {
        public int Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public DateTime? Valid_From_Date { get; set; }
        public DateTime? Valid_To_Date { get; set; }

        public string? Role_Code { get; set; }
    }

    public class LoginUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public LoginUser User { get; set; } = new();
    }

}


