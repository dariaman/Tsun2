namespace User.ParamRequest
{
    public record UserRegisterRequest
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
    }
}
