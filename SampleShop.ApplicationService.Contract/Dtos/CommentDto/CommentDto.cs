namespace SampleShop.ApplicationService.Contract.Dtos.CommentDto
{
    public record CommentDto:BaseDto<long>
    {
        public string CommentName { get; set; } = string.Empty;
        public long ProductId { get; set; }
    }
}
