namespace Master.ParamRequest
{
    public record KabupatenCreateReq
    {
        public int ProvinsiId { get; set; }
        public string KabupatenName { get; set; }
        public int KabupatenFl { get; set; }

    }
}
